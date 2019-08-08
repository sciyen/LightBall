#ifndef ESSENTIAL_H
#define ESSENTIAL_H

#if defined(ARDUINO) && ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#endif

#include "Tasks.h"
#include "Modes.h"

/* LED */
#define   RED_LED_PIN   5
#define GREEN_LED_PIN   6
#define  BLUE_LED_PIN   9
#define  LED_OPEN 1
#define LED_CLOSE 0
#define LED_R_INDEX 0
#define LED_G_INDEX 1
#define LED_B_INDEX 2
extern volatile char led_buffer[3];

/* LED BUFFER */
#define         BUFFER_MODE_BIT 0
#define   BUFFER_START_TIME_BIT 1
#define       BUFFER_PERIOD_BIT 2
#define           BUFFER_P1_BIT 3
#define           BUFFER_P2_BIT 4
#define           BUFFER_P3_BIT 5
#define           BUFFER_P4_BIT 6
#define           BUFFER_P5_BIT 7
#define           BUFFER_P6_BIT 8
#define           BUFFER_P7_BIT 9

//#define BUFFER_SIZE 80
//#define CMD_PARAMETER_LENGTH 10
//extern int cmd_buffer[BUFFER_SIZE][CMD_PARAMETER_LENGTH];
extern int buffer_counter;
extern int buffer_excute_counter;
extern unsigned long buffer_start_time;


void led_init();
void buffer_init();
void led_update();
//void set_cmd(int mode, int startTime, int period, int p1=0, int p2=0, int p3=0, int p4=0, int p5=0, int p6=0, int p7=0);
unsigned long inline get_buffer_start_time();
void buffer_update();
void hsv_test();
void ISR_enable();
void ISR_disable();

#endif
