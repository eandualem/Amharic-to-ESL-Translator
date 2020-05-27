#!/usr/bin/env python
# coding: utf-8

# In[1]:


import preprocess_util as putil
from collections import Counter
import re

CODES = {0: '<PAD>', 1: '<EOS>', 2: '<UNK>', 3: '<GO>' }

# In[2]:


def clean(word):
    clean_word=re.sub(r'^https?:\/\/.*[\r\n]*', '', word)
    clean_word = re.sub('[\!\@\#\$\%\^\«\»\&\*\(\)\…\[\]\{\}\;\“\”\›\’\‘\"\'\:\,\.\‹\/\<\>\?\\\\|\`\´\~\-\=\+]', '', clean_word)
    clean_word = re.sub('[\፡\።\፤\;\፦\፥\፧\፨\፠\፣]', ' ' ,clean_word)
    return clean_word


# In[3]:


def tokenize(text, trimmed_limit=5):
    words = text.split()
    word_counts = Counter(words)
    #lemmatized_trimmed_words = [putil.get_root(word) for word in words if word_counts[word] > trimmed_limit]
    trimmed_words = [word for word in words]
    return trimmed_words, trimmed_words


# In[4]:

NEG_IND = "አይደለም።"
BEST = 1
LANG="am"
def get_root(word):
    analysis = l3.anal(LANG, word, raw=False, nbest=BEST, gram=True)
    analysis = analysis.split()
    if "citation:" in analysis:
        root_idx = analysis.index("citation:") + 1
        root = analysis[root_idx]
    elif "stem:" in analysis:
        root_idx = analysis.index("stem:") + 1
        root = analysis[root_idx]
    else:
        return word
    if "negative" in analysis:
        root = root + " " + NEG_IND
    return root


# In[5]:

def Lemmatize_text(words):
    res = []
    i = 0
    for word in words:
        res.append(get_root(word))
        print("Total: ", i)
        i+=1
    return res
        
def create_lookup_tables(words):
    word_counts = Counter(words)
    sorted_vocab = sorted(word_counts, key=word_counts.get, reverse=True)
    int_to_vocab = {ii: word for ii, word in enumerate(sorted_vocab, len(CODES))}
    vocab_to_int = {word: ii for ii, word in int_to_vocab.items()}

    return vocab_to_int, int_to_vocab






