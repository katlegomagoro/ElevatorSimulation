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
        public static void MoveToFloor(Elevator elevator, int targetFloor, TextWriter? writer = null)
        {
            writer ??= Console.Out;

            if (elevator.CurrentFloor == targetFloor)
            {
                writer.WriteLine($"Elevator {elevator.Id} is already on Floor {targetFloor}.");
                return;
            }

            elevator.Direction = targetFloor > elevator.CurrentFloor
                ? ElevatorDirection.Up
                : ElevatorDirection.Down;

            writer.WriteLine($"Elevator {elevator.Id} moving {elevator.Direction}...");

            while (elevator.CurrentFloor != targetFloor)
            {
                elevator.CurrentFloor += elevator.Direction == ElevatorDirection.Up ? 1 : -1;
                writer.WriteLine($"Elevator {elevator.Id} now at Floor {elevator.CurrentFloor}");
                Thread.Sleep(100); 
            }

            elevator.Direction = ElevatorDirection.Idle;
            writer.WriteLine($"Elevator {elevator.Id} has arrived at Floor {targetFloor}");
        }
    }
}
