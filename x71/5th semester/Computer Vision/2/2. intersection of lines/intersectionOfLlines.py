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


def drawRandomPoints(img, numberOfPoints):
    points = []

    for i in range(numberOfPoints):
        x = randint(0, img.shape[0])
        y = randint(0, img.shape[1])

        if compare(img[x, y], [0, 0, 0]):
            points.append(drawRandomPoints(img, 1)[0])
        else:
            img[x, y] = [0, 0, 0]
            points.append((y, x, 1))
    return points


def drawLine(img, point1, point2):
    line = np.cross(point1, point2)
    a, b, c = line
    x1, x2 = -1, imgX
    y1, y2 = -(a * x1 + c) / b, -(a * x2 + c) / b
    cv2.line(img, (x1, y1), (x2, y2), (0, 0, 0))
    return line


def drawLines(img, points):
    lines = []

    for i in range(len(points)):
        for j in range(i + 1, len(points)):
            lines.append(drawLine(img, points[i], points[j]))
    return lines


def showIntersectionOfLines(img, lines):
    for i in range(len(lines)):
        for j in range(i + 1, len(lines)):
            y, x, k = np.cross(lines[i - 1], lines[j - 1])
            x, y = x / k, y / k
            if 0 <= x and x < imgX and 0 <= y and y < imgY:
                cv2.circle(img, (y, x), 2, (0, 0, 255), -1)


img = createWhiteImg(imgX, imgY)
points = drawRandomPoints(img, 4)
lines = drawLines(img, points)
showIntersectionOfLines(img, lines)

cv2.imshow('Lines', img)
cv2.waitKey(0)
cv2.destroyAllWindows()