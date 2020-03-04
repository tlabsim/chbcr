import sys
import os
import pickle
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.image as mpimg

xs = []
for i in range(10):
    x = np.random.rand(2,2).astype(np.float)
    xs.append(x)

xs = np.asarray(xs).reshape(-1, 10, 10, 1)
print(xs)




