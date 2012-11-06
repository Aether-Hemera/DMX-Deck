/* This program allows you to set DMX channels over the serial port.
**
** After uploading to Arduino, switch to Serial Monitor and set the baud rate
** to 9600. You can then set DMX channels using these commands:
**
** <number>c : Select DMX channel
** <number>v : Set DMX channel to new value
**
** These can be combined. For example:
** 100c355w : Set channel 100 to value 255.
**
** For more details, and compatible Processing sketch,
** visit http://code.google.com/p/tinkerit/wiki/SerialToDmx
**
** Help and support: http://groups.google.com/group/dmxsimple       */

#include <DmxSimple.h>

void setup() {
  Serial.begin(115200);
  Serial.println();
  Serial.println("SerialToDmx ready");
  Serial.println();
  Serial.println("Syntax:");
  Serial.println(" e    : Echo on");
  Serial.println(" o    : Echo off");
  Serial.println(" 123c : use DMX channel 123");
  Serial.println(" 45v  : set current channel to value 45");
  
  
  DmxSimple.usePin(7);
  for (int iCh = 1; iCh <= 255; iCh++)
  {
    DmxSimple.write(iCh, 0);
  }
}

int value = 0;
int channel;
int bEcho = 0;

void loop() {
  int c;

  while(!Serial.available());
  c = Serial.read();
  if ((c>='0') && (c<='9')) {
    value = 10*value + c - '0'; // shift ten and add value
  } else {
    if (c=='c') // sets the channel to be written at the specificed value received
		channel = value;
    else if (c=='v') {
		if (bEcho == 1)
	  	{
			Serial.print(channel);
			Serial.print(": ");
			Serial.print(value);
			Serial.print(" ");
		}
      	DmxSimple.write(channel, value);
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
