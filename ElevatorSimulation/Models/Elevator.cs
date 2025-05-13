using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Models
{
    public class Elevator
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; } = 1;
        public ElevatorDirection Direction { get; set; } = ElevatorDirection.Idle;
        public int PassengerCount { get; set; } = 0;
        public const int MaxCapacity = 10;

        public bool IsAvailable => PassengerCount < MaxCapacity;

        public override string ToString()
        {
            return $"Elevator {Id}: Floor {CurrentFloor}, Direction: {Direction}, Passengers: {PassengerCount}";
        }
    }
}
