/*
  Blink
  Turns on an LED on for one second, then off for one second, repeatedly.
 
  This example code is in the public domain.
 */
 
// Pin 13 has an LED connected on most Arduino boards.
// give it a name:
int myPins[] = {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, A0, A1, A2, A3};
int i;
// the setup routine runs once when you press reset:
void setup() {                
  // initialize the digital pin as an output.
  for (i = 0; i < 16; i++){
    pinMode(myPins[i], OUTPUT);     
  }
}

// the loop routine runs over and over again forever:
void loop() {
  for (i = 0; i < 16; i++){
    digitalWrite(myPins[i], HIGH);   // turn the LED on (HIGH is the voltage level)
  }
  delay(2000);               // wait for a second
  for (i = 0; i < 16; i++){
    digitalWrite(myPins[i], LOW);    // turn the LED off by making the voltage LOW
  }
  delay(2000);               // wait for a second
}
