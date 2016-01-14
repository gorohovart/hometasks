import cv2
import kmeans
import cPickle as pickle
import time
import numpy as np


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
        for i in range(1, NUMBER_OF_IMAGES, 50):
            stri = str(i)
            filename = './6/scene'
            for _ in range(5 - len(stri)):
                filename += '0'
            filename = filename + stri + '.jpg'
            im = cv2.imread(filename)
            image = cv2.cvtColor(im, cv2.COLOR_BGR2GRAY)
            keypoints, descriptors = sift.detectAndCompute(image, None)
            if descriptors is None: continue

            if max < descriptors.shape[0]: max = descriptors.shape[0]

            for j, descriptor in enumerate(descriptors):
                x, y = keypoints[j].pt
                descriptors_dictionary.append(descriptor)
                keypoints_dictionary.append((i, (int(x), int(y))))
            print((i * 100.0) / NUMBER_OF_IMAGES)
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
    criteria = (cv2.TERM_CRITERIA_EPS + cv2.TERM_CRITERIA_MAX_ITER, 1, 1.0)
    ret, labels, centers = cv2.kmeans(data, NUMBER_OF_CLUSTERS, criteria, 1, cv2.KMEANS_RANDOM_CENTERS)

    cluster_time2 = time.time()
    clusterTime = cluster_time2 - cluster_time1
    print('Cluster time:' + str(clusterTime) + '\n')

    clustered = data, labels, centers, keypoints_dictionary
    # gr_code_file = open('time.txt', 'w', encoding='utf8')

    # cluster_time = time.time()

    clusters = ([[] for i in range(NUMBER_OF_CLUSTERS)], [[] for i in range(NUMBER_OF_CLUSTERS)])
    for i, cluster_number in enumerate(labels):
        clusters[0][cluster_number].append(data[i])
        clusters[1][cluster_number].append(keypoints_dictionary[i])
    cent = np.asarray(centers, np.float32)
    c = []
    for i in range(NUMBER_OF_CLUSTERS):
        c.append(np.asarray(clusters[0][i], np.float32))

    result = ((c, clusters[1]), cent)

    save_object(result, 'dictionary.pkl')
    #  gr_code_file.writelines(str(readTime) + '\n' + str(len(dictionary)))
    # clustered = kmeans.cluster(dictionary, NUMBER_OF_CLUSTERS)

    # save_time = time.time()
    #
    #
    # clusterTime = read_time - cluster_time
    # saveTime = cluster_time - save_time
    #
    # gr_code_file.writelines(str(readTime) + '\n' + str(clusterTime) + '\n' + str(saveTime) + '\n')

    return result


def mk_clusters(clustered, NUMBER_OF_CLUSTERS, keypoints_dictionary):
    data, labels, centers = clustered
    clusters = ([[] for i in range(NUMBER_OF_CLUSTERS)], [[] for i in range(NUMBER_OF_CLUSTERS)])
    for i, cluster_number in enumerate(labels):
        clusters[0][cluster_number].append(data[i])
        clusters[1][cluster_number].append(keypoints_dictionary[i])
    centers = np.asarray(centers, np.float32)
    c = []
    for i in range(NUMBER_OF_CLUSTERS):
        c.append(np.asarray(clusters[0][i], np.float32))
    return (c, clusters[1]), centers

NUMBER_OF_IMAGES = 142101
IS_REREAD_NEED = True
IS_REBUILD_NEED = True
# IS_REBUILD_NEED = True
NUMBER_OF_CLUSTERS = 6000
clusters, centroids = buildDictionary(IS_REBUILD_NEED, IS_REREAD_NEED, NUMBER_OF_CLUSTERS,
                                                      NUMBER_OF_IMAGES)