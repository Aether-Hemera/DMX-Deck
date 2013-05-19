// I2CBus receiver (Aether & Hemera)
// This code is in the public domain

// This code is based on the original source of 
// Wire Slave Receiver
// by Nicholas Zambetti <http://www.zambetti.com>

#include <SoftPWM.h>
#include <Wire.h>

#define BOARDNUMBER 2

void setup()
{
  SoftPWMBegin();
  int iPin = 0;
  for (iPin = 0; iPin < 18; iPin++)
  {
    SoftPWMSet(iPin, 0);
    SoftPWMSetFadeTime(iPin, 100, 100);
  }
  
  Wire.begin(BOARDNUMBER);      // join i2c bus with address #BOARDNUMBER
  Wire.onReceive(receiveEvent); // register event
}

void loop()
{
  delay(1000);
}

// function that executes whenever data is received from master
// this function is registered as an event, see setup()
void receiveEvent(int howMany)
{
  while (Wire.available() > 1)
  {
    byte channel = Wire.read();    // receive byte 
    byte value = Wire.read();    // receive byte 
    SoftPWMSet(channel, value);
  }
}
