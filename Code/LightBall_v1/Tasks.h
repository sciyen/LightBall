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
  // Mode,        Start,   Period, p1,     p2,     p3,     p4
    {LM_SET_RGB,  0,       0,      0,      0,      0,      0},
    {LM_EMPTY,    0,       0,      0,      0,      0,      0}
};

#endif
