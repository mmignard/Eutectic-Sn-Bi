//read temperature of a K-type thermocouple probe using AD8495 amplifer and ADS1115 ADC

#include <Wire.h>
#define ADS1115_Address 0x48 // Device address in which is also included the 8th bit for selecting the mode, read in this case.
#define Conversion_Register 0x00 // Conversion Register
#define Config_Register 0x01 // Configuration Register
int adcMSB,adcLSB,adcVal;
float voltage,temperature;

void setup() {
  Wire.begin(); // Initiate the Wire library
  Serial.begin(9600);
  delay(100);
  
  // Enable continuous measurement
  Wire.beginTransmission(ADS1115_Address);
  Wire.write(Config_Register);
  Wire.write(0xc4);  
  Wire.write(0x03);  
  Wire.endTransmission();
  
  // Point to conversion register
  Wire.beginTransmission(ADS1115_Address);
  Wire.write(Conversion_Register);
  Wire.endTransmission();
}

void loop() {
  Wire.requestFrom(ADS1115_Address,2);
  
  if(Wire.available()<=2) {
    adcMSB = Wire.read();
    adcLSB = Wire.read();  
  }
  else{
    adcMSB = adcLSB = 0;
  }

  adcVal = 256*adcMSB + adcLSB;
  voltage = 2.048*adcVal/32676;
  temperature = (voltage - 1.25)/0.005;
  
  Serial.println(temperature);
  
  delay(1000);
}
