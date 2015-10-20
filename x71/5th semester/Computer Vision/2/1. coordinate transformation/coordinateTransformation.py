__author__ = 'Artem Gorokhov'

import cv2
import numpy as np


def imgChangeUsingWarpAffine(img, topLeft1, bottomRight1, topLeft2, bottomRight2):
    rows, cols, ch = img.shape

    pts1 = np.float32([[topLeft1[0], topLeft1[1]], [bottomRight1[0], bottomRight1[1]], [bottomRight1[0], topLeft1[1]]])
    pts2 = np.float32([[topLeft2[0], topLeft2[1]], [bottomRight2[0], bottomRight2[1]], [bottomRight2[0], topLeft2[1]]])

    M = cv2.getAffineTransform(pts1, pts2)
    img = cv2.warpAffine(img, M, (cols, rows))
    return img


def imgChangeUsingRemap(img, topLeft1, bottomRight1, topLeft2, bottomRight2):
    def difference(point1, point2):
        return point2[0] - point1[0], point2[1] - point1[1]

    diff1 = difference(topLeft1, bottomRight1)
    diff2 = difference(topLeft2, bottomRight2)

    map_x = np.zeros(img.shape[:2], np.float32)
    map_y = np.zeros(img.shape[:2], np.float32)

    for i in range(img.shape[0]):
        for j in range(img.shape[1]):
            map_x[i, j] = j / (diff2[1] / diff1[1])
            map_y[i, j] = i / (diff2[0] / diff1[0])

    img = cv2.remap(img, map_x, map_y, cv2.INTER_CUBIC)

    #cv2.imshow('Scaled', img)

    diff3 = difference(topLeft1, topLeft2)

    for i in range(img.shape[0]):
        for j in range(img.shape[1]):
            map_x[i, j] = j - diff3[0]
            map_y[i, j] = i - diff3[1]

    img = cv2.remap(img, map_x, map_y, cv2.INTER_CUBIC)

    return img


img = cv2.imread('1.jpg')


cv2.imshow('Base', img)
img = cv2.copyMakeBorder(img, 0, 500, 0, 800, cv2.BORDER_CONSTANT, value=[0, 0, 0])
img1 = imgChangeUsingWarpAffine(img, (0, 0), (10, 10), (20, 0), (40, 20))
img = imgChangeUsingRemap(img, (0, 0), (10, 10), (20, 0), (40, 20))
cv2.imshow('Remaped', img)
cv2.imshow('WarpAffined', img1)
cv2.waitKey(0)
cv2.destroyAllWindows()
