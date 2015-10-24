__author__ = 'Artem Gorokhov'

import cv2
import numpy as np
import math
from random import randint

'''
def createImg(x, y):
    img = np.ndarray(shape=(x, y, 3), dtype=np.uint8)

    return img
'''

img = cv2.imread('hall405.jpg')
pts = np.float32([[550, 200, 1], [520, 250, 1], [600, 300, 1], [587, 194, 1]])

for point in pts:
    x, y, _ = point
    img[y, x, 0] = 0
    img[y, x, 1] = 0
    img[y, x, 2] = 255

src_pts = np.float32([[507, 131], [629, 78], [506, 308], [631, 307]])
dst_pts = np.float32([[0, 0], [299, 0], [0, 299], [299, 299]])

M, _ = cv2.findHomography(src_pts, dst_pts, cv2.RANSAC, 5.0)
for i in M:
    for j in i:print(float(j))

dst = cv2.warpPerspective(img, M, (300, 300))

for point in pts:
    pointH = np.dot(point, M)
    x, y, z = pointH

    for i in pointH: print(int(i))
    x = int(x/z)
    y = int(y/z)
    print(x, y)
    dst[y, x, 0] = 0
    dst[y, x, 1] = 0
    dst[y, x, 2] = 255

cv2.imshow('src', img)
cv2.imshow('dst', dst)
cv2.waitKey(0)
