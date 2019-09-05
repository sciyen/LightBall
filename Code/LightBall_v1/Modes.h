#ifndef MODES_H
#define MODES_H

#if defined(ARDUINO) && ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#endif

#define LIMITED_MIN 0
#define LIMITED_MAX 255
/* HSV */
#define DEFAULT_HSV_S 255
#define HSV_V_MAX 100
#define HSV_PROGRESSIVE_UPDATE_CYCLE 180
/* RGB */
#define SPARK_PROGRESSIVE_TIME_LIMIT 20
extern int hsv_task_counter;
extern int spark_task_counter;

char get_limited_value(int v);
void set_rgb(int r=0, int g=0, int b=0);
void set_rgb_spark(int r, int g, int b, int period, int fre);
void set_hsv(int h, int s, int v);
void set_hsv_spark(int h, int s, int v, int period, int fre);
void set_hsv_progressive_init();
void set_hsv_progressive(int h_start, int h_end, int v, int period, int fre);
void set_hsv_spark_progressive(int h_start, int h_end, int v, int period, int fre);
void set_rgb_spark_progressive_init();
void set_rgb_spark_progressive(int r, int g, int b, int period, int fre);
float HueToRGB(float v1, float v2, float vH);
void set_hsl(int H, float S, float L);
void set_hsl_progressive(unsigned int index, int h, int s, int l, int colorTrans, int brightTrans);

#endif
