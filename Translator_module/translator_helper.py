#!/usr/bin/env python
# coding: utf-8

# In[ ]:


import re
import pickle
import os
import preprocess_util as putil
CODES = {0: '<PAD>', 1: '<EOS>', 2: '<UNK>', 3: '<GO>' }

def clean_data(sent, save=False, savePath=os.path.join("./cleaned.txt")):
    clean_sen=re.sub(r'^https?:\/\/.*[\r\n]*', ' ', sent)
    clean_sen = re.sub('[\_\£\!\@\#\$\%\^\«\»\&\*\(\)\…\[\]\{\}\;\“\”\›\’\‘\"\'\:\,\.\‹\/\<\>\?\\\\|\`\´\~\-\=\+]', '', clean_sen)
    clean_sen = re.sub('[\፡\።\፤\;\፦\፥\፧\፨\፠\፣]', ' ' ,clean_sen)
    #todo clean eng alpha and nums
    return clean_sen


def save_dump(save_file, dump_file):
    with open(save_file, 'wb') as out_file:
        pickle.dump(dump_file, out_file)


def load_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as f:
        return f.read()
    

def create_lookup_tables(text):
    vocabs = set(text.split())
    int_to_vocab = dict(CODES)
    for i, word in enumerate(vocabs, len(CODES)):
        int_to_vocab[i] = word
    vocab_to_int = {vocab: i for i, vocab in int_to_vocab.items()}
    return vocab_to_int, int_to_vocab
    

def text_to_int(source_text, target_text, source_vocab_to_int, target_vocab_to_int):
    source_sents = source_text.split('\n')
    target_sents = [sent + ' <EOS>' for sent in target_text.split('\n')]
    source_id_text = []
    target_id_text = []
    for sent in source_sents:
        res = []
        for word in sent.split():
            #root_word = putil.get_root(word)
            root_word = word
            res.append(source_vocab_to_int[root_word])
        source_id_text.append(res)
    for sent in target_sents:
        res = []
        for word in sent.split():
            #root_word = putil.get_root(word)
            root_word = word
            res.append(target_vocab_to_int[root_word])
        target_id_text.append(res)
    
    return source_id_text, target_id_text


def preprocess_and_save(source_file_path, target_file_path,
                        src_int_to_vocab, src_vocab_to_int,
                        tgt_int_to_vocab, tgt_vocab_to_int,
                        save_path):
    source_file, target_file = load_file(source_file_path), load_file(target_file_path)
    source_clean_text, target_clean_text = putil.clean_data(source_file), putil.clean_data(target_file)
    
    #TODO LEMMATIZE
    
    #source_vocab_to_int, source_int_to_vocab = create_lookup_tables(source_clean_text)
    #target_vocab_to_int, target_int_to_vocab = create_lookup_tables(target_clean_text)

    src_int_text, tgt_int_text = text_to_int(source_clean_text, target_clean_text, src_vocab_to_int, tgt_vocab_to_int)

    dumpfile = (
                (src_int_text, tgt_int_text), 
                (src_vocab_to_int, tgt_vocab_to_int),
                (src_int_to_vocab, tgt_int_to_vocab)
               )
    
    save_dump(os.path.join(save_path), dumpfile)
    
    return (src_int_text, tgt_int_text), (src_vocab_to_int, tgt_vocab_to_int),(src_int_to_vocab,tgt_int_to_vocab)

def preprocess_and_save2(source_file_path):
    source_file, target_file = source_file_path, source_file_path
    source_clean_text, target_clean_text = clean_data(source_file), clean_data(target_file)
    
    #TODO LEMMATIZE
    
    source_vocab_to_int, source_int_to_vocab = create_lookup_tables(source_clean_text)
    target_vocab_to_int, target_int_to_vocab = create_lookup_tables(target_clean_text)

    source_int_text, target_int_text = text_to_int(source_clean_text, target_clean_text, source_vocab_to_int, target_vocab_to_int)

    dumpfile = (
                (source_int_text, target_int_text), 
                (source_vocab_to_int, target_vocab_to_int),
                (source_int_to_vocab, target_int_to_vocab)
               )
    
    save_dump(PREPROCESS_SAVE_PATH, dumpfile)
    
def load_preprocessed_data(save_file):
    with open(save_file, 'rb') as in_file:
        return pickle.load(in_file)

def load_params(save_file):
    pass
