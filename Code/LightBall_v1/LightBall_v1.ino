#include "Constants.h"
#include "Essentials.h"
#define DEBUGGER

void setup() {
    #ifdef DEBUGGER
    Serial.begin(9600);
    #endif
    led_init();
    buffer_init();
}

void loop() {
    led_update();
}
