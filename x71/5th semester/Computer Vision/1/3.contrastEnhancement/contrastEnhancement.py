__author__ = 'Artem Gorokhov'
import cv2


def enhaceContrast(img):
    hLow = 0
    hHi = 255
    flag = True
    hist = cv2.calcHist([img], [0], None, [256], [0, 256])

    # ignore pixels with value founded <= 10 times
    def toZero(x):
        for i in range(256):
            if x[i] <= 10:
                x[i] = 0
        return x

    hist = toZero(hist)

    for a in hist:
        if a == 0.0 and flag:
            hLow += 1
        elif a == 0.0:
            hHi -= 1
        else:
            flag = False

    def map(x):
        for i in range(img.shape[0]):
            for j in range(img.shape[1]):
                if x[i, j] < hLow: x[i, j] = hLow
                if x[i, j] > hHi: x[i, j] = hHi
                a = ((x[i, j] - hLow) * 1.0) / (hHi - hLow)
                x[i, j] = 255 * a
        return x

    img = map(img)


img = cv2.imread('low-contrast.png', 0)

cv2.imshow('Old image', img)
enhaceContrast(img)
cv2.imshow('New image', img)

cv2.waitKey(0)
cv2.destroyAllWindows()
