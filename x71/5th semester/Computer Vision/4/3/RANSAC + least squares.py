import math
import random
import cv2
import numpy as np
from scipy.optimize import leastsq

img = cv2.imread('chessboard.jpg', 0)
side_len = 333

# https://en.wikipedia.org/wiki/RANSAC#Parameters
p = 0.99
w = 0.5
n = 4
number_of_iterations = math.log(1 - p) / math.log(1 - math.pow(w, n))
number_of_iterations = int(number_of_iterations)

img_points = np.float32(
        [[202, 160], [509, 233], [426, 540], [1089, 833], [882, 583], [678, 339], [789, 170], [992, 412]])
board_coord = np.float32([[1, 0], [3, 1], [2, 3], [6, 6], [5, 4], [4, 2], [5, 1], [6, 3]])
board_points = side_len * board_coord

for i in range(8):
    img_points = np.vstack((img_points, np.float32([random.randint(1, img.shape[1]), random.randint(1, img.shape[0])])))
    board_points = np.vstack(
            (board_points, np.float32([side_len * random.randint(0, 6), side_len * random.randint(0, 6)])))

def norm_h(x):
    temp = x[2]
    x = np.delete(x, 2, 0)
    if temp == 0:
        temp = 0.0001
    x[0] = x[0] / temp
    x[1] = x[1] / temp

    return x


def func(x):
    fun, t = np.split(x, 2)
    t = np.transpose(t)
    rotation, _ = cv2.Rodrigues(fun)

    temp = map(lambda x: np.dot(number_of_iterations, np.dot(rotation, np.insert(x, 2, 0, axis=0)) + t),
               board_points[max])
    temp = map(lambda x: norm_h(x), temp)

    return (temp - img_points[max]).flatten()

def result():
    number_of_iterations = np.float32([[6741, 0, img.shape[1] / 2], [0, 6741, img.shape[0] / 2], [0, 0, 1]])
    number_of_iterations_inv = np.linalg.inv(number_of_iterations)
    Hn = np.dot(number_of_iterations_inv, h)
    Hn /= np.linalg.norm(Hn[:, 0])

    r1 = Hn[:, 0]
    r2 = Hn[:, 1]
    t0 = Hn[:, 2]
    r3 = np.cross(r1, r2)
    r = np.column_stack((r1, r2, r3))

    f, _ = cv2.Rodrigues(r)
    f = np.transpose(f)[0]
    f = np.concatenate((f, t0), 0)
    f1 = leastsq(func, f)[0][0:3]

    return cv2.Rodrigues(f1)[0]

max = []
sample = []
hom = []
e = 20

for _ in range(number_of_iterations):
    c = random.sample(range(0, 16), 4)

    h, _ = cv2.findHomography(board_points[c], img_points[c])
    if h is not None:
        points_h = map(lambda x: norm_h(np.dot(h, np.insert(x, 2, 1, axis=0))), board_points)
        diff = img_points - points_h

        check_points = filter(lambda (x, y): (x * x + y * y) < e * e, diff)

        if len(check_points) > len(sample):
            sample = np.copy(check_points)
            max = np.copy(c)
            hom = np.copy(h)

print('Max: {}.\nSample: {}.'.format(max, sample))
print('Result: {}.'.format(result()))
