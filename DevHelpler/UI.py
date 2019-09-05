import pygame as pg

TOP = 0
RIGHT = 1 
DOWN = 2
LEFT = 3

FONT_DEFAULT_COLOR = pg.Color('#14FFEC')
BTN_HOVER_COLOR = pg.Color('#222831')

BACKGROUND_COLOR = pg.Color('#323232')
BACKGROUND_MARGIN = (20, 20, 20, 20)

CA_AUDIO_BG_COLOR = pg.Color('#212121')
CA_WAVE_BG_COLOR = pg.Color('#323232')

BOARDLINE_COLOR = pg.Color('#0D7377')
BOARDLINE_MARGIN = (10, 10, 10, 10)

LABEL_SIZE = 24
LABEL_COLOR = pg.Color('#000000')
TEXTBOX_TEXT_COLOR = pg.Color('#333333')
TEXTBOX_BG_COLOR = pg.Color('#DDDDDD')
TEXTBOX_BG_COLOR = pg.Color('#DDDDDD')
TEXTBOX_HOVER_COLOR = pg.Color('#AAAAAA')

CA_AUDIO_HEIGHT = 200

# Setting screen size
display_size = (1280, 640)
def init():
    pg.init()
    screen = pg.display.set_mode(display_size)    
    pg.display.set_caption("Light Ball Dev Helper")           
    return screen

def draw_background(screen):
    # Setting background color
    display_size = screen.get_size()
    background = pg.Surface(display_size)
    background = background.convert()
    background.fill(BACKGROUND_COLOR)

    audio_rect_size = (display_size[0]-(BACKGROUND_MARGIN[RIGHT] + BACKGROUND_MARGIN[LEFT]), CA_AUDIO_HEIGHT)
    audio_rect_pos = (BACKGROUND_MARGIN[LEFT], display_size[1]-(BACKGROUND_MARGIN[DOWN]+CA_AUDIO_HEIGHT))

    pg.draw.rect(background
        , CA_AUDIO_BG_COLOR
        , (audio_rect_pos, audio_rect_size)
        , 0)
    pg.draw.rect(background
        , BOARDLINE_COLOR
        , (   audio_rect_pos[0] + BOARDLINE_MARGIN[LEFT]
            , audio_rect_pos[1] + BOARDLINE_MARGIN[TOP]
            , audio_rect_size[0]-BOARDLINE_MARGIN[RIGHT]-BOARDLINE_MARGIN[LEFT]
            , audio_rect_size[1]-BOARDLINE_MARGIN[TOP]-BOARDLINE_MARGIN[DOWN])
        , 4)

    return background

WAVE_SCALE = 800        # Wave form zoom in
CA_WAVE_HEIGHT = 150    # Size of wave displaying region
def draw_wave(sim_sound, redu_frame_rate):    
    # Real region to display wave form (A big canvas)
    ca_wave = pg.Surface((sim_sound.shape[0], CA_WAVE_HEIGHT))
    ca_wave = ca_wave.convert()
    ca_wave.fill(CA_WAVE_BG_COLOR)
    
    # Draw grid
    for i in range(int(sim_sound.shape[0]/redu_frame_rate)):
        pg.draw.line(ca_wave, (255, 255, 255)
                , (i*60, 0)
                , (i*60, CA_WAVE_HEIGHT), 1)
     
    # Draw wave form
    for i in range(sim_sound.shape[0]-1):
        pg.draw.line(ca_wave, (0,0,255)
                , (i,sim_sound[i]*WAVE_SCALE+CA_WAVE_HEIGHT/2)
                , (i+1, sim_sound[i+1]*WAVE_SCALE+CA_WAVE_HEIGHT/2), 1)
    wave_y = display_size[1]-(BACKGROUND_MARGIN[DOWN]+CA_AUDIO_HEIGHT)+(CA_AUDIO_HEIGHT-CA_WAVE_HEIGHT)/2

    return ca_wave, wave_y

def draw_pointer(sec_offset):
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
    pointer_y = display_size[1]-(BACKGROUND_MARGIN[DOWN]+CA_AUDIO_HEIGHT)
    return ca_pointer, pointer_y 

class TextList:
    def __init__(self, pos, size, col_height):
        self.index = 0
        self.pos = pos
        self.size = size
        self.offset = (10, 5)
        self.h = col_height
        self.select = 0
        self.item = 0
        self.rect = pg.Rect(self.pos, self.size)
        self.image = pg.Surface(self.rect.size).convert()
        self.image.fill(pg.Color('#DDDDDD'))
        self.text = []
        self.font = pg.font.SysFont("simhei", self.h)
        self.font_color = pg.Color("#111111")

    def hovered(self):
        x, y = pg.mouse.get_pos()
        if x>self.pos[0] and x<self.pos[0]+self.size[0] and y>self.pos[1] and y<self.pos[1]+self.size[1]:
            return True
        return False
    
    def appendText(self, txt, x=0, y=0):
        obj = {
                "text":self.font.render(txt, True, self.font_color),
                "pos": (self.pos[0]+self.offset[0]+x*self.size[0], self.pos[1]+self.offset[1]+y)
              }
        self.text.append(obj)

    def load(self, data=None, select=None):
        if data != None:
            self.data = data
        if select != None:
            self.select = select
        if self.select != None:
            self.image.fill(pg.Color('#DDDDDD'))
            pg.draw.rect(self.image
                , pg.Color('#BBBBBB')
                , (   (0, self.select*self.h)
                    , (self.size[1], self.h))
                , 0)

        keys = self.data[0].keys()
        self.text = []         
        self.appendText(txt="Previous", x=0.3)
        self.max_row = int(self.size[1]/self.h)-1
        for i in range(self.max_row-1):
            if i >= len(self.data):
                break
            for k in keys:
                if i == 0:
                    self.appendText(txt=k, x=self.data[0][k], y=self.h)
                else:
                    self.appendText(str(self.data[i+self.index][k]), x=self.data[0][k], y=self.h*(i+1))
        self.appendText(txt="Next", x=0.3, y=self.max_row*self.h)
 
    def setSelect(self, i):
        self.select = i
        self.itam = self.index + self,select -1
    def add(self, obj):
        self.data.insert(self.item, obj)
        self.item += 1
        self.select += 1
        self.load()
    def modify(self, index, obj):
        pass
    def delete(self):
        del self.data[self.item]
        self.load()
    def draw(self, surf):
        surf.blit(self.image, self.rect)
        for obj in self.text:
            surf.blit(obj["text"], obj["pos"])

    def update(self):
        x, y = pg.mouse.get_pos()
        point = (x-self.pos[0], y-self.pos[1])
        if x>self.pos[0] and x<self.pos[0]+self.size[0] and y>self.pos[1] and y<self.pos[1]+self.size[1]:
            i = int((point[1] - self.offset[1]) / self.h)
            if i == 0 and self.index > 0:
                self.index -= 1
            elif i >= self.max_row and self.index+self.max_row<=len(self.data):
                self.index += 1
            self.item = i + self.index -1
            self.load(select=i)
            return True
        return False

"""
Create a visualized text list, and provide the ability 
to make a focused column.
"""
class TextBox:
    def __init__(self, pos, size, color, text, font_size=24, font_color=FONT_DEFAULT_COLOR):
        self.pos = pos
        self.size = size
        self.rect = pg.Rect(pos, size)
        self.image = pg.Surface(self.rect.size).convert()
        self.color = color
        self.font = pg.font.SysFont("simhei", font_size)
        self.font_color = font_color
        self.txt = text
        self.draw_text()
   
    def draw_text(self):
        self.image.fill(self.color)
        self.text = self.font.render(self.txt, True, self.font_color)
        self.text_rect = self.text.get_rect(center=self.rect.center)
 
    def hovered(self):
        x, y = pg.mouse.get_pos()
        if x>self.pos[0] and x<self.pos[0]+self.size[0] and y>self.pos[1] and y<self.pos[1]+self.size[1]:
            return True
        return False

    def draw(self, surf):
        surf.blit(self.image, self.rect)
        surf.blit(self.text, self.text_rect)

class TextInput(TextBox):
    def __init__(self, pos, size, label, placehoder, color=TEXTBOX_BG_COLOR):
        super().__init__(pos, size, color, placehoder
                , font_color=LABEL_COLOR)
        self.focus = False
        self.label_font = pg.font.SysFont("simhei", LABEL_SIZE)
        self.label_text = self.label_font.render(label, True, FONT_DEFAULT_COLOR)
        self.label_rect = self.label_text.get_rect(topleft=(pos[0], pos[1]-LABEL_SIZE+8))

    def input(self, event, surf):
        if event.key == pg.K_BACKSPACE:
            self.txt = self.txt[:-1]
        else:
            self.txt += event.unicode
        self.draw_text()
        super().draw(surf)

    def setFocus(self, focus, surf):
        if focus != self.focus:
            if focus:
                self.image.fill(TEXTBOX_HOVER_COLOR)
            else:
                self.image.fill(self.color)
            self.focus = focus
            self.draw(surf)

    def draw(self, surf):
        super().draw(surf)
        surf.blit(self.label_text, self.label_rect)

class Button(TextBox):
    def __init__(self, pos, size, color, text, font_size=24):
        super().__init__(pos, size, color, text, font_size)
        self.pre_state = True
    
    def update(self, surf):
        now_state = self.hovered()
        if (now_state != self.pre_state):
            if now_state:
                self.image.fill(BTN_HOVER_COLOR)
            else:
                self.image.fill(self.color)
            self.pre_state = now_state
            super().draw(surf)

class TextGroup:
    def __init__(self, config):
        self.config = config
        self.pos = self.config["pos"]
        self.size = self.config["size"]
        self.rect = pg.Rect(self.pos, self.size)
        self.image = pg.Surface(self.rect.size).convert()
        self.image.fill(CA_AUDIO_BG_COLOR)
        self.buttons = []
        self.focusIndex = -1
        for btn in self.config["buttons"]:
            pos = (btn["pos"][0]+self.config["pos"][0], 
                   btn["pos"][1]+self.config["pos"][1])
            new_btn = TextInput(pos=pos, 
                    size=btn["size"],
                    label=btn["name"],
                    placehoder="")
            self.buttons.append(new_btn)
 
    def hovered(self):
        x, y = pg.mouse.get_pos()
        if x>self.pos[0] and x<self.pos[0]+self.size[0] and y>self.pos[1] and y<self.pos[1]+self.size[1]:
            return True
        return False

    def isFocus(self, surf):
        pre_focus = self.focusIndex
        if self.hovered():
            i = 0
            # Find which button clicked
            for i in range(len(self.buttons)):
                if self.buttons[i].hovered():
                    self.buttons[i].setFocus(True, surf)
                    self.focusIndex = i
                    break
                i += 1
            # Does not click on any button
            if i == len(self.buttons):
                self.focusIndex = -1
        else:
            self.focusIndex = -1

        # Redraw to not focus
        if pre_focus >= 0 and self.focusIndex != pre_focus:
            self.buttons[pre_focus].setFocus(False, surf)

    def input(self, event, surf):
        if self.focusIndex >= 0:
            self.buttons[self.focusIndex].input(event, surf)

    def draw(self, surf):
        self.image.fill(CA_AUDIO_BG_COLOR)
        surf.blit(self.image, self.rect)
        for btn in self.buttons:
            btn.draw(surf)
