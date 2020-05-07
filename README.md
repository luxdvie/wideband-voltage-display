# Wideband Voltage Display

This project consists of an Arduino sketch that reads voltage in (0-5v) and communicates with a .NET WinForms app on a Windows PC to display a number that represents this value in the range of 9-19

From the Digital Wideband's documentation, it outputs a value:
> Analog 0-5V Linear Range is 9-19 AFR 0V = 9 AFR 5V = 19 AFR

See the [WB D1 Digital Wideband WBO Controller Module (Board)](https://www.wide-band.com/product-p/wb_d1diy.htm?fbclid=IwAR1HxyFk0bE6KYueTIFYDgQe6jiabUKki9khknbDLKLF-AkUgwS7NVnc5vw) for more information on this device.

# Goals

The serial output of the Wideband is too slow. Do the following:

-  Write Arduino sketch to read analog voltage
   -  Read voltage in 0-5v
   -  Report via Serial Port
-  Write a Windows App to show a voltage reading value
   -  Maps 0-5 to 9-19
   -  Option to "Stay On Top" always
   -  Select COM Port
   -  Connect/Disconnect COM Port
   -  Full Screen (voltage display) mode

# Requirements

-  Windows Application
   -  To run: Windows Operating System, .NET Framework 4.5
   -  To build/modify: Windows Operating System, Visual Studio 2017
-  Arduino Sketch
   -  Arduino Uno or compatible

# Author

Austin Brown [GitHub](https://github.com/luxdvie),  [austinbrown2500@gmail.com](mailto:austinbrown2500@gmail.com)

# License: The MIT License

Copyright 2020 Austin Brown

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.