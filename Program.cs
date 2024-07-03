// Justin Harris 
// CISS 311 - Advanced Agile Software Development 
// Dropbox 4 - Driving Game. 
// Columbia College of Missouri 
// July 2nd, 2024

/*
 * DrivingGame
 * This simple console game simulates a driving experience where the player controls a vehicle
 * navigating through an endless road filled with other vehicles. The player's vehicle can move
 * left and right, accelerate, and brake using the arrow keys. Random computer-controlled vehicles
 * continuously appear at the top of the screen and move downward. The player's objective is to avoid
 * collisions with these computer vehicles while maintaining control of their own speed and position.
 * The game runs in an infinite loop, constantly refreshing the screen to create the illusion of movement.
 * Each iteration of the loop checks for user input, updates the positions of all vehicles, and handles
 * collision detection. If a collision is detected, the player's vehicle responds appropriately.
 * 
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace DrivingGame
{
    public class Program
    {
        static void Main()
        {
            // Hide the cursor for a better visual experience
            Console.CursorVisible = false;

            // Define the width of the road
            const int ROAD_WIDTH = 20;

            // Initialize the player's vehicle
            Vehicle playerVehicle = new Vehicle(10, 20, '^', ConsoleColor.Green, 0);
            // Vehicle computerVehicle = new Vehicle
            //         (10, 0, '8', ConsoleColor.Green, 0);

            // Initialize a random number generator and a list for computer vehicles
            Random random = new Random();
            List<Vehicle> list = new List<Vehicle>();

            // Main game loop
            while (true)
            {
                // Clear the console screen
                Console.Clear();

                // Add a new computer vehicle at a random X position at the top of the screen
                int newXPosition = random.Next(ROAD_WIDTH);
                Vehicle vehicle = new Vehicle(newXPosition, 0, '8', ConsoleColor.Green, 0);
                list.Add(vehicle);

                // Update and display each computer vehicle in the list
                foreach (var computerVehicle in list)
                {
                    // Check for collision
                    if (playerVehicle.XPosition == computerVehicle.XPosition &&
                        playerVehicle.YPosition == computerVehicle.YPosition)
                    {
                        playerVehicle.Collide();
                    }

                    // Move the computer's vehicle down the screen
                    if (computerVehicle.YPosition < Console.WindowHeight - 1)
                        computerVehicle.YPosition++;
                    else
                        computerVehicle.YPosition = 1;

                    // Display the computer's vehicle
                    computerVehicle.Display();
                }

                // Display the player's vehicle
                playerVehicle.Display();

                // Handle user input
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        // Move player vehicle left if it's not at the edge
                        if (playerVehicle.XPosition > 0)
                            playerVehicle.MoveLeft();
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        // Move player vehicle right if it's not at the edge
                        if (playerVehicle.XPosition + 1 < ROAD_WIDTH)
                            playerVehicle.MoveRight();
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        // Increase speed if it's below the maximum limit
                        if (playerVehicle.Speed + 10 < 200)
                            playerVehicle.Accelerate();
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        // Decrease speed if it's above the minimum limit
                        if (playerVehicle.Speed - 10 > 0)
                            playerVehicle.Brake();
                    }
                }

                // Control the game speed based on the player's vehicle speed
                Thread.Sleep(200 - playerVehicle.Speed);
            }
        }
    }
}
