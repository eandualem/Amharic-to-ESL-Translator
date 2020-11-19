
import os
import re
import numpy as np
import librosa
import keras
import random
from librosa import display, load, resample
import _pickle as pickle

import tensorflow as tf
from tqdm import tqdm

from tensorflow.keras.models import Model, Sequential
from tensorflow.keras.layers import * 
from tensorflow.keras.preprocessing.text import Tokenizer
from tensorflow.keras.preprocessing.sequence import pad_sequences
from tensorflow.keras.optimizers import SGD, Adam, RMSprop
from tensorflow.keras.callbacks import Callback, EarlyStopping, ModelCheckpoint, TensorBoard

from keras.utils import plot_model
from keras import backend as K

import kapre
from kapre.utils import Normalization2D
from kapre.time_frequency import Melspectrogram, Spectrogram 


def clean_signal(signal, normalize = False ,trim_db = None, clean_db = None):

    if normalize:
        feats_mean = np.mean(signal, axis=0)
        feats_std = np.std(signal, axis=0)
        signal = (signal - feats_mean) / (feats_std + 1e-14)

    if trim_db:
        signal, index = librosa.effects.trim(signal, top_db=trim_db)

    if clean_db:
        yt = librosa.effects.split(signal, top_db=clean_db)
        clean_signal = []
        for start_i, end_i in yt:
            clean_signal.append( signal[start_i: end_i])

        signal = np.concatenate(np.array(clean_signal),axis=0)

    return signal

def WAV2Numpy(folder, sr):

    allFiles = []
    for root, dirs, files in os.walk(folder):
        allFiles += [os.path.join(root, f) for f in files
                     if f.endswith('.wav')]

    i = 0
    for file in tqdm(allFiles):
        try:
            wav, rate = librosa.load(file, sr=None)
            y_ = librosa.resample(wav, rate, sr)

            y = clean_signal(y_, True, 24, 30)

            np.save(file.strip('.wav') + '.npy', y)
            os.remove(file)
        
        except EOFError as e:
            pass

def get_text(PATH_TEXT, labels):
    text  = []
    start = re.escape("(")
    end   = re.escape(")")
    
    with open(PATH_TEXT) as fp:
        line = fp.readline()
        while line:
            text.append(line.replace('<s> ', '').replace(' </s> ', ''))
            line = fp.readline()
    
    new_text = []
    new_labels = []
    for i in text:
        result = re.search('%s(.*)%s' % (start, end), i).group(1)
        
        if result in labels: # if the audio file exists 
            new_text.append( i.replace('(' + result + ')\n', ''))
            new_labels.append(result)

    return new_text, new_labels

def sort_by_duration(PATH, labels, text, longets_audio):
    
    dt           = []
    sorted_label = []
    sorted_text  = []
    new_labels   = []

    for label in labels:
        wav = np.load(PATH + '/' + label + '.npy')
        
        if len(wav) < longets_audio: 
            dt.append(len(wav))
            new_labels.append(label)

    dt_dict = dict(zip(new_labels, dt))
    for k in sorted(dt_dict, key=dt_dict.get, reverse=True):
        sorted_label.append(k)

    for i in sorted_label:
        sorted_text.append(text[labels.index(i)])
    
    return dt, dt_dict, sorted_label, sorted_text

def char_per_sec(PATH, labels, text, sr):
    
    char_sec = []

    for label, txt in zip(labels, text):

        wav = np.load(PATH + '/' + label + '.npy')
        char_sec.append(len(txt)*(sr/len(wav)))
    
    return char_sec

def remove_char_sec(PATH, labels, text, sr, min, max):
    
    new_text = []
    new_labels = []

    for label, txt in zip(labels, text):
        wav = np.load(PATH + '/' + label + '.npy')
        x = len(txt)*(sr/len(wav))

        if (min < x < max):
            new_text.append(txt)
            new_labels.append(label)
    
    return new_labels, new_text

def compare(i, fft_size, n_mels_list, hop_size_list, sr=16000):

    sample_data = sample_generator.__getitem__(i)
    sample_audios = sample_data[0]["the_input"]
    sample_labels = sample_data[0]["the_labels"]

    nrows, ncols = len(hop_size_list), len(n_mels_list), 
    plt.figure(figsize=(4*nrows, 4*ncols));

    for i in range(nrows):
        n_mels = n_mels_list[i]

        for y in range(ncols):
            hop_size = hop_size_list[y]
            
            plt.subplot(nrows, ncols, i*ncols+y+1);

            model = preprocessin_model(fft_size, hop_size, n_mels)
            pred = model.predict(sample_audios)
            
            pred = pred[0, :, :, 0]
            librosa.display.specshow(pred.T, sr=sr, hop_length=hop_size, cmap="jet")
            plt.title('hop: {}, n_mels: {}, shape: {}'.format(hop_size, n_mels, pred.shape), fontsize=11)

    print("The longest sentence in this batch has {} characters".format(sample_labels.shape[1]))

    plt.tight_layout();
    plt.show()

# cmaps = ["jet", "gray_r", "viridis", "cubehelix", "RdBu"]

def vis_model(pred, title):
    librosa.display.specshow(pred.T, sr=sr, y_axis='mel', x_axis='time', hop_length=hop_size, cmap="jet")
    plt.title('{}. Shape = {}'.format(title, pred.shape))
    plt.colorbar(format='%+2.0f dB')
    plt.tight_layout()
    plt.show()

class TokenizerWrap(Tokenizer):
    
    def __init__(self, texts, padding, len_sent, filters, reverse=False):
        Tokenizer.__init__(self, filters=filters, char_level=True)

        self.len_sent = len_sent
        self.fit_on_texts(texts)

        self.index_to_word = dict(zip(self.word_index.values(), self.word_index.keys()))
        self.tokens = self.texts_to_sequences(texts)

        if reverse:
            self.tokens = [list(reversed(x)) for x in self.tokens]
            truncating = 'pre'
        else:
            truncating = 'post'

        self.tokens_padded = pad_sequences( self.tokens,
                                           maxlen=len_sent,
                                           padding=padding,
                                           truncating=truncating
                                          )

    def token_to_word(self, token):
        word = " " if token == 0 else self.index_to_word[token]
        return word 

    def tokens_to_string(self, tokens):
        words = [self.index_to_word[token] for token in tokens if token != 0]
        text = " ".join(words)
        return text
    
    def text_to_tokens(self, text, reverse=False, padding=False):
        tokens = self.texts_to_sequences([text])
        tokens = np.array(tokens)

        if reverse:
            tokens = np.flip(tokens, axis=1)
            truncating = 'pre'
        else:
            truncating = 'post'

        if padding:
            tokens = pad_sequences( tokens,
                                   maxlen=self.len_sent,
                                   padding=truncating,
                                   truncating=truncating
                                  )
        return tokens


class DataGenerator(tf.keras.utils.Sequence):
    def __init__(self, wav_paths, labels, text, dt_dict, batch_size=32, shuffle=True):
        self.wav_paths = wav_paths
        self.labels = labels
        self.text = text 
        self.dt_dict = dt_dict                                           
        self.batch_size = batch_size
        self.len = int(np.floor(len(self.labels) / self.batch_size))
        self.shuffle = shuffle
        self.on_epoch_end()

    def __len__(self):
        return self.len
        
    def __data_generation(self, batch_labels, batch_text):

        longest_audio = max([self.dt_dict[i] for i in batch_labels])
        longest_label = len(max(batch_text, key=len))
        longest_label = longest_label if longest_label < 130 else 130 
       
        X_data          = np.zeros([self.batch_size, longest_audio], dtype="float32")
        labels          = np.ones([self.batch_size, longest_label], dtype="int64")
        input_length    = np.ones([self.batch_size, 1], dtype="int64") * longest_audio
        label_length    = np.zeros([self.batch_size, 1], dtype="int64")
        
        i = 0
        for label, txt in zip(batch_labels, batch_text):
            
            wav = np.load(self.wav_paths + '/' + label + '.npy')

            X_data[i, :self.dt_dict[label]] = wav

            label_length[i] = len(txt) if len(txt) < 130 else 130 
            labels[i,] = tf.convert_to_tensor(tokenizer.text_to_tokens(txt, padding=True)[:,:longest_label])
            
            i+=1
        
        outputs = {'ctc': tf.zeros( ([self.batch_size]), dtype=tf.dtypes.float32)}
        inputs = {
                    'the_input':    tf.convert_to_tensor(X_data), 
                    'the_labels':   tf.convert_to_tensor(labels), 
                    'input_length': tf.convert_to_tensor(input_length, dtype="float32"), 
                    'label_length': tf.convert_to_tensor(label_length)
                }
        return (inputs, outputs)
            
    def on_epoch_end(self):
                
        self.indexes = np.arange(self.len*self.batch_size)

        if self.shuffle == True:
            
            self.indexes = self.indexes.reshape(self.len, self.batch_size)
            np.random.shuffle(self.indexes)

            for i in range(self.len):
                np.random.shuffle(self.indexes[i])

            self.indexes = self.indexes.reshape(self.len*self.batch_size)


    def __getitem__(self, index):
        indexes = self.indexes[index*self.batch_size:(index+1)*self.batch_size]

        batch_labels = [self.labels[int(k)] for k in indexes]
        batch_text = [self.text[int(k)] for k in indexes]
        
        return  self.__data_generation(batch_labels, batch_text)



def MFCC(input, num_mfccs=13):
    input = tf.squeeze( input, axis=2)
    return tf.signal.mfccs_from_log_mel_spectrograms(input)[..., :num_mfccs]

def MFCCLayer(input):
    return tf.map_fn(MFCC, input)

def preprocessin_model(fft_size, hop_size, n_mels, sr, mfcc=False):
    
    input_data = Input(name='input', shape=(None,), dtype="float32")
    x = Reshape((1, -1), dtype="float32")(input_data)
    
    spec = Melspectrogram(  n_dft=fft_size, 
                            n_hop=hop_size,
                            padding='same', 
                            sr=sr, 
                            n_mels = n_mels,
                            power_melgram=1.0,
                            return_decibel_melgram=True, 
                            trainable_fb=False,
                            trainable_kernel=False,
                            name='mel_stft') (x)

    x = Normalization2D(int_axis=0)(spec)

    x = Permute((2, 1, 3), name='permute', dtype="float32")(x)

    if mfcc: x = Lambda(MFCCLayer, name='MFCCLayer')(x)

    model = Model( inputs=input_data, outputs=x, name="preprocessin_model" )
    
    return model




def vis(j=5):

    for i in range(0, 260, 260//j):
    
        sample_data = sample_generator.__getitem__(i)
        sample_audios = sample_data[0]["the_input"]
        sample_labels = sample_data[0]["the_labels"]
        sample_labels_length = sample_data[0]["input_length"]

        melspec = melspecModel.predict(sample_audios)
        mfcc = MFCCModel.predict(sample_audios)

        print('\n')
        print('-'*100)

        print("The longest sentence in this batch has {} characters".format(sample_labels.shape[1]))
        print("Longest sentence has to double {} times to reach length of Time steps".format(np.log2([melspec.shape[1]/sample_labels.shape[1]])[0]))

        time_span = (1/sr)
        print("Single sample every: {} ms".format(time_span * 10**3 ))

        print("Duration of single frame: {}ms".format(fft_size * time_span * 10**3 ))

        print("Gap between frames: {}ms".format(hop_size * time_span * 10**3 ))

        char_frame = (sample_labels_length[0]/(fft_size*sample_labels.shape[1]))[0]
        print("Single Character spans {} frames".format( char_frame))

        char_hops = (sample_labels_length[0]/(hop_size*sample_labels.shape[1]))[0]
        print("Single Character spans {} hops".format( char_hops))

        print('-'*100)
        print('\n')

        fig, ax = plt.subplots(figsize=(16,4))
        pred = melspec[0, :, :, 0]
        vis_model(pred, "Mel-frequency spectrogram")

        fig, ax = plt.subplots(figsize=(16,4))
        pred = mfcc[0, :, :]
        vis_model(pred, "MFCC")


"""# Models
<br>
<br>
<br>

## Final Data
<br>
<br>
"""



"""## CTC
<br>
<br>
"""

def ctc_lambda_func(args):
    y_pred, labels, input_length, label_length = args
    return K.ctc_batch_cost(labels, y_pred, input_length, label_length)

def input_lengths_lambda_func(args):
    input_length = args
    return tf.cast(tf.math.ceil(input_length/hop_size), dtype="float32")


def add_ctc_loss(model_builder):
    the_labels      = Input(name='the_labels',      shape=(None,), dtype='float32')
    input_lengths   = Input(name='input_length',    shape=(1,), dtype='float32')
    label_lengths   = Input(name='label_length',    shape=(1,), dtype='float32')

    input_lengths2 = Lambda(input_lengths_lambda_func)(input_lengths)
    if model_builder.output_length:
         output_lengths  = Lambda(model_builder.output_length)(input_lengths2)
    else:
         output_lengths  = input_lengths2
    
    # CTC loss is implemented in a lambda layer
    loss_out = Lambda(ctc_lambda_func, output_shape=(1,), name='ctc')([model_builder.output, the_labels, output_lengths, label_lengths])
    model = Model( inputs=[model_builder.input, the_labels, input_lengths, label_lengths],  outputs=loss_out)
    return model

"""## Model Builder
<br>
<br> 
"""

def build_model(melspecModel, output_dim, custom_model, mfcc=False, calc=None):

    input_audios = Input(name='the_input', shape=(None,))

    if mfcc:
         pre = MFCCModel(input_audios)
    else:
         pre = melspecModel(input_audios)
         pre = Lambda(lambda x: tf.squeeze(x, [3]))(pre)


    y_pred = custom_model(pre)
    
    model = Model( inputs=input_audios, outputs=y_pred, name="model_builder" )

    model.output_length = calc
    
    return model

"""## Train
<br>
<br>
"""

def train(model_builder,  
          model_name, 
          epochs=20, 
          verbose=1,
          optimizer=SGD(lr=0.002, decay=1e-6, momentum=0.9, nesterov=True, clipnorm=5),
          ):    
              
    model = add_ctc_loss(model_builder)

    # optimizer = Adam(lr=.005, clipnorm = 1, decay=1e-6)
    model.compile(loss={'ctc': lambda y_true, y_pred: y_pred}, optimizer=optimizer)


    # make results/ directory, if necessary
    if not os.path.exists('models'):
        os.makedirs('models')

    # add checkpointer
    checkpointer = ModelCheckpoint(filepath=PATH_Model+model_name+'.h5', verbose=0)
    early_stopping = EarlyStopping( monitor="val_loss", patience=10, restore_best_weights=True)

    # train the model
    hist = model.fit_generator(generator=train_gen,
                               validation_data=val_gen,
                               epochs=epochs, 
                               callbacks=[checkpointer, early_stopping], 
                               verbose=verbose, 
                               use_multiprocessing=False)

    # save model loss
    with open(PATH_Model+model_name+'.pickle', 'wb') as f:
        pickle.dump(hist.history, f)

"""# Model building
<br>
<br>
<br>

## Model 0: RNN
<br>
<br>
"""\

"""## ResNet
<br>
<br>
"""

def cnn_output_length(input_length, kernel_list, pool_sizes, cnn_stride, mx_stride, padding='same'):

    if padding == 'same':        
        output_length = input_length
        for i, j in zip(cnn_stride, pool_sizes):
            output_length = (output_length)/i
            if j != 0: output_length = (output_length - j)/mx_stride + 1
                
        return tf.math.ceil(output_length)

    elif padding == 'valid':

        output_length = input_length
        for i, j in zip(kernel_list, pool_sizes):
            output_length = (output_length - i)/cnn_stride + 1
            if j != 0: output_length = (output_length - j)/mx_stride + 1
        
        return tf.math.floor(output_length)

def block(filters, inp):
    inp = inp    
    layer_1 = BatchNormalization()(inp)
    act_1 = Activation('relu')(layer_1)
    conv_1 = Conv2D(filters, (3,3), padding = 'same')(act_1)
    layer_2 = BatchNormalization()(conv_1)
    act_2 = Activation('relu')(layer_2)
    conv_2 = Conv2D(filters, (3,3), padding = 'same')(act_2)
    return(conv_2)

def resnet( input_dim, output_dim=224, units=250,  number_of_layers=2, activation='tanh', dropout_rate=0.5):

    filters = [16, 32, 64]   
    kernels = [3, 3, 3] 
    pool_sizes = [0, 0, 2]  
    cnn_stride = [1, 1, 1]
    mx_stride = 2


    input_data = Input(name='the_input', shape=(None, input_dim))
    x = Reshape((-1, input_dim, 1), dtype="float32")(input_data)
    
    x = Conv2D(filters[0], (3,3), padding = 'same')(x)
    y = MaxPooling2D((1,2), strides=(1, 2), padding = 'same')(x)
    
    x = Add()([block(filters[0], y),y])  
    y = Add()([block(filters[0], x),x])
    x = Add()([block(filters[0], y),y])

    x = Conv2D(filters[1], (3,3), strides = (1,2), padding = 'same',  activation = 'relu')(x)
    
    y = Add()([block(filters[1], x),x])
    x = Add()([block(filters[1], y),y])
    y = Add()([block(filters[1], x),x])
    
    y = Conv2D(filters[2], (3,3), strides = (1,2), padding = 'same',  activation = 'relu')(y)
    
    x = Add()([block(filters[2], y),y])  
    y = Add()([block(filters[2], x),x])
    x = Add()([block(filters[2], y),y])

    x = MaxPooling2D((2,2), strides=2, padding = 'same')(x)
    # x = AveragePooling2D((2, 2), strides=2, padding='same')(x)
    x = Reshape((-1, x.shape[-1] * x.shape[-2] ))(x)

    layer = GRU(512, activation=activation,  return_sequences=True, implementation=2, name='rnn_1', dropout=dropout_rate)(x)
    layer = BatchNormalization(name='bt_rnn_1')(layer)

    for i in range(number_of_layers - 2):
        layer = GRU(units, activation=activation, return_sequences=True, implementation=2, name='rnn_{}'.format(i+2), dropout=dropout_rate)(layer)
        layer = BatchNormalization(name='bt_rnn_{}'.format(i+2))(layer)

    layer = GRU(512, activation=activation, return_sequences=True, implementation=2, name='final_layer_of_rnn')(layer)
    layer = BatchNormalization(name='bt_rnn_final')(layer)


    time_dense = TimeDistributed(Dense(output_dim))(layer)

    y_pred = Activation('softmax', name='softmax')(time_dense)

    model = Model( inputs=input_data, outputs=y_pred, name="custom_model" )

    output_length_calculater = lambda x: cnn_output_length(x, kernels, pool_sizes, cnn_stride, mx_stride)
    
    return model, output_length_calculater



"""# Inference
<br>
<br>
<br>
"""

class Predict():
    def __init__(self):
        self.tokenizer = self.get_tokenizer()
        self.model = self.get_model()

    def get_model(self):
        sr = 8000
        fft_size = 256
        hop_size = 128
        n_mels = 128
        melspecModel = preprocessin_model(fft_size, hop_size, n_mels, sr)
        resnet_, calc = resnet(n_mels, 224, 1024, 4, activation='relu')
        model = build_model(melspecModel, 224, resnet_, False, calc)
        model_name = "resnet_V1"
        PATH_Model = "/content/gdrive/My Drive/Models/"
        model.load_weights(PATH_Model + model_name + '.h5')

        return model

    def get_tokenizer(self):
        with open('/content/gdrive/MyDrive/Pickles/char_tokenizer_am.pickle', 'rb') as handle:
            tokenizer = pickle.load(handle)

        return tokenizer

    def predict(self, audio_file):
        sr = 8000
        wav, rate = librosa.load(audio_file, sr=None)
        y_ = librosa.resample(wav, rate, sr)
        y = clean_signal(y_, True, 24, 30)
        y = y.reshape(1, -1)
        
        y_pred = self.model.predict(y)

        input_shape = tf.keras.backend.shape(y_pred)
        input_length = tf.ones(shape=input_shape[0]) * tf.keras.backend.cast(input_shape[1], 'float32')
        prediction = tf.keras.backend.ctc_decode(y_pred, input_length, greedy=False)[0][0]

        pred = K.eval(prediction).flatten().tolist()
        pred = list(filter(lambda a: a != -1, pred))
                        
        return ''.join(self.tokenizer.tokens_to_string(pred))
