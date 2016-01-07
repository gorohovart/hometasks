import numpy as np
import numpy.linalg as linalg
import math
import numpy.random as rnd

def normalize(v):
    x, y, z = v[0], v[1], v[2]
    norm = math.sqrt(x * x + y * y + z * z)
    return v / norm

vectors = [np.array([1, 0.5, 1]), np.array([-1, 1, 0.5])]

vectors = [normalize(vector) for vector in vectors]

def randomPoint(vectors):
    return rnd.uniform() * vectors[0] + rnd.uniform() * vectors[1]


def add_noise(points):
    return points + rnd.normal(0, 0.1, [len(points), 3])


points = np.array([randomPoint(vectors) for i in range(100)])

points = add_noise(points)


def calc_plane(points):
    x = points[:, 0].copy()
    y = points[:, 1].copy()

    A = np.column_stack((x, y, (np.ones(len(points)))))
    AT = A.copy().T

    z = points[:, 2].copy().reshape(len(points), 1)

    res = linalg.inv(AT.dot(A)).dot(AT).dot(z)
    a = res[0][0]
    b = res[1][0]
    c = -1

    return normalize(np.array([a, b, c]))


def calc_difference(plane):
    vector = np.cross(vectors[0], vectors[1])
    return linalg.norm(plane + normalize(vector))

file = open('output.txt', 'w')
for i in range(10, 101, 10):
    file.write("%.20f"%(calc_difference(calc_plane(points[:i]))))
    file.write('\n')
