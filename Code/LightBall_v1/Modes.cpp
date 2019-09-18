#include "Modes.h"
#include "Essentials.h"
//#define DEBUGGER
/* check the value always limited in MIN ~ MAX */
uint8 inline get_limited_value(uint8 v){
    return (char)(v<LIMITED_MIN) ? LIMITED_MIN : ( (v>LIMITED_MAX) ? LIMITED_MAX : v );
}
void set_rgb(uint8 r, uint8 g, uint8 b){
    led_buffer[LED_R_INDEX] = get_limited_value(r);
    led_buffer[LED_G_INDEX] = get_limited_value(g);
    led_buffer[LED_B_INDEX] = get_limited_value(b);
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
void set_hsl_progressive(uint24 index, uint16 duration, 
                         uint8 h, uint8 s, uint8 l, 
                         uint8 colorTrans, uint8 brightTrans, 
                         uint8 count, uint8 duty){
    set_hsl_spark_async(index, duration, h, s, l,
                         colorTrans, brightTrans, 1, 255);
}
/* The starting color will change continuously. */
void set_hsl_spark_async(uint24 index, uint16 duration, 
                         uint8 h, uint8 s, uint8 l, 
                         uint8 colorTrans, uint8 brightTrans, 
                         uint8 count, uint8 duty){
    int n_h = h+colorTrans*index/1000;
    int n_l = l+brightTrans*index/1000;
    uint16 size = duration/count;       //Frame size
    if (255*(index%size)/size < duty){  //In range of duty
      n_h %= 360; n_l %= 255;
      set_hsl(n_h, s/255.0, n_l/255.0);  // unit: H/1000s, L/1000s
    }
    else
      set_rgb(0, 0, 0);
}
/* Each starting color is the same. */
void set_hsl_spark_sync(uint24 index, uint16 duration, 
                         uint8 h, uint8 s, uint8 l, 
                         uint8 colorTrans, uint8 brightTrans, 
                         uint8 count, uint8 duty){
    uint16 size = duration/count;       //Frame size
    if (255*(index%size)/size < duty){  //In range of duty
      int n_h = h+colorTrans*(index%size)/1000;
      int n_l = l+brightTrans*(index%size)/1000;
      n_h %= 360; n_l %= 255;
      set_hsl(n_h, s/255.0, n_l/255.0);  // unit: H/1000s, L/1000s
    }
    else
      set_rgb(0, 0, 0);
}
/* Each cycle has there own fading rate.
   And the brights fade automatically. */
void set_hsl_meteor_async(uint24 index, uint16 duration, 
                         uint8 h, uint8 s, uint8 l, 
                         uint8 colorTrans, uint8 meteorTrans, 
                         uint8 count, uint8 duty){
    int n_h = h+colorTrans*index/1000;
    uint16 size = duration/count;       //Frame size
    if (255*(index%size)/size < duty){  //In range of duty
      n_h += meteorTrans*(index%size)/1000;
      n_h %= 360;
      set_hsl(n_h, s/255.0, (float)(index%size)/size);  // unit: H/1000s, L/1000s
    }
    else
      set_rgb(0, 0, 0);
}
/* The starting color of each cycle is the same.
   And the brights fade automatically. */
void set_hsl_meteor_sync(uint24 index, uint16 duration, 
                         uint8 h, uint8 s, uint8 l, 
                         uint8 colorTrans, uint8 meteorTrans, 
                         uint8 count, uint8 duty){
    uint16 size = duration/count;       //Frame size
    if (255*(index%size)/size < duty){  //In range of duty
      int n_h = h+meteorTrans*(index%size)/1000;
      n_h %= 360;
      set_hsl(n_h, s/255.0, (float)(index%size)/size);  // unit: H/1000s, L/1000s
    }
    else
      set_rgb(0, 0, 0);
}
