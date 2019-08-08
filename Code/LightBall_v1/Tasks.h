#ifndef TASK_H
#define TASK_H

#if defined(ARDUINO) && ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#endif

#include "Constants.h"
#include "Essentials.h"

//#define BUFFER_SIZE 80
#define CMD_PARAMETER_LENGTH 10
const int cmd_buffer[][CMD_PARAMETER_LENGTH] = {
  // Mode,                          Start,    Period, p1,     p2,     p3,     p4
    /*{LM_SET_RGB,                    0,        1000,   125,    125,    125,    0},
    {LM_SET_HSV      ,              1000,     1000,   0,      255,    100,    4},
    {LM_SET_HSV      ,              2000,     1000,   20,      255,    100,    4},
    {LM_SET_HSV      ,              3000,     1000,   40,      255,    100,    4},
    {LM_SET_HSV      ,              4000,     1000,   60,      255,    100,    4},
    {LM_SET_HSV      ,              5000,     1000,   80,      255,    100,    4},
    {LM_SET_HSV      ,              6000,     1000,   100,      255,    100,    4},
    {LM_SET_HSV      ,              7000,     1000,   120,      255,    100,    4},
    {LM_SET_HSV      ,              8000,     1000,   140,      255,    100,    4},
    {LM_SET_HSV      ,              9000,     1000,   160,      255,    100,    4},
    {LM_SET_HSV      ,              10000,    1000,   180,      255,    100,    4},
    {LM_SET_HSV      ,              11000,    1000,   200,      255,    100,    4},
    {LM_SET_HSV      ,              12000,    1000,   240,      255,    100,    4},
    {LM_SET_HSV      ,              13000,    1000,   260,      255,    100,    4},
    {LM_SET_HSV      ,              14000,    1000,   280,      255,    100,    4},
    {LM_SET_HSV      ,              15000,    1000,   300,      255,    100,    4},
    {LM_SET_HSV      ,              16000,    1000,   320,      255,    100,    4},
    {LM_SET_HSV      ,              17000,    1000,   340,      255,    100,    4},
    {LM_SET_HSV      ,              18000,    1000,   360,      255,    100,    4},
    {LM_SET_HSV_SPARK_PROGRESSIVE,  19000,    10000,  0,        360,    100,    1},
    {LM_SET_RGB_SPARK_PROGRESSIVE,  29000,    5000,   125,      125,    0,      5},
    {LM_SET_HSV_PROGRESSIVE,        34000,    10000,  0,        360,    100,    1},*/
    {LM_SET_HSV_SPARK_PROGRESSIVE,  0,        10000,  0,        360,    100,    1},
    {LM_SET_RGB_SPARK_PROGRESSIVE,  10000,    5000,   125,      125,    0,      5},
    {LM_SET_HSV_PROGRESSIVE,        15000,    10000,  0,        360,    100,    1},
    {LM_SET_CLOSE,                  25000,    10000,  0,        0,      0,      0},
    {LM_EMPTY,                      0,       0,      0,      0,      0,      0}
};

#endif
