using System;
using System.Threading;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please specify the COM port name of the Arduino device.");
                return;
            }

            var portName = args[0];
            const int baudRate = 9600;
            var controller = new ArduinoHidMiddleware.Controller(portName, baudRate);

            Console.WriteLine($"Using COM port: {portName}, baud rate: {baudRate}");

            const int numClicks = 5;
            const int interval = 2;
            
            Console.WriteLine($"Sending {numClicks} clicks, {interval} seconds in between.");

            for (var i = 0; i < numClicks; i++)
            {
                Thread.Sleep(interval * 1000);
                controller.MouseDown();
                controller.MouseUp();
                Console.WriteLine("Click!");
            }
        }
    }
}