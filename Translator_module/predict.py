import translator_helper as helper
#%tensorflow_version 1.x
import tensorflow as tf
import preprocess_util as putil
import numpy as np

save_path = "./translating_checkpoints/dev"
PREPROCESS_SAVE_PATH = "preprocssed_data.p"
batch_size = 256
load_path = "./translating_checkpoints/dev"
loaded_graph = tf.Graph()
(src_int_text, tgt_int_text), (src_vocab_to_int, tgt_vocab_to_int), (src_int_to_vocab, tgt_int_to_vocab)  = helper.load_preprocessed_data(PREPROCESS_SAVE_PATH)
max_tgt_len = max([len(sen) for sen in tgt_int_text])

def sent_to_int(sentence, vocab_to_int):
    return [src_vocab_to_int.get(word, vocab_to_int.get('<UNK>')) for word in sentence.lower().split()]

def decode_sentence(translation):
  return " ".join([tgt_int_to_vocab[i] for i in translation])

def translate(sentence):
  cleaned_sen = helper.clean_data(sentence)
  int_sen = sent_to_int(cleaned_sen, src_vocab_to_int)
  with tf.Session(graph=loaded_graph) as sess:
    # Load saved model
    loader = tf.train.import_meta_graph(load_path + '.meta')
    loader.restore(sess, load_path)

    input_data = loaded_graph.get_tensor_by_name('src_input:0')
    logits = loaded_graph.get_tensor_by_name('predictions:0')
    target_sequence_length = loaded_graph.get_tensor_by_name('tgt_seq_len:0')
    source_sequence_length = loaded_graph.get_tensor_by_name('src_seq_len:0')
    keep_prob = loaded_graph.get_tensor_by_name('keep_prob:0')

    translation = sess.run(logits, {input_data: [int_sen]*batch_size,
                                       target_sequence_length: [len(int_sen)*2]*batch_size,
                                       source_sequence_length: [len(int_sen)]*batch_size,
                                       keep_prob: 1.0})[-1]
    return decode_sentence(translation)

