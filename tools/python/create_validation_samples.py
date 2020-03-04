import sys, os
import numpy as np
import pickle
import matplotlib.image as mpimg

sample_directory = f'D:/chbcr/dataset_images/validation_samples_processed'
output_file = "validation_samples_1.pickle"

samples = []

for root, dirs, files in os.walk(sample_directory, topdown=True):
    for fname in files:            
        if fname[-3:] in ["bmp"]:
            full_name = os.path.join(root, fname)
            img = mpimg.imread(full_name, format="bmp")
            img = 1 - img[:, :, 0]/255
            img = img.astype(np.uint8)

            samples.append(img)

print(samples)

pf = open(output_file, 'wb')
pickle.dump(samples, pf)
pf.close()
