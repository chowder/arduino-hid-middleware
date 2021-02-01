import serial


class Action:
    MOUSE_DOWN = 1
    MOUSE_UP = 2


class Controller:
    def __init__(self, port_name: str, baud_rate: int):
        self.serial_port = serial.Serial(port_name, baud_rate)

    def send(self, action: Action):
        packet = action.to_bytes(1, byteorder='little')
        self.serial_port.write(packet)
        pass

    def mouse_down(self):
        self.send(Action.MOUSE_DOWN)

    def mouse_up(self):
        self.send(Action.MOUSE_UP)
