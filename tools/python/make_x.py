import sys
import os
import pickle
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.image as mpimg

IMG_SIZE = 64
N_CHANNELS = 1

base_dir = f"../../dataset_images/processed/letters_processed/v1/"
pickle_out_dir = f"../../dataloader/pickles/graphemes/"

if not os.path.isdir(pickle_out_dir):
    os.mkdir(pickle_out_dir)

for dirname in [base_dir + f"{i}" for i in range(1, 28)]:
    print(dirname)
    all_graphemes = {}
    for root, dirs, files in os.walk(dirname, topdown=True):
        for fname in files:            
            if fname[4] == "_":
                full_name = os.path.join(root, fname)
                # print(name)
                grapheme_id = fname[:4]
                # print(grapheme_id)
                img = mpimg.imread(full_name, format="bmp")
                img = 1 - img[:, :, 0]/255
                img = img.astype(np.uint8)

                if grapheme_id in all_graphemes:
                    all_graphemes[grapheme_id].append(img)
                else:
                    all_graphemes[grapheme_id] = [img]

                # print(img)
                # print(sys.getsizeof(img))
                # plt.imshow(img)
   
    for k, v in all_graphemes.items():
        grapheme_id = int(k)

        data_out = {'grapheme_id': grapheme_id, 'img_data': v}

        pickle_name = k + ".pickle"
        pickle_path = os.path.join(pickle_out_dir, pickle_name)
        
        if os.path.isfile(pickle_path):
            os.remove(pickle_path)

        pf = open(pickle_path, 'wb')
        pickle.dump(data_out, pf)
        pf.close()
        

    del all_graphemes

test_path = os.path.join(pickle_out_dir, '0001.pickle')
pf = open(test_path, 'rb')
dt = pickle.load(pf)
print(dt['grapheme_id'])
# print(dt['img_data'])
plt.imshow(dt['img_data'][0])
pf.close()