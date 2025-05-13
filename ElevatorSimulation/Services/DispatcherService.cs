using ElevatorSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Services
{
    public class DispatcherService
    {
        private readonly List<Elevator> _elevators;

        public DispatcherService(List<Elevator> elevators)
        {
            _elevators = elevators;
        }

        public Elevator? AssignBestElevator(int requestedFloor)
        {
            // Filter available elevators
            var availableElevators = _elevators.Where(e => e.IsAvailable).ToList();

            if (!availableElevators.Any())
                return null;

            // Choose the closest elevator 
            return availableElevators
                .OrderBy(e => Math.Abs(e.CurrentFloor - requestedFloor))
                .First();
        }
    }
}