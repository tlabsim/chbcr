import sys
import os
import pickle
import pandas as pd
import numpy as np
from numba import jit
import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import timeit
import math

p = 0

for i in range(1, 10000000):
    p += 1 / (i*i*i)

print(p)
print((math.pi * math.pi * math.pi)/p)