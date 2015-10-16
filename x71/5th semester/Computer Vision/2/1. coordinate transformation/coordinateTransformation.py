__author__ = 'Artem Gorokhov'

import cv2
import numpy as np
import math


def imgChange(img, topLeft1, bottomRight1, topLeft2, bottomRight2):
    rows, cols, ch = img.shape

    def difference(point1, point2):
        return point2[0] - point1[0], point2[1] - point1[1]

    def distance(point1, point2):
        diff = difference(point1, point2)
        return math.sqrt(diff[0] * diff[0] * 1.0 + diff[1] * diff[1] * 1.0)

    dist1 = distance(topLeft1, bottomRight1)
    dist2 = distance(topLeft2, bottomRight2)

    M = np.float32([[(dist2 / dist1), 0, (difference(topLeft1, topLeft2)[0])],
                    [0, (dist2 / dist1), (difference(topLeft1, topLeft2)[1])]])

    img = cv2.warpAffine(img, M, (cols, rows))
    return img


img = cv2.imread('1.jpg')

cv2.imshow('base', img)
img = imgChange(img, (0, 0), (10, 10), (20, 0), (40, 20))
cv2.imshow('new', img)
cv2.waitKey(0)
cv2.destroyAllWindows()
