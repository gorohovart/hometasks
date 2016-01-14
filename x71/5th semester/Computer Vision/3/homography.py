__author__ = 'Artem Gorokhov'

import cv2
import numpy as np
import math


def isRed(x):
    return x[0] < 45 and x[1] < 45 and x[2] > 200


def isNear(x, y):
    return abs(x[0] - y[0]) + abs(x[1] - y[1]) < 12


img = cv2.imread('hall405.jpg')
pts = np.float32([[550, 200, 1], [520, 250, 1], [600, 300, 1], [587, 194, 1]])
red = np.float32([0, 0, 255])

for point in pts:
    x, y, _ = point
    img[y, x] = red

src_pts = np.float32([[507, 131], [629, 78], [506, 308], [631, 307]])
dst_pts = np.float32([[0, 0], [299, 0], [0, 299], [299, 299]])

M, _ = cv2.findHomography(src_pts, dst_pts, cv2.RANSAC, 5.0)

dst = cv2.warpPerspective(img, M, (300, 300))


def findRed():
    red_pts = []
    for i in range(dst.shape[0]):
        for j in range(dst.shape[1]):
            if isRed(dst[i, j]):
                red_pts.append([i, j])
    for i in red_pts:
        for j in red_pts:
            if i != j and isNear(i, j):
                red_pts.remove(i)
    return red_pts


findRed()
max_err = 0
for point in pts:
    p = np.float32([[point[0]], [point[1]], [point[2]]])
    pointH = np.dot(M, point)
    x, y, k = pointH
    x = int(x / k)
    y = int(y / k)
    dst[y, x, 0] = 255
    dst[y, x, 1] = 0
    dst[y, x, 2] = 0


    def calcError(x, y):
        max_err = 0
        for j in y:
            if isNear(x, j):
                err = math.sqrt((x[0] - j[0]) * (x[0] - j[0]) + (x[1] - j[1]) * (x[1] - j[1]))
                if max_err < err: max_err = err
        return max_err
    err = calcError([y, x], findRed())
    if max_err < err: max_err = err
print("Max error is:")
print(max_err)

cv2.imshow('Source', img)
cv2.imshow('Result', dst)
cv2.waitKey(0)
