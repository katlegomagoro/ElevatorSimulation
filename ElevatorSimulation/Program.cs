using ElevatorSimulation.Models;
using ElevatorSimulation.Services;
using ElevatorSimulation.UI;

namespace ElevatorSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int TOTAL_FLOORS = 10;
            const int TOTAL_ELEVATORS = 3;
            bool systemActive = true;

            // Initialize elevators
            List<Elevator> elevators = new();
            for (int i = 1; i <= TOTAL_ELEVATORS; i++)
            {
                elevators.Add(new Elevator
                {
                    Id = i,
                    CurrentFloor = 1,
                    Direction = ElevatorDirection.Idle,
                    PassengerCount = 0
                });
            }

            // Initialize services
            var dispatcher = new DispatcherService(elevators);
            var ui = new ConsoleUI();

            ui.InitializeDisplay();
            Console.WriteLine($"System initialized with {TOTAL_ELEVATORS} elevators serving {TOTAL_FLOORS} floors.\n");

            // Main loop
            while (systemActive)
            {
                ui.DisplayElevatorStatus(elevators);

                Console.WriteLine("Enter 'CALL' to request elevator or 'EXIT' to stop simulation:");
                string? command = Console.ReadLine()?.Trim().ToUpper();

                if (command == "CALL")
                {
                    ui.HandleElevatorRequest(elevators, dispatcher, TOTAL_FLOORS);
                }
                else if (command == "EXIT")
                {
                    systemActive = false;
                    Console.WriteLine("Shutting down elevator system. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid command. Please enter 'CALL' or 'EXIT'.");
                }
            }
        }
    }
}
