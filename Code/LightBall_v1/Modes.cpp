#include "Modes.h"
#include "Essentials.h"
//#define DEBUGGER
/* check the value always limited in MIN ~ MAX */
char inline get_limited_value(int v){
    return (char)(v<LIMITED_MIN) ? LIMITED_MIN : ( (v>LIMITED_MAX) ? LIMITED_MAX : v );
}
void inline set_rgb(int r, int g, int b){
    led_buffer[LED_R_INDEX] = get_limited_value(r);
    led_buffer[LED_G_INDEX] = get_limited_value(g);
    led_buffer[LED_B_INDEX] = get_limited_value(b);
}
void set_rgb_spark(int r, int g, int b, int period, int fre){
    int delta_t = period / fre / 2;
    set_rgb(r, g, b);
    delay(delta_t);
    set_rgb(0, 0, 0);
    delay(delta_t);
}
int spark_task_counter;
void set_rgb_spark_progressive_init(){
    spark_task_counter = 0;
}
void set_rgb_spark_progressive(int r, int g, int b, int period, int fre){
    //static int delta_t = 0;
    //if ( spark_task_counter == 0 ) delta_t = period / fre / 2;
    int delta_t = delta_t = period / fre / 2;
    spark_task_counter += 1;
    set_rgb(r, g, b);
    delay(delta_t/spark_task_counter + SPARK_PROGRESSIVE_TIME_LIMIT);
    set_rgb(0, 0, 0);
    delay(delta_t/spark_task_counter + SPARK_PROGRESSIVE_TIME_LIMIT);
}
/*
 * h = 0~360
 * s = 0~255
 * v = 0~100
 */
void set_hsv(int h, int s, int v){
    int r=0, g=0, b=0;
    int hi = (h / 60) % 6;
    int p = v * (255 - s) / HSV_V_MAX;
    int t = v * (255 - s * (60 - h % 60) / 60) / HSV_V_MAX;
    int q = v * (255 - (s * (h % 60) / 60 )) / HSV_V_MAX;
    v = v * 255 / 100;
    if (hi == 0)      { r = v; g = t; b = p; }
    else if (hi == 1) { r = q; g = v; b = p; }
    else if (hi == 2) { r = p; g = v; b = t; }
    else if (hi == 3) { r = p; g = q; b = v; }
    else if (hi == 4) { r = t; g = p; b = v; }
    else if (hi == 5) { r = v; g = p; b = q; }
    set_rgb(r, g, b);
    #ifdef DEBUGGER
    Serial.print("hi=");
    Serial.print(hi);
    Serial.print(" (h,s,v)=(");
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
}
void set_hsv_spark(int h, int s, int v, int period, int fre){
    int delta_t = period / fre / 2;
    set_hsv(h, s, v);
    delay(delta_t);
    set_rgb(0, 0, 0);
    delay(delta_t);
}
int hsv_task_counter;
void set_hsv_progressive_init(){
    hsv_task_counter = 0;
}
void set_hsv_progressive(int h_start, int h_end, int v, int period, int fre){
    static int h;
    int delta_t = period / fre / HSV_PROGRESSIVE_UPDATE_CYCLE; 
    if ( hsv_task_counter==0 ) h = h_start;
    h += (h_end - h_start) / HSV_PROGRESSIVE_UPDATE_CYCLE;
    if ( h_end > h_start && h > h_end ) h = h_start;
    else if ( h_end < h_start && h < h_end ) h = h_start;
    set_hsv(h, DEFAULT_HSV_S, v);
    delay(delta_t);
    hsv_task_counter++;
}
void set_hsv_spark_progressive(int h_start, int h_end, int v, int period, int fre){
    static int h;
    int delta_t = period / fre / HSV_PROGRESSIVE_UPDATE_CYCLE; 
    if ( hsv_task_counter==0 ) h = h_start;
    h += (h_end - h_start) / HSV_PROGRESSIVE_UPDATE_CYCLE;
    if ( h_end > h_start && h > h_end ) h = h_start;
    else if ( h_end < h_start && h < h_end ) h = h_start;
    
    hsv_task_counter++;
    set_hsv(h, DEFAULT_HSV_S, v);
    delay(delta_t);
    if ( hsv_task_counter % (HSV_PROGRESSIVE_UPDATE_CYCLE/32) == 0 ){
        set_rgb(0, 0, 0);
        delay(period/40);
    }
}
float HueToRGB(float v1, float v2, float vH)
{
  if (vH < 0)
    vH += 1;

  if (vH > 1)
    vH -= 1;

  if ((6 * vH) < 1)
    return (v1 + (v2 - v1) * 6 * vH);

  if ((2 * vH) < 1)
    return v2;

  if ((3 * vH) < 2)
    return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

  return v1;
};

void set_hsl(int H, float S, float L) {
  unsigned char R, G, B;

  if (S == 0)
  {
    R = G = B = (unsigned char)(L * 255);
  }
  else
  {
    float v1, v2;
    float hue = (float)H / 360;

    v2 = (L < 0.5) ? (L * (1 + S)) : ((L + S) - (L * S));
    v1 = 2 * L - v2;

    R = (unsigned char)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
    G = (unsigned char)(255 * HueToRGB(v1, v2, hue));
    B = (unsigned char)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
  }
  set_rgb(R, G, B);
};
void set_hsl_progressive(unsigned int index, int h, int s, int l, int colorTrans, int brightTrans){
    int n_h = h+colorTrans*index/1000;
    int n_l = l+brightTrans*index/1000;
    n_h = n_h%360;//(n_h<0)?0:(n_h>360?360:n_h);
    n_l = n_l%255;//(n_l<0)?0:(n_l>255?255:n_l);
    set_hsl(n_h, s/255.0, n_l/255.0);  // unit: H/1000s, L/1000s
}
