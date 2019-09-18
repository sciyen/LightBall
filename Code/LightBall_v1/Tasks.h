#ifndef TASK_H
#define TASK_H

#include "Constants.h"
#include "Essentials.h"

//#define BUFFER_SIZE 80
#define CMD_PARAMETER_LENGTH 14

const byte cmd_buffer[][CMD_PARAMETER_LENGTH] = {
  //     Mode,          Starting Time,   Duration,    h,    s,    l,color,  bri,count, duty
  {LM_SET_RGB, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0xFF, 0x77, 0x00, 0x00, 0x01, 0xFF}
};

#endif
