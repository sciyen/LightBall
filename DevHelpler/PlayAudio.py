import pyaudio
import wave
import numpy as np

FILENAME = ""
spf = None
player = None
stream = None
playing = False

def get_pos():
    global spf
    return spf.tell()

def set_pos(pos):
    global spf
    spf.setpos(pos)

def move_pos(offset):
    now = get_pos()
    set_pos(now+offset)

def callback(in_data, frame_count, time_info, status):
    global spf
    #global frame_assign
    #global frame_num
    #if frame_assign >= 0:
    #    frame_count = frame_assign
    #    frame_assign = -1
    #frame_num = time_info['output_buffer_dac_time']
    data = spf.readframes(frame_count)
    return (data, pyaudio.paContinue)

def init(filename):
    global FILENAME
    global spf
    global player
    global stream

    FILENAME = filename
    spf = wave.open(FILENAME, 'rb')
    player = pyaudio.PyAudio()
    stream = player.open(
                format=player.get_format_from_width(spf.getsampwidth()),
                channels=spf.getnchannels(),
                rate=spf.getframerate(),
                output=True,
                stream_callback=callback)

def playing():
    global playing
    return playing        

def play():
    global playing
    global stream
    playing = True
    stream.start_stream()

def pause():
    global playing
    global stream
    playing = False
    stream.stop_stream()

def switch():
    if playing:
        pause()
    else:
        play()

def stop():
    global spf
    global player
    global stream
    stream.stop_stream()
    stream.close()
    spf.close()
    player.terminate()

def get_music_info(filename, reduce_rate=1000):
    # Audio visualize
    spf = wave.open(filename, 'rb')
    params = spf.getparams()
    nchannels, sampwidth, framerate, nframes = params[:4]
    
    sound_info = spf.readframes(-1)
    sound_info = np.fromstring(sound_info, dtype=np.int16)
    sound_info = sound_info*1.0/(max(abs(sound_info)))
    sound_info = np.reshape(sound_info,[nframes,nchannels])
    
    sim_sound = [np.mean(sound_info[i*reduce_rate:(i+1)*reduce_rate]) for i in range(int(nframes/reduce_rate))]
    spf.close()
    return np.array(sim_sound), framerate/reduce_rate


