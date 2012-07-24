// Wire Master Writer
// by Nicholas Zambetti <http://www.zambetti.com>

// Demonstrates use of the Wire library
// Writes data to an I2C/TWI slave device
// Refer to the "Wire Slave Receiver" example for use with this

// Created 29 March 2006

// This example code is in the public domain.

#include <Wire.h>
#include <SoftPWM.h>



void setup()
{
  Serial.begin(115200); // 9600; 57600
  Serial.println();
  Serial.println("Bus");
  
  Wire.begin(); // join i2c bus (address optional for master)
  
  SoftPWMBegin();
  int iPin = 0;
  for (iPin = 0; iPin < 18; iPin++)
  {
    SoftPWMSet(iPin, 0);
    SoftPWMSetFadeTime(iPin, 100, 100);
  }
}

const byte dim_curve[] = {
    0,   1,   1,   2,   2,   2,   2,   2,   2,   3,   3,   3,   3,   3,   3,   3,
    3,   3,   3,   3,   3,   3,   3,   4,   4,   4,   4,   4,   4,   4,   4,   4,
    4,   4,   4,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   6,   6,   6,
    6,   6,   6,   6,   6,   7,   7,   7,   7,   7,   7,   7,   8,   8,   8,   8,
    8,   8,   9,   9,   9,   9,   9,   9,   10,  10,  10,  10,  10,  11,  11,  11,
    11,  11,  12,  12,  12,  12,  12,  13,  13,  13,  13,  14,  14,  14,  14,  15,
    15,  15,  16,  16,  16,  16,  17,  17,  17,  18,  18,  18,  19,  19,  19,  20,
    20,  20,  21,  21,  22,  22,  22,  23,  23,  24,  24,  25,  25,  25,  26,  26,
    27,  27,  28,  28,  29,  29,  30,  30,  31,  32,  32,  33,  33,  34,  35,  35,
    36,  36,  37,  38,  38,  39,  40,  40,  41,  42,  43,  43,  44,  45,  46,  47,
    48,  48,  49,  50,  51,  52,  53,  54,  55,  56,  57,  58,  59,  60,  61,  62,
    63,  64,  65,  66,  68,  69,  70,  71,  73,  74,  75,  76,  78,  79,  81,  82,
    83,  85,  86,  88,  90,  91,  93,  94,  96,  98,  99,  101, 103, 105, 107, 109,
    110, 112, 114, 116, 118, 121, 123, 125, 127, 129, 132, 134, 136, 139, 141, 144,
    146, 149, 151, 154, 157, 159, 162, 165, 168, 171, 174, 177, 180, 183, 186, 190,
    193, 196, 200, 203, 207, 211, 214, 218, 222, 226, 230, 234, 238, 242, 248, 255,
};

void getRGB(int hue, int sat, int val, int colors[3]) { 
  /* convert hue, saturation and brightness ( HSB/HSV ) to RGB
     The dim_curve is used only on brightness/value and on saturation (inverted).
     This looks the most natural.      
  */

  val = dim_curve[val];
  sat = 255-dim_curve[255-sat];

  int r;
  int g;
  int b;
  int base;

  if (sat == 0) { // Acromatic color (gray). Hue doesn't mind.
    colors[0]=val;
    colors[1]=val;
    colors[2]=val;  
  } else  { 

    base = ((255 - sat) * val)>>8;

    switch(hue/60) {
    case 0:
        r = val;
        g = (((val-base)*hue)/60)+base;
        b = base;
    break;

    case 1:
        r = (((val-base)*(60-(hue%60)))/60)+base;
        g = val;
        b = base;
    break;

    case 2:
        r = base;
        g = val;
        b = (((val-base)*(hue%60))/60)+base;
    break;

    case 3:
        r = base;
        g = (((val-base)*(60-(hue%60)))/60)+base;
        b = val;
    break;

    case 4:
        r = (((val-base)*(hue%60))/60)+base;
        g = base;
        b = val;
    break;

    case 5:
        r = val;
        g = base;
        b = (((val-base)*(60-(hue%60)))/60)+base;
    break;
    }

    colors[0]=r;
    colors[1]=g;
    colors[2]=b; 
  }   
}



int ColorHSV(int h, double s, double v, int rgb) {
  //this is the algorithm to convert from RGB to HSV
  double r=0; 
  double g=0; 
  double b=0;

  double hf=h/60.0;

  int i=(int)floor(h/60.0);
  double f = h/60.0 - i;
  double pv = v * (1 - s);
  double qv = v * (1 - s*f);
  double tv = v * (1 - s * (1 - f));

  switch (i)
  {
  case 0: //rojo dominante
    r = v;
    g = tv;
    b = pv;
    break;
  case 1: //verde
    r = qv;
    g = v;
    b = pv;
    break;
  case 2: 
    r = pv;
    g = v;
    b = tv;
    break;
  case 3: //azul
    r = pv;
    g = qv;
    b = v;
    break;
  case 4:
    r = tv;
    g = pv;
    b = v;
    break;
  case 5: //rojo
    r = v;
    g = pv;
    b = qv;
    break;
  }

  //set each component to a integer value between 0 and 255
  int red=constrain((int)255*r,0,255);
  int green=constrain((int)255*g,0,255);
  int blue=constrain((int)255*b,0,255);
  
  switch (rgb)
  {
    case 1:
      return red;
    case 2:
      return green;      
    case 3:
      return blue;
    default:
      return 0;
  }
  return 0;
}

byte x = 0;

int value = 0;
byte channel;

byte channelR = 0;
byte channelG = 0;
byte channelB = 0;


int GotSerial = 0;
int iCol = 0;
int bEcho = 0;

byte Ports[] = {
  33,32,34,
  27,20,21,
  30,28,29,
  22,24,23,
  25,31,26,
  7,8,6,
  15,17,16,
  10,2,3,
  13,11,12,
  4,9,5
  };

void SetChannel(byte Channel, byte Value)
{
  if (bEcho == 1)
  {
    Serial.print(Channel);
    Serial.print(": ");
    Serial.print(Value);
    Serial.print(" ");
  }
  // DmxSimple.write(channel, value);
  
  if (Channel < 18) // pins 0 & 1 are for serial ; 2 to 13 and A0 to A3 (i.e. 14, 15, 16, 17) are also PWM ; above that then send to slaves
  {
    SoftPWMSet(Channel, Value);
  }
  else
  {
    Wire.beginTransmission(4); // transmit to device #4    
    Wire.write(Channel);              // sends one byte  
    Wire.write(Value);              // sends one byte  
    Wire.endTransmission();    // stop transmitting
  }
}


void DoColors()
{
  byte red = (byte)ColorHSV(iCol, 1.0, 1.0, 1);
  byte green = (byte)ColorHSV(iCol, 1.0, 1.0, 2);
  byte blue = (byte)ColorHSV(iCol, 1.0, 1.0, 3);
   
  int iChIndex = 0;
  for (iChIndex = 0; iChIndex < 30; )
  {
    SetChannel(Ports[iChIndex++], red);
    SetChannel(Ports[iChIndex++], green);
    SetChannel(Ports[iChIndex++], blue);
  }
}

void loop()
{
  int c;
  long LoopCount = 0;
  
  while(!Serial.available())
  {
    if (GotSerial == 0)
    {
      LoopCount++;
      if (LoopCount > 6000)
      {
        iCol++;
        if (iCol > 359)
          iCol = 0;
        DoColors();
        LoopCount = 0;
      }
    }
  }
  GotSerial = 1;
  c = Serial.read();
  if ((c>='0') && (c<='9')) {
    value = 10*value + c - '0'; // shift ten and add value
  } else {
    if (c=='c') // sets the channel for Value
      channel = value;
    else if (c=='r') 
      channelR = value;
    else if (c=='g') 
      channelG = value;
    else if (c=='b') 
      channelB = value;
    else if (c=='v') { // sets the value
      SetChannel(channel, value); 
    }
    else if (c=='h') {
      /*
      byte red = (byte)ColorHSV(value, 1.0, 1.0, 1);
      byte green = (byte)ColorHSV(value, 1.0, 1.0, 2);
      byte blue = (byte)ColorHSV(value, 1.0, 1.0, 3);
      SetChannel(channelR, red);
      SetChannel(channelG, green);
      SetChannel(channelB, blue);
      */
      int rgb_colors[3];   
      getRGB(value,255,255,rgb_colors);   // converts HSB to RGB
      SetChannel(channelR, rgb_colors[0]);
      SetChannel(channelG, rgb_colors[1]);
      SetChannel(channelB, rgb_colors[2]);
    }
    else if (c=='e') {
      bEcho = 1;
      Serial.print("echo on ");
    }
    else if (c=='o') {
      bEcho = 0;
      Serial.print("echo off ");
    }
    value = 0;
  }
}
