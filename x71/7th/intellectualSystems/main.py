# SBPU 471
# Recommendation system
# Authors: Artem Gorokhov

import time
import math
import datetime
import random

# ==== example of users and songs ====
user1 = 'baf47ed8da24d607e50d8684cde78b923538640f'
user2 = '530fe4b17c4c6d1cb88dccdf8a8ded8a19fe1c5e'
user3 = '85c1f87fea955d09b4bec2e36aee110927aedf9a'

song1 = 'SOKLBHE12A8C13B8FA'
song2 = 'SOACWYB12AF729E581'
# ====================================


dict_of_sims_for_each_user = {}

songs_for_learning = set()  # 80% of songs set
songs_for_testing = set()  # 20% of songs set
songs = set()  # 100% of songs set

M = {}  # dict like this 'user1 -> {song2: 2}; user2 -> {song3: 20}  '


def try_get_user(userID):
    return M.get(userID, -1)


def all_users():
    return M.keys()


def try_get_rate(userID, songID):
    return M[userID].get(songID, -1)


def get_user_vector(userID):
    if userID in M:
        return M[userID]


def plays_count_of_user(user_dict):
    count = 0
    for songID in user_dict:
        count += user_dict[songID]
    return count


def from_count_to_rate(count):
    if count == 1:
        return 1
    elif count in range(2, 3):
        return 2
    elif count in range(4, 6):
        return 3
    elif count in range(7, 10):
        return 4
    else:
        return 5


def get_filter_user_vector(userID, songs_set):
    if userID in M:
        result_vector = {}
        for songID in M[userID].keys():
            if songID in songs_set:
                result_vector[songID] = M[userID][songID]
        return result_vector
    else:
        return {}

def load_data_into_M(count_of_loading_users, filtering_count_of_plays):
    f = open("train_triplets.txt")
    count_of_users = 0
    cur_user = ''
    dict_of_cur_user = {}
    # format: user song countOfPlays
    for line in f:
        split = line.split()

        user = split[0]
        song = split[1]
        count = int(split[2])

        songs.add(song)

        if try_get_user(user) == -1:
            if cur_user == '':
                dict_of_cur_user = {}
                cur_user = user
            if cur_user != user:
                if plays_count_of_user(dict_of_cur_user) > filtering_count_of_plays:
                    count_of_users += 1
                    M[cur_user] = dict_of_cur_user
                dict_of_cur_user = {}
                cur_user = user
            if cur_user == user:
                dict_of_cur_user[song] = count
            if count_of_users == (count_of_loading_users):
                break

def testing_and_learning_sets():
    full_songs = list(songs)
    len_of_fs = len(full_songs)
    pr80 = int(len_of_fs * 0.80)
    pr20 = len_of_fs - pr80
    for i in range(0, pr20 - 1):
        random_num = random.randint(0, len(full_songs) - 1)
        songs_for_testing.add(full_songs.pop(random_num))
    songs_for_learning.update(set(full_songs))

def strtimedelta(starttime, stoptime):
    return str(datetime.timedelta(seconds=stoptime - starttime))

def user_cos(u1, u2):
    norm1 = 0
    norm2 = 0
    top = 0

    for el in u1.keys():
        norm1 += u1[el] * u1[el]
    for el in u2.keys():
        norm2 += u2[el] * u2[el]

    set1 = set(u1.keys())
    set2 = set(u2.keys())
    commonSet = set1 & set2

    for el in commonSet:
        top += u1[el] * u2[el]

    return top / math.sqrt(norm1 * norm2)

def get_similar(n, userID):
    similars = []
    user_vector = get_filter_user_vector(userID, songs_for_learning)

    for user in all_users():
        other_user_vector = get_filter_user_vector(user, songs_for_learning)

        cosin = user_cos(user_vector, other_user_vector)
        similars.append((cosin, user))
    similars.sort()
    len_similars = len(similars)
    return similars[len_similars - n - 1: len_similars - 1]

def learning(n):
    for userId in all_users():
        dict_of_sims_for_each_user[userId] = get_similar(n, userId)

def rate_prediction(user, song):
    similars = dict_of_sims_for_each_user[user]

    rate_sum = 0.0
    n = 0
    for (rate, similar) in similars:
        if try_get_user(similar) == -1:
            continue

        if try_get_rate(similar, song) == -1:
            continue
        n += 1
        rate_sum += try_get_rate(similar, song)
    if n == 0:
        return 0
    return rate_sum / n

def get_best_items(userID, item_number):
    best_items = []
    for song in songs:
        if try_get_rate(userID, song) != -1:
            continue

        prediction = rate_prediction(userID, song)
        best_items.append((prediction, song))
    best_items.sort()
    return best_items[len(best_items) - item_number - 1: len(best_items) - 1]

def RMSE():
    number_of_rates = 0
    sum_sqr_of_rates = 0.0
    users_done = 0

    for user in all_users():
        for song in get_filter_user_vector(user, songs_for_testing):
            real_rate = try_get_rate(user, song) != -1
            if real_rate == -1:
                continue
            prediction = rate_prediction(user, song)
            number_of_rates += 1

            diff = real_rate - prediction
            sqr = diff * diff
            sum_sqr_of_rates += sqr
        users_done += 1

    return math.sqrt(sum_sqr_of_rates / number_of_rates)

print "Parameters:"

Good_N_of_similar = 11
count_of_loading_users = 1000
filtering_count_of_plays = 51

load_data_into_M(count_of_loading_users, filtering_count_of_plays)

print "Count of similar for each user = " + str(Good_N_of_similar)
print "Count of plays for filtering each user = " + str(filtering_count_of_plays)
print "Count of unique users  = " + str(len(all_users()))
print "Count of unique songs = " + str(len(songs))

testing_and_learning_sets()

print "Size of learning set = " + str(len(songs_for_learning))
print "Size of testing set = " + str(len(songs_for_testing))

print "============Learning started=============="
t1 = time.time()
learning(Good_N_of_similar)
t2 = time.time()
print "Time = " + strtimedelta(t1, t2)
print "============Learning ended================"

print "============RMSE counting================="
t1 = time.time()
print "RMSE = " + str(RMSE())
t2 = time.time()
print "Time = " + strtimedelta(t1, t2)
print "============RMSE counting ended============"
