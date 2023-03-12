import socket
import random
import time

HOST = '127.0.0.1'
PORT = 5000

client = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

languages = [\
"Happy,0.8,おーっほっほっほ！お嬢様でしてよ！！",\
"Angry,0.6,無礼者！わたくしを誰と心得るの？",\
"Sad,0.6,わたくしにだって落ち込む日くらいありましてよ",\
"Relaxed,0.4,優雅たれ。わたくしのモットーですわ",\
"Surprised,0.4,きゃっ！？……んんっ、こほん",\
"Happy,0.6,華麗に可憐なわたくし登場ですわ！",\
"Angry,0.8,……わたくし、無作法ものは相手にしない主義ですの",\
"Sad,0.4,あなたがそんな調子だと、わたくもやりにくくってよ",\
"Relaxed,0.4,優雅なアフタヌーンティー……至福の時間ですわ",\
"Surprised,0.9,なっなっなっ！？なんですの！？",\
"Happy,0.6,ごきげんよう。ご機嫌いかか？",\
"Angry,0.4,今、あなたとは口を聞きたくありませんの",\
"Sad, 0.4,そのっ……さすがにわたくしも、言い過ぎでしたわ",\
"Relaxed,0.6,こんな日は乗馬がしたくなりますわね",\
"Surprised,0.9,ひぇっわたくし、怪談は苦手でしてよ！？"\
]

while True:
    a = random.choice(languages)
    result = str(a)
    print(a)
    client.sendto(result.encode('utf-8'),(HOST,PORT))
    time.sleep(5.0)