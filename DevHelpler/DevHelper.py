import pygame as pg
import sys
import numpy as np
import wave
import matplotlib.pyplot as plt


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


TOP = 0
RIGHT = 1 
DOWN = 2
LEFT = 3
BACKGROUND_COLOR = pg.Color('#323232')
BACKGROUND_MARGIN = (20, 20, 20, 20)
CA_AUDIO_BG_COLOR = pg.Color('#212121')
BTN_HOVER_COLOR = pg.Color('#222831')
CA_WAVE_BG_COLOR = pg.Color('#323232')
BOARDLINE_COLOR = pg.Color('#0D7377')
BOARDLINE_MARGIN = (10, 10, 10, 10)
FONT_DEFAULT_COLOR = pg.Color('#14FFEC')
CA_AUDIO_HEIGHT = 200
CA_WAVE_HEIGHT = 150    # Size of wave displaying region
WAVE_SCALE = 800        # Wave form zoom in

AUDIO_SOURCE = './music.wav'    # Name of wav audio file
sec_offset = 40

pg.init()

# Setting screen size
display_size = (1280, 640)
screen = pg.display.set_mode(display_size)    
pg.display.set_caption("Light Ball Dev Helper")           

# Setting background color
background = pg.Surface(screen.get_size())
background = background.convert()
background.fill(BACKGROUND_COLOR)

# Setting audio block
ca_audio_size = screen.get_size()
ca_audio_size = (display_size[0]-(BACKGROUND_MARGIN[RIGHT] + BACKGROUND_MARGIN[LEFT]), CA_AUDIO_HEIGHT)
ca_audio = pg.Surface(ca_audio_size)
ca_audio = ca_audio.convert()
ca_audio.fill(CA_AUDIO_BG_COLOR)

pg.draw.rect(ca_audio
        , BOARDLINE_COLOR
        , [BOARDLINE_MARGIN[LEFT]
            , BOARDLINE_MARGIN[TOP]
            , ca_audio_size[0]-BOARDLINE_MARGIN[RIGHT]-BOARDLINE_MARGIN[LEFT]
            , ca_audio_size[1]-BOARDLINE_MARGIN[TOP]-BOARDLINE_MARGIN[DOWN]]
        , 4)

sim_sound, frame_rate = get_music_info(AUDIO_SOURCE, 1000)

# Real region to display wave form (A big canvas)
ca_wave = pg.Surface((sim_sound.shape[0], CA_WAVE_HEIGHT))
ca_wave = ca_wave.convert()
ca_wave.fill(CA_WAVE_BG_COLOR)

# Draw grid
for i in range(int(sim_sound.shape[0]/frame_rate)):
    pg.draw.line(ca_wave, (255, 255, 255)
            , (i*60, 0)
            , (i*60, CA_WAVE_HEIGHT), 1)

# Draw wave form
for i in range(sim_sound.shape[0]-1):
    pg.draw.line(ca_wave, (0,0,255)
            , (i,sim_sound[i]*WAVE_SCALE+CA_WAVE_HEIGHT/2)
            , (i+1, sim_sound[i+1]*WAVE_SCALE+CA_WAVE_HEIGHT/2), 1)

# Draw pointer
POINTER_RADIUS = 15
ca_pointer = pg.Surface((2*sec_offset, CA_AUDIO_HEIGHT), pg.SRCALPHA)
ca_pointer.fill((255, 255, 255, 0))
pg.draw.line(ca_pointer                       # Middle indicator
        , (0, 0, 0, 128)
        , (sec_offset, 0)
        , (sec_offset, CA_AUDIO_HEIGHT), 3)
pg.draw.circle(ca_pointer                     # Uppper decoration
        , pg.Color('#F9ED69')
        , (sec_offset, POINTER_RADIUS)
        , POINTER_RADIUS, 0)
pg.draw.circle(ca_pointer                     # Lower decoration
        , pg.Color('#F9ED69')
        , (sec_offset, CA_AUDIO_HEIGHT-POINTER_RADIUS)
        , POINTER_RADIUS, 0)

# Update screen
screen.blit(background, (0, 0))
screen.blit(ca_audio, (BACKGROUND_MARGIN[LEFT], display_size[1]-(BACKGROUND_MARGIN[DOWN]+CA_AUDIO_HEIGHT)))
screen.blit(ca_wave, (40, display_size[1]-(BACKGROUND_MARGIN[DOWN]+CA_AUDIO_HEIGHT)+(CA_AUDIO_HEIGHT-CA_WAVE_HEIGHT)/2))
pg.display.update()

print('wave width=' + str(sim_sound.shape) + ' frames')
print('frame_rate=' + str(frame_rate) + ' frame/sec')
print('screen size=' + str(ca_audio_size))

class Button:
    def __init__(self, pos, size, color, text, font_size=24):
        self.pos = pos
        self.size = size
        self.rect = pg.Rect(pos, size)
        self.image = pg.Surface(self.rect.size).convert()
        self.color = color
        self.image.fill(self.color)
        self.font = pg.font.SysFont("simhei", font_size)
        self.font_color = FONT_DEFAULT_COLOR 
        self.text = self.font.render(text, True, self.font_color)
        self.text_rect = self.text.get_rect(center=self.rect.center)
    
    def hovered(self):
        x, y = pg.mouse.get_pos()
        if x>self.pos[0] and x<self.pos[0]+self.size[0] and y>self.pos[1] and y<self.pos[1]+self.size[1]:
            return True
        return False

    def draw(self, surf):
        if self.hovered():
            self.image.fill(BTN_HOVER_COLOR)
        else:
            self.image.fill(self.color)
        surf.blit(self.image, self.rect)
        surf.blit(self.text, self.text_rect)

running = True
music_playing = False
x_axis = sec_offset
sec_font = pg.font.SysFont("simhei", 24)

AUDIO_SOURCE='./music.mp3'
# Load music
pg.mixer.music.load(AUDIO_SOURCE)
pg.mixer.music.play()
pg.mixer.music.pause()

# Buttons
btn_sp = Button(pos=(50, 50), size=(120, 40), color=CA_AUDIO_BG_COLOR, text="Start/Pause")
while running:
    current_frame = pg.mixer.music.get_pos()/1000 # Seconds in unit
    x_axis = int(-current_frame*frame_rate)
    # Detect events
    for event in pg.event.get():
        if event.type == pg.MOUSEBUTTONDOWN:
            # Mouse scroll
            if event.button == 4: 
                x_axis -= 20
            if event.button == 5: 
                x_axis += 20

            # Pressed
            if event.button == 1:
                if btn_sp.hovered:
                    if music_playing:
                        pg.mixer.music.pause()
                        music_playing = False
                    else:
                        print(-x_axis/frame_rate)
                        #pg.mixer.music.play(-1, start=-x_axis/frame_rate)
                        pg.mixer.music.set_pos(10)
                        #pg.mixer.music.play(-1, 2.0)
                        pg.mixer.music.unpause()
                        music_playing = True
        # Click close
        elif event.type == pg.QUIT:
            running = False
    
    btn_sp.draw(screen)

    # Display time stamp only when mouse scrolled
    music_sec = (-x_axis)/frame_rate
    music_text = sec_font.render("{:.2f}s".format(music_sec), True, FONT_DEFAULT_COLOR, CA_AUDIO_BG_COLOR)
    wave_y = display_size[1]-(BACKGROUND_MARGIN[DOWN]+CA_AUDIO_HEIGHT)+(CA_AUDIO_HEIGHT-CA_WAVE_HEIGHT)/2

    screen.blit(ca_wave, (sec_offset + x_axis, wave_y))
    screen.blit(music_text, (sec_offset+20, wave_y-20))
    screen.blit(ca_pointer, (0, display_size[1]-(BACKGROUND_MARGIN[DOWN]+CA_AUDIO_HEIGHT)))
    pg.display.update()

    # Set FPS    
    pg.time.Clock().tick(30)

pg.mixer.music.unload()
pg.quit()  
