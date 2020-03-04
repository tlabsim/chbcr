import numpy as np
import tensorflow as tf
from tensorflow.keras.layers import Activation, Input, Add, Dense, Concatenate, Conv2D, MaxPooling2D, GlobalMaxPooling2D
from tensorflow.keras.layers import BatchNormalization, Flatten, Dropout
from tensorflow.keras.initializers import glorot_uniform
from tensorflow.keras.models import Model, Sequential
from tensorflow.keras import optimizers
from tensorflow.keras  import layers
import warnings
warnings.filterwarnings("ignore")

x = np.array([1,2,3])


def one_hot_encoder(data):
    array = np.zeros((data.shape[0], data.max() + 1))
    
    for i in range(data.shape[0]):
        array[i,data[i]] = 1
        
    return array

a = one_hot_encoder(x)

print (a)