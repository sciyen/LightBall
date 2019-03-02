#include "Modes.h"
#include "Essentials.h"

/* check the value always limited in MIN ~ MAX */
int inline get_limited_value(int v){
    return (v<LIMITED_MIN) ? LIMITED_MIN : ( (v>LIMITED_MAX) ? LIMITED_MAX : v );
}

void inline set_rgb(int r, int g, int b){
    led_buffer[RED_LED_PIN] = get_limited_value(r);
    led_buffer[GREEN_LED_PIN] = get_limited_value(g);
    led_buffer[BLUE_LED_PIN] = get_limited_value(b);
}

/*
 * h = 0~360
 * s = 0~255
 * v = 0~255
 */
void set_hsv(int h, int s, int v){
    int r, g, b;
    int hi = (h / 60) % 6;
    int p = v * (255 - s) / 255;
    int q = v * (255 - s * (60 - h % 60) / 60) / 255;
    int t = v * (255 - (h % 60) / 60 * s) / 255;
    if (hi == 0)      { r = v; g = t; b = p; }
    else if (hi == 1) { r = q; g = v; b = p; }
    else if (hi == 2) { r = p; g = v; b = t; }
    else if (hi == 3) { r = p; g = q; b = v; }
    else if (hi == 4) { r = t; g = p; b = v; }
    else if (hi == 5) { r = v; g = p; b = q; }
    #ifdef DEBUGGER
    Serial.print("(h,s,v)=(");
    Serial.print(h);
    Serial.print(",");
    Serial.print(s);
    Serial.print(",");
    Serial.print(v);
    Serial.print(") -> (r,g,b)=(");
    Serial.print(r);
    Serial.print(",");
    Serial.print(g);
    Serial.print(",");
    Serial.print(b);
    Serial.print(")\n");
    #endif
    set_rgb(r, g, b);
}

