import translator_helper as helper
import os
import preprocess_util as putil
import numpy as np
from sklearn.model_selection import train_test_split
import tensorflow.compat.v1 as tf
from tensorflow import keras

source_vocab_mapping = "./amh_vocab_mapping.p"
target_vocab_mapping = "./amh_vocab_mapping.p"
PREPROCESS_SAVE_PATH = "preprocssed_data.p"

(src_int_text, tgt_int_text), (src_vocab_to_int, tgt_vocab_to_int), (src_int_to_vocab, tgt_int_to_vocab)  = helper.load_preprocessed_data(PREPROCESS_SAVE_PATH)

BATCH_SIZE = 256
embedding_dim = 256
rnn_size = 256
lr = 0.001

def get_embedding_mat(embedding_size, vocab_size, load_path):
  embed_graph = tf.Graph()
  with embed_graph.as_default():
    inputs = tf.compat.v1.placeholder(tf.int32, [None], name='inputs')
    labels = tf.compat.v1.placeholder(tf.int32, [None, None], name='labels')
    embedding = tf.Variable(tf.compat.v1.truncated_normal([vocab_size, embedding_size]))
  with embed_graph.as_default():
    saver = tf.compat.v1.train.Saver()

  with tf.compat.v1.Session(graph=embed_graph) as sess:
    saver.restore(sess, tf.train.latest_checkpoint(load_path))
    embed_mat = sess.run(embedding)
  #tf.reset_default_graph()
  return embed_mat

def gru(units):
    if tf.test.is_gpu_available():
        return tf.keras.layers.CuDNNGRU(units, 
                                        return_sequences=True, 
                                        return_state=True, 
                                        recurrent_initializer='glorot_uniform')
    else:
        return tf.keras.layers.GRU(units, 
                                   return_sequences=True, 
                                   return_state=True, 
                                   recurrent_activation='sigmoid', 
                                   recurrent_initializer='glorot_uniform')

class Encoder(tf.keras.Model):
    def __init__(self, embed_mat, rnn_size, batch_size):
        super(Encoder, self).__init__()
        self.batch_size = batch_size
        self.rnn_size = rnn_size
        self.embed_mat = embed_mat
        self.gru = gru(self.rnn_size)
        
    def call(self, enc_input, hidden):
        embeded_input = tf.nn.embedding_lookup(self.embed_mat, enc_input)
        output, state = self.gru(embeded_input, initial_state = hidden)        
        return output, state
    
    def initialize_hidden_state(self):
        return tf.zeros((self.batch_size, self.rnn_size))

class Decoder(tf.keras.Model):
    def __init__(self, tgt_vocab_size, embed_mat, rnn_size, batch_size):
        super(Decoder, self).__init__()
        self.batch_size = batch_size
        self.rnn_size = rnn_size
        self.embed_mat = embed_mat
        self.gru = gru(self.rnn_size)


        self.output_layer = tf.keras.layers.Dense(tgt_vocab_size)
        # used for attention
        self.W1 = tf.keras.layers.Dense(self.rnn_size)
        self.W2 = tf.keras.layers.Dense(self.rnn_size)
        self.V = tf.keras.layers.Dense(1)

    def call(self, dec_input, hidden, enc_output):
        # enc_output shape == (batch_size, max_length, hidden_size) 
        # hidden shape == (batch_size, hidden size)
        # hidden_with_time_axis shape == (batch_size, 1, hidden size)
        # we are doing this to perform addition to calculate the score
        hidden_with_time_axis = tf.expand_dims(hidden, 1)
        
        # score shape == (batch_size, max_length, 1)
        # we get 1 at the last axis because we are applying tanh(FC(EO) + FC(H)) to self.V
        # this is the step 1 described in the blog to compute scores s1, s2, ...
        score = self.V(tf.nn.tanh(self.W1(enc_output) + self.W2(hidden_with_time_axis)))
        
        # attention_weights shape == (batch_size, max_length, 1)
        # this is the step 2 described in the blog to compute attention weights e1, e2, ...
        attention_weights = tf.nn.softmax(score, axis=1)
        
        # context_vector shape after sum == (batch_size, hidden_size)
        # this is the step 3 described in the blog to compute the context_vector = e1*h1 + e2*h2 + ...
        context_vector = attention_weights * enc_output
        context_vector = tf.reduce_sum(context_vector, axis=1)
        
        # x shape after passing through embedding == (batch_size, 1, embedding_dim)
        dec_embeded_input = tf.nn.embedding_lookup(self.embed_mat, dec_input)
        
        # x shape after concatenation == (batch_size, 1, embedding_dim + hidden_size)
        # this is the step 4 described in the blog to concatenate the context vector with the output of the previous time step
        x = tf.concat([tf.expand_dims(context_vector, 1), dec_embeded_input], axis=-1)
        
        # passing the concatenated vector to the GRU
        output, state = self.gru(x)
        
        # output shape == (batch_size * 1, hidden_size)
        output = tf.reshape(output, (-1, output.shape[2]))
        
        # output shape == (batch_size * 1, vocab)
        # this is the step 5 in the blog, to compute the next output word in the sequence
        x = self.output_layer(output)
        
        # return current output, current state and the attention weights
        return x, state, attention_weights
        
    def initialize_hidden_state(self):
        return tf.zeros((self.batch_sz, self.dec_units))
# loading the embedding matrix
src_embed_mat = get_embedding_mat(256, len(src_int_to_vocab),"embedding_checkpoints")
tgt_embed_mat = get_embedding_mat(256, len(src_int_to_vocab),"embedding_checkpoints")

# intitalizing the encoder and decoder
encoder = Encoder(src_embed_mat, 256, 256)
decoder = Decoder(len(tgt_vocab_to_int), tgt_embed_mat, 256, 256)
optimizer = tf.train.AdamOptimizer()
def loss_function(real, pred):
    mask = 1 - np.equal(real, 0)
    loss_ = tf.nn.sparse_softmax_cross_entropy_with_logits(labels=real, logits=pred) * mask
    return tf.reduce_mean(loss_)
checkpoint_dir = './training_checkpoints3'
checkpoint_prefix = os.path.join(checkpoint_dir, "ckpt")
checkpoint = tf.train.Checkpoint(optimizer=optimizer,
                                 encoder=encoder,
                                 decoder=decoder) 
def evaluate(inputs, encoder, decoder, max_length_tgt_to_trans): 
    inputs = tf.convert_to_tensor(inputs)
    result = ''
    init_hidden = [tf.zeros((1, 256))]
    enc_out, enc_hidden = encoder(inputs, init_hidden)

    dec_hidden = enc_hidden
    dec_input = tf.expand_dims([tgt_vocab_to_int['<GO>']], 0)

    for t in range(max_length_tgt_to_trans): 
        translation, dec_hidden, _ = decoder(dec_input, dec_hidden, enc_out)  
        translation = tf.argmax(translation[0]).numpy()
        result += tgt_int_to_vocab[translation] + ' '
        if tgt_int_to_vocab[translation] == '<EOS>':
            return result
        dec_input = tf.expand_dims([translation], 0)

    return result
def sent_to_int(sentence, vocab_to_int):
    return [src_vocab_to_int.get(word, vocab_to_int.get('<UNK>')) for word in sentence.lower().split()]

def decode_sentence(translation):
  return " ".join([tgt_int_to_vocab[i] for i in translation])
checkpoint.restore(tf.train.latest_checkpoint(checkpoint_dir))
def translate(sentence):
  cleaned_sen = helper.clean_data(sentence)
  sen_int = sent_to_int(cleaned_sen, src_vocab_to_int)
  return evaluate([sen_int], encoder, decoder, 20)






