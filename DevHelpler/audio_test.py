#!/usr/bin/python3
import PlayAudio
import time

PlayAudio.init("music.wav")
PlayAudio.play()

for i in range(100):
    #pass
    time.sleep(1)
    #PlayAudio.play()
    #time.sleep(1)
    #PlayAudio.pause()

PlayAudio.stop()
