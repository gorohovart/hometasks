import numpy as np

# CSV training set: http://www.pjreddie.com/media/files/mnist_train.csv
# CSV test set:     http://www.pjreddie.com/media/files/mnist_test.csv
step = 0.005
number_of_iterations = 20
numbers = (0, 1)


def get_set(file_name, numbers):
    a, b = numbers
    images = []
    numbers = []
    file = open(file_name, 'r')
    lines = file.readlines()
    file.close()
    for line in lines:
        linebits = line.split(',')
        number = int(linebits[0])
        if number == a or number == b:
            images.append(np.asfarray(linebits[1:]))
            numbers.append(1 if number == a else -1)
    return numbers, images


def e_in(w):
    res = np.zeros(28 * 28)
    for i, number in enumerate(train_numbers):
        image = train_images[i]
        res += (number * image) / (1 + np.exp(np.dot(number, w.T) * image))
        pass
    return (-1 / len(train_numbers)) * res


w = np.zeros(28 * 28)
train_numbers, train_images = get_set("mnist_train.csv", numbers)
test_numbers, test_images = get_set("mnist_test.csv", numbers)
for i in range(number_of_iterations):
    w = w - step * e_in(w)

results = []

for image in test_images:
    z = np.dot(image, w.T)
    results.append(1 / (1 + np.exp(-z)))

results = map(lambda x: x > 0.5, results)
TP = 0
TN = 0
FP = 0
FN = 0
for result, label in zip(results, test_numbers):
    res = result > 0.5
    if res and label == 1:
        TP += 1
    elif res and label == -1:
        FP += 1
    elif not res and label == 1:
        FN += 1
    else:
        TN += 1

file = open('output.txt', 'w')
file.write("number of iterations {}.\nstep {}\n".format(number_of_iterations, step))
file.write("TP {}, TN {}, FP {}, FN {}\n".format(TP, TN, FP, FN))
file.write("Precision {}\n".format(TP * 1.0 / (TP + FP)))
file.write("Recall {}\n".format(TP * 1.0 / (TP + FN)))
