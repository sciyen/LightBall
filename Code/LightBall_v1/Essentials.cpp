#include "Essentials.h"
#include "Constants.h"
volatile char led_buffer[3];
//int cmd_buffer[BUFFER_SIZE][CMD_PARAMETER_LENGTH];
int buffer_counter;
int buffer_excute_counter;
unsigned long buffer_start_time;

void led_init(){
    pinMode(BTN_PIN, INPUT_PULLUP);
    pinMode(RED_LED_PIN,    OUTPUT);
    pinMode(GREEN_LED_PIN,  OUTPUT);
    pinMode(BLUE_LED_PIN,   OUTPUT);
    digitalWrite(RED_LED_PIN,   LED_CLOSE);
    digitalWrite(GREEN_LED_PIN, LED_CLOSE);
    digitalWrite(BLUE_LED_PIN,  LED_CLOSE);
}

void buffer_init(){
    led_buffer[LED_R_INDEX] = LED_CLOSE;
    led_buffer[LED_G_INDEX] = LED_CLOSE;
    led_buffer[LED_B_INDEX] = LED_CLOSE;
    buffer_counter = 0;
    buffer_excute_counter = 0;
    /*
    for(int i=0; i<BUFFER_SIZE; i++){
        cmd_buffer[i][0] = LM_EMPTY;
        for(int j=1; j<CMD_PARAMETER_LENGTH; j++)
            cmd_buffer[i][j] = 0;
    }*/
    buffer_start_time = millis();
}

void inline led_update(){
    analogWrite(RED_LED_PIN,    led_buffer[LED_R_INDEX]);
    analogWrite(GREEN_LED_PIN,  led_buffer[LED_G_INDEX]);
    analogWrite(BLUE_LED_PIN,   led_buffer[LED_B_INDEX]);
}
/*
void set_cmd(int mode, int startTime, int period, int p1, int p2, int p3, int p4, int p5, int p6, int p7){
    if( buffer_counter >= BUFFER_SIZE) return;
    cmd_buffer[buffer_counter][BUFFER_MODE_BIT] = mode;
    cmd_buffer[buffer_counter][BUFFER_START_TIME_BIT] = startTime;
    cmd_buffer[buffer_counter][BUFFER_PERIOD_BIT] = period;
    cmd_buffer[buffer_counter][BUFFER_P1_BIT] = p1;
    cmd_buffer[buffer_counter][BUFFER_P2_BIT] = p2;
    cmd_buffer[buffer_counter][BUFFER_P3_BIT] = p3;
    cmd_buffer[buffer_counter][BUFFER_P4_BIT] = p4;
    cmd_buffer[buffer_counter][BUFFER_P5_BIT] = p5;
    cmd_buffer[buffer_counter][BUFFER_P6_BIT] = p6;
    cmd_buffer[buffer_counter][BUFFER_P7_BIT] = p7;
    buffer_counter += 1;
}*/

unsigned long inline get_buffer_start_time(){
    return (millis() - buffer_start_time);
}

void buffer_update(){
    /* if the task work done, move to next task. */
    if( get_buffer_start_time() > 
        cmd_buffer[buffer_excute_counter][BUFFER_START_TIME_BIT]
      + cmd_buffer[buffer_excute_counter][BUFFER_PERIOD_BIT] ){
        //set_hsv_progressive_init();
        //set_rgb_spark_progressive_init();
        buffer_excute_counter += 1;
        set_rgb(LED_CLOSE, LED_CLOSE, LED_CLOSE);
      }
    
    /* if command buffer is a empty task, reset the counter and wait for next call. */
    if( cmd_buffer[buffer_excute_counter][BUFFER_MODE_BIT] == LM_EMPTY ){
        buffer_init();
        return;
    }
    
    /* if the task time is about to start */
    if( get_buffer_start_time() > cmd_buffer[buffer_excute_counter][BUFFER_START_TIME_BIT] ){
        switch(cmd_buffer[buffer_excute_counter][BUFFER_MODE_BIT]){
            case LM_EMPTY:
            case LM_SET_CLOSE: set_rgb(LED_CLOSE, LED_CLOSE, LED_CLOSE); break;
            case LM_SET_RGB: set_rgb(cmd_buffer[buffer_excute_counter][BUFFER_P1_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P2_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P3_BIT]); break;
            case LM_SET_RGB_SPARK: set_rgb_spark(cmd_buffer[buffer_excute_counter][BUFFER_P1_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P2_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P3_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_PERIOD_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_P4_BIT]); break;
            case LM_SET_RGB_SPARK_PROGRESSIVE: set_rgb_spark_progressive(cmd_buffer[buffer_excute_counter][BUFFER_P1_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P2_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P3_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_PERIOD_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_P4_BIT]); break;
            case LM_SET_HSV: set_hsv(cmd_buffer[buffer_excute_counter][BUFFER_P1_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P2_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P3_BIT]); break;
            case LM_SET_HSV_SPARK: set_hsv_spark(cmd_buffer[buffer_excute_counter][BUFFER_P1_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P2_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P3_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_PERIOD_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_P4_BIT]); break; 
            case LM_SET_HSV_PROGRESSIVE: set_hsv_progressive(cmd_buffer[buffer_excute_counter][BUFFER_P1_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P2_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P3_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_PERIOD_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_P4_BIT]); break;                                                       
            case LM_SET_HSV_SPARK_PROGRESSIVE: set_hsv_spark_progressive(cmd_buffer[buffer_excute_counter][BUFFER_P1_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P2_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P3_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_PERIOD_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_P4_BIT]); break;                                                    
            case LM_SET_HSL_PROGRESSIVE: set_hsl_progressive(
                                     (unsigned int)(get_buffer_start_time()-cmd_buffer[buffer_excute_counter][BUFFER_START_TIME_BIT]),
                                     cmd_buffer[buffer_excute_counter][BUFFER_P1_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P2_BIT], 
                                     cmd_buffer[buffer_excute_counter][BUFFER_P3_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_P4_BIT],
                                     cmd_buffer[buffer_excute_counter][BUFFER_P5_BIT]); break; 
                                     
        }
    }
}

void hsv_test(){
    set_hsv(0, 255, 255);
    set_hsv(30, 255, 255);
    set_hsv(60, 255, 255);
    set_hsv(90, 255, 255);
    set_hsv(120, 255, 255);
    set_hsv(180, 255, 255);
    set_hsv(210, 255, 255);
    set_hsv(240, 255, 255);
    set_hsv(270, 255, 255);
    set_hsv(300, 255, 255);
    set_hsv(330, 255, 255);
    set_hsv(360, 255, 255);
}

void ISR_enable()
{
  TCCR2A = 0;
  TCCR2B = 0; 
  TCCR2B |= (1<<WGM22);  // CTC mode; Clear Timer on Compare
  TCCR2B |= (1<<CS22) | (1<<CS20);  // Prescaler == 8 ||(1<<CS30)
  TIMSK2 |= (1 << OCIE2A);  // enable CTC for TIMER1_COMPA_vect
  TCNT2=0;  // counter 歸零 
  OCR2A = 1000;
}

void ISR_disable()
{
  TCCR2A = 0;
  TCCR2B = 0; 
}


ISR(TIMER2_COMPA_vect)
{
    led_update();
}
