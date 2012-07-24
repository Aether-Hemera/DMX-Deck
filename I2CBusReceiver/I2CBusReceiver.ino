// Wire Slave Receiver
// by Nicholas Zambetti <http://www.zambetti.com>

// Demonstrates use of the Wire library
// Receives data as an I2C/TWI slave device
// Refer to the "Wire Master Writer" example for use with this

// Created 29 March 2006

// This example code is in the public domain.

#include <SoftPWM.h>
#include <Wire.h>

void setup()
{
  SoftPWMBegin();
  int iPin = 0;
  for (iPin = 0; iPin < 18; iPin++)
  {
    SoftPWMSet(iPin, 0);
    SoftPWMSetFadeTime(iPin, 100, 100);
  }
  
  Wire.begin(4);                // join i2c bus with address #4
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
    channel = channel - 18;  
    SoftPWMSet(channel, value);
  }
}
