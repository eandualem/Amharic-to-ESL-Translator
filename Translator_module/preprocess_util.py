#!/usr/bin/env python
# coding: utf-8

# In[1]:


import re
import pickle
import os
from HornMorph.build.lib import l3


# In[ ]:


def clean_data(sent, save=False, savePath=os.path.join("./cleaned.txt")):
    clean_sen=re.sub(r'^https?:\/\/.*[\r\n]*', ' ', sent)
    clean_sen = re.sub('[\_\£\!\@\#\$\%\^\«\»\&\*\(\)\…\[\]\{\}\;\“\”\›\’\‘\"\'\:\,\.\‹\/\<\>\?\\\\|\`\´\~\-\=\+]', '', clean_sen)
    clean_sen = re.sub('[\፡\።\፤\;\፦\፥\፧\፨\፠\፣]', ' ' ,clean_sen)
    #todo clean eng alpha and nums
    if save:
        file = open(savePath, "w")
        file.write(clean_sen)
        file.close()
    return clean_sen


# In[ ]:


def save_dump(save_file, dump_file):
    with open(save_file, 'wb') as out_file:
        pickle.dump(dump_file, out_file)

def load_file(file_path):
    with open(file_path, 'rb') as in_file:
        return pickle.load(in_file)


# In[ ]:


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

