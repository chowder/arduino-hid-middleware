using System.IO.Ports;

namespace ArduinoHidMiddleware
{
    public class Controller
    {
        public enum Action : byte
        {
            MouseDown = 1,
            MouseUp = 2
        }
        
        private SerialPort SerialPort { get; }

        /// <summary>
        /// Creates an Arduino HID middleware controller.
        /// </summary>
        /// <param name="portName">The COM port name to connect to.</param>
        /// <param name="baudRate">The baud rate of the connection.</param>
        public Controller(string portName, int baudRate = 9600)
        {
            SerialPort = new SerialPort(portName, baudRate, Parity.None);
            SerialPort.Open();
        }

        ~Controller() => SerialPort.Close();

        /// <summary>
        /// Sends a controller action across the COM port.
        /// </summary>
        /// <param name="action">The action to send across the COM port.</param>
        public void Send(Action action)
        {
            SerialPort.Write(AsBuffer(action), 0, 1);
        }

        /// <summary>
        /// Sends a MOUSE_DOWN command
        ///
        /// This is equivalent to Controller.Send(Controller.Action.MouseDown);
        /// </summary>
        public void MouseDown()
        {
            Send(Action.MouseDown);
        }

        /// <summary>
        /// Sends a MOUSE_UP command
        ///
        /// This is equivalent to Controller.Send(Controller.Action.MouseUp);
        /// </summary>
        public void MouseUp()
        {
            Send(Action.MouseUp);
        }
        
        private static byte[] AsBuffer(Action action)
        {
            return new[] {(byte) action};
        }
    }
}