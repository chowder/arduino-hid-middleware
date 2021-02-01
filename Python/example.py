import sys
import time

from ArduinoHidMiddleware import Controller


def main():
    if len(sys.argv) < 2:
        print("Please specify the COM port name of the Arduino device.")
        return

    port_name = sys.argv[1]
    baud_rate = 9600
    print("Using COM port: %s, baud rate: %s" % (port_name, baud_rate))

    controller = Controller(port_name, baud_rate)

    numClicks = 5
    interval = 2

    print("Sending %s clicks, %s seconds in between." % (numClicks, interval))

    for _ in range(numClicks):
        time.sleep(interval)
        controller.mouse_down()
        controller.mouse_up()
        print("Click!")


if __name__ == "__main__":
    main()
