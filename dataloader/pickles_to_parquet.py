import sys
import os
import math
import pickle
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import matplotlib.image as mpimg

x_pickles_dir = 'pickles/graphemes'
y_pickle = "pickles/grapheme_map/grapheme_map.pickle"

x_vals = []
y_vals = []
# Load grapheme map
pf = open(y_pickle, 'rb')
grapheme_maps = pickle.load(pf)
pf.close()

def get_y(grapheme_id):
            if grapheme_id in grapheme_maps:
                mp = grapheme_maps[grapheme_id]
                return [mp["digit_index"], mp["vowel_index"], mp["consonant_index"], mp["consonant_join_index"], mp["consonant_allograph_index"], mp["consonant_allograph2_index"], mp["consonant_diacritic_index"], mp["vowel_allograph_index"]]
    
def load_x_data(pickle_file):
    pf = open(pickle_file, 'rb')
    dt = pickle.load(pf)
    ret = (dt["grapheme_id"], dt["img_data"])
    pf.close()
    return ret

for _, _, files in os.walk(x_pickles_dir, topdown=True):
        for fname in files:
            if fname[-6:] == "pickle":
                file_Path = os.path.join(x_pickles_dir, fname)
                (g_id, xs) = load_x_data(file_Path)
                y = get_y(g_id)
                for x in xs:
                    x_vals.append(x.reshape(1, -1)[0])
                    y_vals.append(y)
                
                

# Write to files =================
do_partition = True
compression = None
if do_partition:
    npartitions = 5
    nrows = len(x_vals)
    rows_per_partition = int(math.ceil(nrows/npartitions))

    start = 0
    for p in range(npartitions):
        end = start + rows_per_partition
        if p == npartitions - 1:
            end = nrows
        df = pd.DataFrame({'x' : x_vals[start : end], 'y': y_vals[start : end]})
        df.to_parquet(f'parquets/chbcr-db-{p}.parquet', compression=compression)
        start = end
else:
    # Writing to a single file fails
    print(len(x_vals))
    df = pd.DataFrame({'x' : x_vals, 'y': y_vals})
    df.to_parquet(f'parquets/chbcr-db.parquet', compression=compression)
