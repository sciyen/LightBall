#include "Constants.h"
#include "Essentials.h"
#define DEBUGGER

void setup() {
    #ifdef DEBUGGER
    Serial.begin(9600);
    #endif
    ISR_disable();
    led_init();
    buffer_init();
    ISR_enable();
}

void loop() {
    buffer_update();
}
