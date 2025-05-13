using ElevatorSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Services
{
    public static class ElevatorController
    {
        public static void MoveToFloor(Elevator elevator, int targetFloor)
        {
            if (elevator.CurrentFloor == targetFloor)
            {
                Console.WriteLine($"Elevator {elevator.Id} is already on Floor {targetFloor}.");
                return;
            }

            // Set direction based on target
            elevator.Direction = targetFloor > elevator.CurrentFloor
                ? ElevatorDirection.Up
                : ElevatorDirection.Down;

            Console.WriteLine($"Elevator {elevator.Id} moving {elevator.Direction}...");

            // Simulate step- by step movement
            while (elevator.CurrentFloor != targetFloor)
            {
                elevator.CurrentFloor += elevator.Direction == ElevatorDirection.Up ? 1 : -1;
                Console.WriteLine($"Elevator {elevator.Id} now at Floor {elevator.CurrentFloor}");
                Thread.Sleep(300); // simulate delay between floors
            }

            // Arrived
            elevator.Direction = ElevatorDirection.Idle;
            Console.WriteLine($"Elevator {elevator.Id} has arrived at Floor {targetFloor}");
        }
    }
}
