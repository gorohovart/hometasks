import cv2
import kmeans
import cPickle as pickle
import time
import numpy as np
from random import randint


def save_object(obj, filename):
    with open(filename, 'wb') as output:
        pickle.dump(obj, output, pickle.HIGHEST_PROTOCOL)


def buildDictionary(IS_REBUILD_NEED, IS_REREAD_NEED, NUMBER_OF_CLUSTERS, NUMBER_OF_IMAGES):
    max = 0

    if not (IS_REBUILD_NEED): return pickle.load(open('dictionary.pkl', 'rb'))
    descriptors_dictionary = []
    keypoints_dictionary = []
    if IS_REREAD_NEED:
        sift = cv2.SIFT()
        start_time = time.time()
        for i in range(1, NUMBER_OF_IMAGES, 10):
            # Image read
            filename = './6/' + str(i) + '.jpg'
            image = cv2.imread(filename, cv2.CV_LOAD_IMAGE_GRAYSCALE)

            keypoints, descriptors = sift.detectAndCompute(image, None)
            if descriptors is None: continue

            if max < descriptors.shape[0]: max = descriptors.shape[0]

            for j, descriptor in enumerate(descriptors):
                x, y = keypoints[j].pt
                descriptors_dictionary.append(descriptor)
                keypoints_dictionary.append((i, (int(x), int(y))))
            print((i * 100.0) / 300)
            print('\n')
        print(max)
        read_time = time.time()
        readTime = read_time - start_time
        print('Read time:' + str(readTime) + '\n')
        save_object((descriptors_dictionary, keypoints_dictionary), 'images.pkl')
    else:
        descriptors_dictionary, keypoints_dictionary = pickle.load(open('images.pkl', 'rb'))

    print('dict size: ' + str(len(descriptors_dictionary)) + '\n')

    cluster_time1 = time.time()
    # Clustering
    data = np.asarray(descriptors_dictionary)
    criteria = (cv2.TERM_CRITERIA_EPS + cv2.TERM_CRITERIA_MAX_ITER, 10, 1.0)
    compactness, labels, centers = cv2.kmeans(data, NUMBER_OF_CLUSTERS, criteria, 1, cv2.KMEANS_RANDOM_CENTERS)

    cluster_time2 = time.time()
    clusterTime = cluster_time2 - cluster_time1
    print('Cluster time:' + str(clusterTime) + '\n')
    print('Cluster time:' + str(clusterTime / 60) + ' ' + str(clusterTime % 60) + '\n')
    print('Compactness:' + str(compactness) + '\n')

    clustered = labels, centers, keypoints_dictionary
    result = mk_clusters(clustered, NUMBER_OF_CLUSTERS)

    save_object(result, 'dictionary.pkl')
    return result


def mk_clusters(clustered, NUMBER_OF_CLUSTERS):
    labels, centers, keypoints_dictionary = clustered
    clusters = ([[] for i in range(NUMBER_OF_CLUSTERS)])
    # ccenters = [centers[i] for i in range(NUMBER_OF_CLUSTERS)]
    ccenters = np.asarray(centers, np.float32)
    for i, cluster_number in enumerate(labels):
        clusters[cluster_number].append(keypoints_dictionary[i])
    print('0 center: ')
    print(centers[0])
    print('\n')
    return clusters, ccenters


def removeStopList(result):
    clusters, centers = result

    length_list = []
    for cluster in clusters:
        length_list.append(len(cluster))

    length_list.sort()

    text_file = open('result_images.txt', 'w', encoding='utf8')
    for i in length_list:
        text_file.write(str(i) + '\n')
    text_file.close()


# NUMBER_OF_IMAGES = 2843
# IS_REREAD_NEED = False
# IS_REBUILD_NEED = True
# # IS_REBUILD_NEED = True
# NUMBER_OF_CLUSTERS = 30000
# clusters = buildDictionary(IS_REBUILD_NEED, IS_REREAD_NEED, NUMBER_OF_CLUSTERS, NUMBER_OF_IMAGES)
