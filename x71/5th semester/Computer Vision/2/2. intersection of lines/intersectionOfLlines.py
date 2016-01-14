__author__ = 'Artem Gorokhov'

import cv2
import numpy as np
from random import randint

imgX = 800
imgY = 300


def compare(x, y):
    return x[0] == y[0] and x[1] == y[1] and x[2] == y[2]


def createWhiteImg(x, y):
    img = np.ndarray(shape=(x, y, 3), dtype=np.uint8)
    img.fill(255)

    return img


def findBlackPoints(img):
    points = []
    for x in range(img.shape[0]):
        for y in range(img.shape[1]):
            if compare(img[x, y], (0, 0, 0)):
                points.append((x, y, 1))
    return points


def drawRandomPoints(img, numberOfPoints):
    for _ in range(numberOfPoints):
        x = randint(0, img.shape[0] - 1)
        y = randint(0, img.shape[1] - 1)

        # check for equality with other point from already gotten
        if compare(img[x, y], (0, 0, 0)):
            drawRandomPoints(img, 1)
        else:
            img[x, y] = [0, 0, 0]


def drawLine(img, point1, point2):
    line = np.cross(point1, point2)
    a, b, c = line
    x1, x2 = 0, imgX - 1
    y1, y2 = -(a * x1 + c) / b, -(a * x2 + c) / b
    cv2.line(img, (y1, x1), (y2, x2), (0, 0, 0))
    return line


def drawLines(img, points):
    lines = []
    for i, point1 in enumerate(points):
        for j, point2 in enumerate(points[i + 1:], start=i):
            lines.append(drawLine(img, point1, point2))
    return lines


def showIntersectionOfLines(img, lines):
    for i, line1 in enumerate(lines):
        for line2 in lines[i + 1:]:
            x, y, k = np.cross(line1, line2)
            x, y = x / k, y / k
            if 0 <= x < imgX and 0 <= y < imgY:
                cv2.circle(img, (y, x), 2, (0, 0, 255), -1)


img = createWhiteImg(imgX, imgY)
drawRandomPoints(img, 4)
points = findBlackPoints(img)
lines = drawLines(img, points)
showIntersectionOfLines(img, lines)

cv2.imshow('Lines', img)
cv2.waitKey(0)
cv2.destroyAllWindows()
