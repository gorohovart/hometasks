__author__ = 'Artem Gorokhov'

import cv2
import numpy as np
import math


def createWhiteImg(x, y):
    img = np.ndarray(shape=(x, y, 3), dtype=np.uint8)
    img.fill(255)

    return img


def perspectiveProjection(point, cx, angle):
    ax, ay, az = point
    f = (cx * 1.0) / math.tan(math.radians(angle))
    return int(f * ((ax * 1.0) / az) + cx), int(f * ((ay * 1.0) / az) + cx)


def orthographicProjection(point):
    x, y, z = point

    return int(x * imgX / 4 + imgX / 2), int(y * imgY / 4 + imgY / 2)


pointsOfSquare = [(math.sqrt(2) * 3 / 2, 1, 7),
                  (-1 * math.sqrt(2) * 3 / 2, 1, 7),
                  (math.sqrt(2) * 3 / 2, -2, 10),
                  (-1 * math.sqrt(2) * 3 / 2, -2, 10)]

imgX = 600
imgY = imgX

img = createWhiteImg(imgX, imgY)
projections = []

for point in pointsOfSquare:
    projections.append(perspectiveProjection(point, imgX / 2, 45))

cv2.line(img, projections[0], projections[1], [0, 0, 0])
cv2.line(img, projections[1], projections[3], [0, 0, 0])
cv2.line(img, projections[3], projections[2], [0, 0, 0])
cv2.line(img, projections[2], projections[0], [0, 0, 0])

cv2.imshow('Perspective', img)

projections = []
img.fill(255)
for point in pointsOfSquare:
    projections.append(orthographicProjection(point))

cv2.line(img, projections[0], projections[1], [0, 0, 0])
cv2.line(img, projections[1], projections[3], [0, 0, 0])
cv2.line(img, projections[3], projections[2], [0, 0, 0])
cv2.line(img, projections[2], projections[0], [0, 0, 0])

cv2.imshow('Orthographic', img)

cv2.waitKey(0)
cv2.destroyAllWindows()
