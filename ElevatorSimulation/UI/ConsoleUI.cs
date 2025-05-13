using ElevatorSimulation.Helpers;
using ElevatorSimulation.Models;
using ElevatorSimulation.Services;

namespace ElevatorSimulation.UI
{
    public class ConsoleUI
    {
        public void InitializeDisplay()
        {
            Console.WriteLine("Welcome to the Elevator Simulation");
            Console.WriteLine("----------------------------------");
        }

        public void DisplayElevatorStatus(List<Elevator> elevators)
        {
            Console.WriteLine("\n--- Elevator Status ---");
            foreach (var elevator in elevators)
            {
                Console.WriteLine(elevator.ToString());
            }
            Console.WriteLine();
        }

        public void HandleElevatorRequest(List<Elevator> elevators, DispatcherService dispatcher, int totalFloors)
        {
            // Prompt for floor input
            int currentFloor;
            do
            {
                currentFloor = InputValidator.PromptInt($"Enter your current floor (1 - {totalFloors}):");
            } while (!InputValidator.IsValidFloor(currentFloor, totalFloors));

            // Prompt for number of passengers
            int passengerCount;
            do
            {
                passengerCount = InputValidator.PromptInt("Enter number of passengers:");
            } while (!InputValidator.IsValidPassengerCount(passengerCount));

            // Assign best elevator
            var bestElevator = dispatcher.AssignBestElevator(currentFloor);
            if (bestElevator == null)
            {
                Console.WriteLine("No available elevators. Please wait...");
                return;
            }

            Console.WriteLine($"Elevator {bestElevator.Id} is arriving at Floor {currentFloor}...");
            ElevatorController.MoveToFloor(bestElevator, currentFloor);
            PassengerRequestHandler.BoardPassengers(bestElevator, passengerCount);

            // Prompt for destination floor
            int destinationFloor;
            do
            {
                destinationFloor = InputValidator.PromptInt($"Enter destination floor (1 - {totalFloors}):");
            } while (!InputValidator.IsValidFloor(destinationFloor, totalFloors));

            ElevatorController.MoveToFloor(bestElevator, destinationFloor);
            PassengerRequestHandler.UnloadPassengers(bestElevator);
        }
    }
}