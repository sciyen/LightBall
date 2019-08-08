import pygame as pg

import PlayAudio
import UI
import json

FUNCTION_JSON = './functions.json'
CONFIG_JSON = './config.json'

FONT_DEFAULT_COLOR = pg.Color('#14FFEC')

AUDIO_SOURCE = './music.wav'    # Name of wav audio file
FRAME_REDUCE = 1000
sec_offset = 40

sim_sound, redu_frame_rate = PlayAudio.get_music_info(AUDIO_SOURCE, FRAME_REDUCE)

screen = UI.init()
ca_background = UI.draw_background(screen=screen)
ca_wave, wave_y = UI.draw_wave(sim_sound, redu_frame_rate)
ca_pointer, pointer_y = UI.draw_pointer(sec_offset)

# Update screen
screen.blit(ca_background, (0, 0))
screen.blit(ca_wave, (sec_offset, wave_y))
pg.display.update()

print('wave width=' + str(sim_sound.shape) + ' frames')
print('frame_rate=' + str(redu_frame_rate) + ' frame/sec')

running = True
x_axis = sec_offset
sec_font = pg.font.SysFont("simhei", 24)

PlayAudio.init(AUDIO_SOURCE)

pre = 0
last_update_time =  pg.time.get_ticks()
# Buttons
btns = {}
btn_y = 350
#btns['load'] = UI.Button(pos=(20, btn_y), size=(50, 40), color=UI.CA_AUDIO_BG_COLOR, text="Load")
btns['add_effect'] = UI.Button(pos=(20, btn_y), size=(100, 40), color=UI.CA_AUDIO_BG_COLOR, text="Add Effect")
btns['del_effect'] = UI.Button(pos=(120, btn_y), size=(100, 40), color=UI.CA_AUDIO_BG_COLOR, text="Del Effect")
btns['add_key'] = UI.Button(pos=(250, btn_y), size=(100, 40), color=UI.CA_AUDIO_BG_COLOR, text="Add Key")
btns['del_key'] = UI.Button(pos=(350, btn_y), size=(100, 40), color=UI.CA_AUDIO_BG_COLOR, text="Del Key")
btns['set'] = UI.Button(pos=(470, btn_y), size=(100, 40), color=UI.CA_AUDIO_BG_COLOR, text="Set Time")
btns['sp'] = UI.Button(pos=(660, btn_y), size=(120, 40), color=UI.CA_AUDIO_BG_COLOR, text="Start/Pause")
btns['left'] = UI.Button(pos=(600, btn_y), size=(40, 40), color=UI.CA_AUDIO_BG_COLOR, text="<<")
btns['right'] = UI.Button(pos=(800, btn_y), size=(40, 40), color=UI.CA_AUDIO_BG_COLOR, text=">>")

def load_json_from_file(filename):
    try:
        with open(filename, 'r') as f:
            json_obj = json.load(f)
            f.close()
            return json_obj
    except FileNotFoundError:
        print(filename + " file not found")
        return

functions = load_json_from_file(FUNCTION_JSON)
config = load_json_from_file(CONFIG_JSON)

effect_list = UI.TextList(pos=(20, 20), size=(100, 300), col_height=20)
effect_list_obj = [{"Effect Name":0}]
for obj in functions['effects']:
    effect_list_obj.append({"Effect Name":obj["name"]})
effect_list.load(effect_list_obj)
effect_list.draw(screen)

effects = UI.TextList(pos=(140, 20), size=(200, 300), col_height=20)
test = []
test.append({"Effect":0, "start":0.5, "end":0.7})
for i in range(20):
    test.append({"Effect":"It's "+str(i), "start":i, "end":i})
effects.load(test)
effects.draw(screen)

keypoint = UI.TextList(pos=(370, 20), size=(200, 300), col_height=20)
keypoint.load(test)
keypoint.draw(screen)


text_group = []
text_group.append(UI.TextGroup(config['main_text_group']))
text_group.append(UI.TextGroup(config['keypoint_text_group']))

for tg in text_group:
    tg.draw(screen)

tb = UI.TextInput(pos=(600, 20), size=(80, 30), label="test", placehoder="empty")
tb.draw(screen)
PlayAudio.pause()
while running:
    pre_axis = x_axis
    frame_num = PlayAudio.get_pos()
    if frame_num - pre != 0:
        #print(str(current_frame-pre) +"  "+ str(count))
        last_update_time = pg.time.get_ticks()
        pre = frame_num
        current_frame = frame_num
    elif PlayAudio.playing:
        current_frame = frame_num + (pg.time.get_ticks() - last_update_time)*44.1
    x_axis = int(-current_frame/FRAME_REDUCE)
    # Detect events
    for event in pg.event.get():
        if event.type == pg.MOUSEBUTTONDOWN:
            # Mouse scroll
            if event.button == 4: 
                PlayAudio.pause()
                PlayAudio.move_pos(-5*FRAME_REDUCE)
            if event.button == 5: 
                PlayAudio.pause()
                PlayAudio.move_pos(5*FRAME_REDUCE)

            # Pressed
            if event.button == 1:
                if btns['sp'].hovered():
                    if not PlayAudio.playing:
                        PlayAudio.move_pos(-12288)
                    PlayAudio.switch()
                elif btns['left'].hovered():
                    PlayAudio.pause()
                    PlayAudio.move_pos(-FRAME_REDUCE)
                elif btns['right'].hovered():
                    PlayAudio.pause()
                    PlayAudio.move_pos(FRAME_REDUCE)
                elif btns['add_effect'].hovered():
                    effect_index = effect_list.item
                    effect_name = effect_list.data[effect_index]
                    print("Add ", end="")
                    print(effect_name)
                    effects.add({"Effect":effect_name["Effect Name"], "start":round(music_sec, 3), "end":round(music_sec+1, 3)})
                    effects.draw(screen)
                elif btns['del_effect'].hovered():
                    effect_index = effects.item
                    print("Delete ", end="")
                    print(effects.data[effect_index])
                    effects.delete()
                    effects.draw(screen)
                elif effect_list.update():
                    effect_list.draw(screen)
                elif effects.update():
                    effects.draw(screen)
                elif keypoint.update():
                    keypoint.draw(screen)
                else:
                    if tb.hovered():
                        tb.setFocus(True, screen)
                    else:
                        tb.setFocus(False, screen)
            for i in range(len(text_group)):
                text_group[i].isFocus(screen)
        # Key down
        if event.type == pg.KEYDOWN:
            if tb.focus:
                tb.input(event, screen)
            for i in range(len(text_group)):
                text_group[i].input(event, screen)


        # Click close
        elif event.type == pg.QUIT:
            running = False
    
    for k in btns.keys():
        btns[k].update(screen)

    if pre_axis != x_axis:
        # Display time stamp only when mouse scrolled
        music_sec = (-x_axis)/redu_frame_rate
        music_text = sec_font.render("{:.2f}s".format(music_sec), True, UI.FONT_DEFAULT_COLOR, UI.CA_AUDIO_BG_COLOR)

        screen.blit(ca_wave, (sec_offset + x_axis, wave_y))
        screen.blit(music_text, (sec_offset+20, wave_y-20))
        screen.blit(ca_pointer, (0, pointer_y))
    pg.display.update()

    # Set FPS    
    pg.time.Clock().tick(30)

PlayAudio.stop()
pg.quit()  
