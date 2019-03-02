#ifndef MODES_H
#define MODES_H

#if defined(ARDUINO) && ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#endif

#define LIMITED_MIN 0
#define LIMITED_MAX 255

int get_limited_value(int v);
void set_rgb(int r=0, int g=0, int b=0);
void set_hsv(int h, int s, int v);

#endif
