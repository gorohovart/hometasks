__author__ = 'Artem Gorokhov'

import cv2
import numpy as np
import math


def createWhiteImg(x, y):
    img = np.ndarray(shape=(x, y, 3), dtype=np.uint8)
    img.fill(255)

    return img


def perspectiveProjection(point, cx, angle):
    ax, ay, az, _ = point
    f = (cx * 1.0) / math.tan(math.radians(angle))
    return int(f * ((ax * 1.0) / az) + cx), int(f * ((ay * 1.0) / az) + cx)


def orthographicProjection(points):
    mat = np.asmatrix(points)
    mat2 = np.asmatrix(np.array([[int(imgX/4), 0, 0, 0],
                                 [0, int(imgY/4), 0, 0],
                                 [0, 0, 0, 0],
                                 [int(imgX/2), int(imgY/2), 0, 1]]))
    return mat * mat2

tmp1 = math.sqrt((math.sqrt(1.5 ** 2 + 2.5 ** 2) * 2) ** 2 - 8)
sq_side = tmp1 - math.sqrt(2)

tmp = math.sqrt(((tmp1 - math.sqrt(8))**2)/2)

pointsOfSquare = np.array([[sq_side/2, 1.5, 2.5, 1],
                           [-1 * sq_side/2, 1.5, 2.5, 1],
                           [sq_side/2, -1 * tmp, 4 + tmp, 1],
                           [-1 * sq_side/2, -1 * tmp, 4 + tmp, 1]])
imgX = 700
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
# print(pointsOfSquare)
projectionMat = np.asarray(orthographicProjection(pointsOfSquare))
# print(projectionMat)

for point in projectionMat:
    a, b = int(point[0]), int(point[1])
    projections.append((a, b))

print('Orthographic Projection points: {}.'.format(projections))
cv2.line(img, projections[0], projections[1], [0, 0, 0])
cv2.line(img, projections[1], projections[3], [0, 0, 0])
cv2.line(img, projections[3], projections[2], [0, 0, 0])
cv2.line(img, projections[2], projections[0], [0, 0, 0])

cv2.imshow('Orthographic', img)
cv2.waitKey(0)
cv2.destroyAllWindows()
