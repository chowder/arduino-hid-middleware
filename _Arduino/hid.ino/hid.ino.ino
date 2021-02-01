#include "Mouse.h"

enum Command {
  MOUSE_DOWN = 1,
  MOUSE_UP = 2,
};

void setup() {
  Serial.begin(9600);
  Mouse.begin();
}

void loop() {
  if (Serial.available() > 0) {
    byte in_byte = Serial.read();
    switch (in_byte) {
      case MOUSE_DOWN: 
        Mouse.press(MOUSE_LEFT);
        break;
      case MOUSE_UP:
        Mouse.release(MOUSE_LEFT);
        break;
    }
  }
}
