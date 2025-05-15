using ElevatorSimulation.Models;
using System;
using System.Threading;

namespace ElevatorSimulation.Services
{
    public static class ElevatorController
    {
        // Pure helper for direction
        public static ElevatorDirection GetDirectionToFloor(Elevator elevator, int targetFloor)
        {
            if (targetFloor > elevator.CurrentFloor)
                return ElevatorDirection.Up;
            else if (targetFloor < elevator.CurrentFloor)
                return ElevatorDirection.Down;
            else
                return ElevatorDirection.Idle;
        }

        // Actual movement 
        public static void MoveToFloor(Elevator elevator, int targetFloor)
        {
            if (elevator.CurrentFloor == targetFloor)
            {
                Console.WriteLine($"Elevator {elevator.Id} is already on Floor {targetFloor}.");
                return;
            }

            elevator.Direction = GetDirectionToFloor(elevator, targetFloor);
            Console.WriteLine($"Elevator {elevator.Id} moving {elevator.Direction}...");

            while (elevator.CurrentFloor != targetFloor)
            {
                elevator.CurrentFloor += elevator.Direction == ElevatorDirection.Up ? 1 : -1;
                Console.WriteLine($"Elevator {elevator.Id} now at Floor {elevator.CurrentFloor}");
                Thread.Sleep(300);
            }

            elevator.Direction = ElevatorDirection.Idle;
            Console.WriteLine($"Elevator {elevator.Id} has arrived at Floor {targetFloor}");
        }
    }
}
