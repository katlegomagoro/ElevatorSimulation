using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ElevatorSimulation.Models;

namespace ElevatorSimulation.Services
{
    public static class PassengerRequestHandler
    {
        public static void BoardPassengers(Elevator elevator, int count)
        {
            if (count <= 0)
            {
                Console.WriteLine("Passenger count must be greater than 0.");
                return;
            }

            int availableSpace = Elevator.MaxCapacity - elevator.PassengerCount;

            if (count > availableSpace)
            {
                Console.WriteLine($"Only {availableSpace} passenger(s) can board Elevator {elevator.Id} (max capacity: {Elevator.MaxCapacity}).");
                elevator.PassengerCount += availableSpace;
            }
            else
            {
                elevator.PassengerCount += count;
                Console.WriteLine($"{count} passenger(s) boarded Elevator {elevator.Id}.");
            }
        }

        public static void UnloadPassengers(Elevator elevator)
        {
            Console.WriteLine($"Unloading {elevator.PassengerCount} passenger(s) from Elevator {elevator.Id}.");
            elevator.PassengerCount = 0;
        }
    }
}