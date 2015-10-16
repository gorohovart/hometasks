__author__ = 'Artem Gorokhov'
import math

def projection(ax, ay, az, cx, angle):
    f = (cx * 1.0) / math.tan(math.radians(angle))
    return f * ((ax * 1.0) / az) + cx, f * ((ay * 1.0) / az) + cx

print('The result is: ')
print(projection(-1, 1, 6, 300, 30))
