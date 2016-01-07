__author__ = 'Artem Gorokhov'
import cv2
import numpy as np
from scipy.optimize import leastsq

img = cv2.imread('chessboard.jpg', 0)
file = open('output.txt', 'w')

side_len = 333
focus = 6741

img_points = np.float32(
        [[202, 160], [509, 233], [426, 540], [1089, 833], [882, 583], [678, 339], [789, 170], [992, 412]])
board_coord = np.float32([[1, 0], [3, 1], [2, 3], [6, 6], [5, 4], [4, 2], [5, 1], [6, 3]])
board_points = side_len * board_coord

homography, _ = cv2.findHomography(board_points[0:4], img_points[0:4])

calibration_matrix = np.float32([[focus, 0, img.shape[1] / 2], [0, focus, img.shape[0] / 2], [0, 0, 1]])

calibration_matrix_inversed = np.linalg.inv(calibration_matrix)

Hn = np.dot(calibration_matrix_inversed, homography)

Hn /= np.linalg.norm(Hn[:, 0])

r1 = Hn[:, 0]
r2 = Hn[:, 1]
t0 = Hn[:, 2]
r3 = np.cross(r1, r2)
r = np.column_stack((r1, r2, r3))

def norm_h(x):
    buff = x[2]
    x = np.delete(x, 2, 0)
    x[0] = x[0] / buff
    x[1] = x[1] / buff
    return x

def func(x):
    fun, t = np.split(x, 2)
    t = np.transpose(t)
    rotation, _ = cv2.Rodrigues(fun)
    res = map(lambda x: np.dot(calibration_matrix, np.dot(rotation, np.insert(x, 2, np.float32(0.0), axis=0)) + t),
               board_points[0:i])
    res = map(lambda x: norm_h(x), res)

    return (res - img_points[0:i]).flatten()

rotation_param, _ = cv2.Rodrigues(r)
rotation_param = np.transpose(rotation_param)[0]
rotation_param = np.concatenate((rotation_param, t0), axis=0)

for i in range(4, 9):
    rotation_param = leastsq(func, rotation_param)[0]
    t = rotation_param[3:6]
    r, _ = cv2.Rodrigues(rotation_param[0:3])

    sum = 0.0
    for j in range(8):
        buff = np.dot(calibration_matrix, np.dot(r, np.insert(board_points[j], 2, np.float32(0), axis=0)) + t)
        buff = norm_h(buff)
        sum += np.linalg.norm(buff - img_points[j])

    sum /= 8
    file.write(str(sum) + '\n')

file.close()
