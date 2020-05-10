/*
  Report voltage from 0-5v to serial port
  https://github.com/luxdvie/wideband-voltage-display
  Austin Brown [GitHub](https://github.com/luxdvie),  [austinbrown2500@gmail.com](mailto:austinbrown2500@gmail.com)
*/

void setup() {
  pinMode(LED_BUILTIN, OUTPUT);
  Serial.begin(9600);
  blink(); // Blink on setup to indicate successful boot
}

void loop() {
  sendData();
  delay(150); // data refresh speed
}

// Reads the voltage on A0 and returns a float between 0.00 and 5.00
// https://www.arduino.cc/en/Tutorial/ReadAnalogVoltage
float readVoltage() {
  int sensorValue = analogRead(A0);
  float voltage = sensorValue * (5.0 / 1023.0);
  if (voltage <= 0.00) {
    return 0.00; // never allow a value of less than 0
  }
  
  return min(voltage, 5.00); // never allow a value of greater than 5.00
}

// Writes data to the serial port
void sendData() {
  // Send simple JSON data now so that we can easily add new data in future
  Serial.print("{\"Voltage\": \""); // begin JSON
  Serial.print(readVoltage()); // actual voltage reading
  Serial.println("\"}"); // end JSON
}

// Takes 1 second and blinks the LED: On, Off, On
// Leaves the LED in the ON state 
void blink() {
  digitalWrite(LED_BUILTIN, HIGH);
  delay(500);
  digitalWrite(LED_BUILTIN, LOW);
  delay(500);
  digitalWrite(LED_BUILTIN, HIGH);
}
