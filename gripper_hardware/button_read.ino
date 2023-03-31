
// this constant won't change, for initialization 
const int buttonPin_1 = 2;  // the pin that the pushbutton is attached to
const int buttonPin_2 = 4;  // the pin that the pushbutton is attached to
const int ledPin = 13;    // the pin that the LED is attached to
int output_array[] = {1,2};

// Variables will change:
int buttonPushCounter_1 = 0;  // counter for the number of button presses
int buttonPushCounter_2 = 0;  // counter for the number of button presses
int buttonState_1 = 0;        // current state of the button
int buttonState_2 = 0;        // current state of the button
int lastButtonState_1 = 0;    // previous state of the button
int lastButtonState_2 = 0;    // previous state of the button

void setup() {
  // initialize the button pin as a input:
  pinMode(buttonPin_1, INPUT);
  pinMode(buttonPin_2, INPUT);
  // initialize the LED as an output:
  pinMode(ledPin, OUTPUT);
  // initialize serial communication:
  Serial.begin(9600);
}

void loop() {
  // read the pushbutton input pin:
  buttonState_1 = digitalRead(buttonPin_1);
  buttonState_2 = digitalRead(buttonPin_2);
  output_array[0] = buttonState_1;
  output_array[1] = buttonState_2;

  for (int i = 0; i < 2; i++) {
  Serial.print(output_array[i]);
  Serial.print(" ");
  }
  Serial.println(); // Print a newline character to start a new line
  delay(10); // Wait for 1 second before printing again
}




  