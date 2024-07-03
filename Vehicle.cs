using System;

namespace DrivingGame
{
    internal class Vehicle
    {
        // Auto Implement Properties 
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public char VehicleSymbol { get; set; }
        public ConsoleColor VehicleColor { get; set; }
        public int Speed { get; set; }

        // Constructor 
        public Vehicle(int xPosition, int yPosition, char vehicleSymbol, ConsoleColor vehicleColor, int speed)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            VehicleSymbol = vehicleSymbol;
            VehicleColor = vehicleColor;
            Speed = speed;
        }

        // Methods 
        public void MoveLeft()
        {
            XPosition--;
        }

        public void MoveRight()
        {
            XPosition++;
        }
        public void Accelerate()
        {
            Speed += 10;
        }
        public void Brake()
        {
            Speed -= 10;
        }
        public void Display()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ForegroundColor = VehicleColor;
            Console.Write(VehicleSymbol);
        }
        public void Collide()
        {
        Console.SetCursorPosition(XPosition,YPosition);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
            Console.SetCursorPosition(XPosition + 2, YPosition);
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("Accident\nPress Enter to Quit.");
            Console.WriteLine();
            Environment.Exit(0);
        }

    }
}
