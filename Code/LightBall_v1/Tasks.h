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
#define CMD_PARAMETER_LENGTH 8
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
    {LM_SET_HSV_PROGRESSIVE,        34000,    10000,  0,        360,    100,    1},
    {LM_SET_HSV_SPARK_PROGRESSIVE,  0,        10000,  0,        360,    100,    1},
    {LM_SET_RGB_SPARK_PROGRESSIVE,  10000,    5000,   125,      125,    0,      5},
    {LM_SET_HSV_PROGRESSIVE,        15000,    10000,  0,        360,    100,    1},
    {LM_SET_CLOSE,                  25000,    10000,  0,        0,      0,      0},*/
    //{LM_SET_RGB,                    0,        1000,   0,    255,    0,    0},

    {LM_SET_HSL_PROGRESSIVE,2569,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,3019,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,3469,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,6019,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,6469,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,6919,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,9469,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,9919,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,10369,100,253,252,119,0,0},
{LM_SET_HSL_PROGRESSIVE,13904,100,0,255,155,0,0},
{LM_SET_HSL_PROGRESSIVE,13904,100,0,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,14339,100,0,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,14774,100,1,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,15209,100,2,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,15644,100,3,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,16079,100,5,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,16514,100,8,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,16949,100,11,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,17384,100,14,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,17819,100,18,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,18254,100,22,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,18689,100,27,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,19124,100,32,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,19559,100,38,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,19994,100,44,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,20429,100,51,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,20864,100,58,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,21299,100,65,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,21734,100,73,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,22169,100,81,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,22604,100,90,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,23039,100,99,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,23474,100,109,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,23909,100,119,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,24344,100,129,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,24779,100,140,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,25214,100,151,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,25649,100,163,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,26084,100,175,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,26519,100,188,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,26954,100,201,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,27389,100,215,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,27824,100,228,255,114,0,0},
{LM_SET_HSL_PROGRESSIVE,28212,13485,201,252,164,10,0},










    
    /*{LM_SET_HSL_PROGRESSIVE,        0,        1000,   0,        240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        1000,     1000,   40,       240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        2000,     1000,   80,       240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        3000,     1000,   120,       240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        4000,     1000,   160,       240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        5000,     1000,   200,       240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        6000,     1000,   240,       240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        7000,     1000,   280,       240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        8000,     1000,   320,       240,    150,    0, -100},
    {LM_SET_HSL_PROGRESSIVE,        9000,     1000,   360,       240,    150,    0, -100},*/

    
    {LM_EMPTY,                      0,       0,      0,      0,      0,      0, 0}
};

#endif
