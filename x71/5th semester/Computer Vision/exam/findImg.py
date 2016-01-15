import cv2
import buildDictionary
import numpy as np
import cPickle as pickle
import shutil
import os


def save_object(obj, filename):
    with open(filename, 'wb') as output:
        pickle.dump(obj, output, pickle.HIGHEST_PROTOCOL)

def removeStopList(clusters, centers):
    length_list = []
    for i, cluster in enumerate(clusters):
        if len(cluster) > 40:
            clusters[i] = []

    # text_file = open('result_images.txt', 'w')
    # for i in length_list:
    #     text_file.write(str(i) + '\n')
    # text_file.close()

NUMBER_OF_IMAGES = 2843
IS_REREAD_NEED = False
IS_REBUILD_NEED = False
NUMBER_OF_CLUSTERS = 30000
clusters, centroids = buildDictionary.buildDictionary(IS_REBUILD_NEED, IS_REREAD_NEED, NUMBER_OF_CLUSTERS,
                                                      NUMBER_OF_IMAGES)

removeStopList(clusters, centroids)


sift = cv2.SIFT()
filename = 'base.jpg'
base_image = cv2.imread(filename)
gray = cv2.cvtColor(base_image, cv2.COLOR_BGR2GRAY)
key_points, descriptors = sift.detectAndCompute(gray, None)

# FLANN parameters
FLANN_INDEX_KDTREE = 0
index_params = dict(algorithm=FLANN_INDEX_KDTREE, trees=5)
search_params = dict(checks=50)

flann = cv2.FlannBasedMatcher(index_params, search_params)

# matches = flann.knnMatch(descriptors, centroids, k=2)
matches = flann.match(np.asarray(descriptors, np.float32), centroids)
image_points = [[] for i in range(NUMBER_OF_IMAGES)]

for i, match in enumerate(matches):
    for j, point in clusters[match.trainIdx]:
        #-1, because of 1 - first element
        image_points[j - 1].append(True)

text_file = open('result_images.txt', 'w')
for i, point in enumerate(image_points):
    length = len(point)
    if length > 0:
        # text_file.write('Image {}: {}\n'.format(i+1, length))
        shutil.copy('./6/{}.jpg'.format(i+1), './result/{}n{}.jpg'.format(length, i + 1))
text_file.close()

# for i, match in enumerate(matches):
#     descriptors_cluster = clusters[0][match.trainIdx]
#     list1 = flann.knnMatch(np.asarray([descriptors[i]], np.float32), descriptors_cluster, k=10)
#     matches1 = list1[0]
#     for i, match1 in enumerate(matches1):
#         if match1.distance < 50:
#             x, y = key_points[i].pt
#             imgNumber, point = clusters[1][match1.trainIdx]
#             image_points[imgNumber].append([point, (int(x), int(y))])
#
# for i, points in enumerate(image_points):
#     if points:
#         stri = str(i)
#         filename = './6/scene'
#         for _ in range(5 - len(stri)):
#             filename += '0'
#         filename = filename + stri + '.jpg'
#         img = cv2.imread(filename)
#         for point in points:
#             point_from_dict, point_from_base_image = point
#             cv2.circle(img, point_from_dict, 2, (0, 255, 0), -1)
#             cv2.circle(base_image, point_from_base_image, 2, (0, 255, 0), -1)
#             # cv2.line(img,(0,0),(511,511),(255,0,0),5)
#         cv2.imshow(filename, img)
# cv2.imshow('base.jpg', base_image)
# cv2.waitKey(0)
