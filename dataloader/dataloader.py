import sys
import os
import pickle
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import matplotlib.image as mpimg

# Loads data from parquet files
# This is a very slow method
# Recommended using dataloader_from_pickles.py

parent = os.path.abspath('..')
parquets_dir = os.path.join(parent, 'dataloader/parquets/')

IMG_W = 64
IMG_H = 64

class DataLoader:

    def load_data():
        xy_sets = []
        npartitions = 5

        for p in range(npartitions):
            df = pd.read_parquet(os.path.join(parquets_dir, f'chbcr-db-{p}.parquet'))
            nrows = df.shape[0]
            for r in range(nrows):
                x = df.iloc[r].values[0].reshape(IMG_W, IMG_H)
                y = df.iloc[r].values[1]
                xy_sets.append([x, y])

            del df
        
        return xy_sets

    def load_data_columnar():
        x_set = []
        y_set = []

        npartitions = 5
        for p in range(npartitions):
            df = pd.read_parquet(os.path.join(parquets_dir, f'chbcr-db-{p}.parquet'))
            nrows = df.shape[0]
            for r in range(nrows):
                x = df.iloc[r].values[0].reshape(IMG_W, IMG_H)
                y = df.iloc[r].values[1]
                x_set.append(x)
                y_set.append(y)

            del df
        
        return [x_set, y_set]

                            
# Test
if __name__ == "__main__":
    s = DataLoader.load_data_columnar()
    img = plt.imshow(s[0][0])
    del img