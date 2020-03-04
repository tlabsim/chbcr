# Provides method for loading chbcr datset
# The DataLOader class loads data from pickle files which
# contains processed images stored in nparray (64*64) of type uint8
# There are 2100 pickle files for each type of grapheme

import sys, os
import pickle
import numpy as np
import random as rng
import matplotlib.pyplot as plt
import matplotlib.image as mpimg

parent = os.path.abspath('..')
x_pickles_dir = 'dataloader/pickles/graphemes'
y_pickle = "dataloader/pickles/grapheme_map/grapheme_map.pickle"
x_pickles_dir = os.path.join(parent, x_pickles_dir)
y_pickle = os.path.join(parent, y_pickle)

class DataLoader:
    """
    Loads data in a rowise fashion where each row contains an i/o set
    """
    def load_data(train_set_percentage = 0.8, shuffle = True, seed = 1):        
        if train_set_percentage > 1 or train_set_percentage < 0.2 :
            raise("Train set percentage outside of range (0.2, 1.0)")

        train_set = []     
        test_set = []

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

                        if shuffle:
                            rng.shuffle(xs)

                        nx = len(xs)
                        ntrain = int(nx * train_set_percentage)

                        train_xs = xs[: ntrain]
                        test_xs = xs[ntrain: ]

                        for x in train_xs:
                            train_set.append([x, y])

                        for x in test_xs:
                            test_set.append([x, y])

        return [train_set, test_set]

    """
    Loads data in a columnar fashion where first column contains input sets 
    and second column contains corresponding output sets
    """
    def load_data_columnar(train_set_percentage = 0.8, shuffle = True, seed = 1):        
        if train_set_percentage > 1 or train_set_percentage < 0.2 :
            raise("Train set percentage outside of range (0.2, 1.0)")
        
        train_x_set = []
        train_y_set = []        
        test_x_set = []
        test_y_set = []

        # Seed
        rng.seed(seed)
        
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
                        
                        if shuffle:
                            rng.shuffle(xs)

                        nx = len(xs)
                        ntrain = int(nx * train_set_percentage)

                        train_xs = xs[: ntrain]
                        test_xs = xs[ntrain: ]

                        for x in train_xs:
                            train_x_set.append(x)
                            train_y_set.append(y)

                        for x in test_xs:
                            test_x_set.append(x)
                            test_y_set.append(y)                            
                            

        return [[train_x_set, train_y_set], [test_x_set, test_y_set]]


# Test
if __name__ == "__main__":
    data = DataLoader.load_data_columnar()
    img = plt.imshow(data[0][0][0])
    del img

    print(data[0][1][0])