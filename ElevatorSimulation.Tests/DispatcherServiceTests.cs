using ElevatorSimulation.Models;
using ElevatorSimulation.Services;
using Xunit;

namespace ElevatorSimulation.Tests
{
    public class DispatcherServiceTests
    {
        [Fact]
        public void AssignBestElevator_ShouldHandleMultipleScenariosCorrectly()
        {
            
            var elevators1 = new List<Elevator>
            {
                new Elevator { Id = 1, CurrentFloor = 1, PassengerCount = 0 },
                new Elevator { Id = 2, CurrentFloor = 5, PassengerCount = 0 },
                new Elevator { Id = 3, CurrentFloor = 10, PassengerCount = Elevator.MaxCapacity }
            };
            var dispatcher1 = new DispatcherService(elevators1);
            var result1 = dispatcher1.AssignBestElevator(3);
            Assert.NotNull(result1);
            Assert.Equal(1, result1.Id); 

            
            var elevators2 = new List<Elevator>
            {
                new Elevator { Id = 1, CurrentFloor = 2, PassengerCount = Elevator.MaxCapacity },
                new Elevator { Id = 2, CurrentFloor = 6, PassengerCount = Elevator.MaxCapacity }
            };
            var dispatcher2 = new DispatcherService(elevators2);
            var result2 = dispatcher2.AssignBestElevator(4);
            Assert.Null(result2); 

           
            var elevators3 = new List<Elevator>
            {
                new Elevator { Id = 1, CurrentFloor = 4, PassengerCount = 0 },
                new Elevator { Id = 2, CurrentFloor = 2, PassengerCount = 0 }
            };
            var dispatcher3 = new DispatcherService(elevators3);
            var result3 = dispatcher3.AssignBestElevator(4);
            Assert.NotNull(result3);
            Assert.Equal(1, result3.Id);

           
            var elevators4 = new List<Elevator>
            {
                new Elevator { Id = 1, CurrentFloor = 3, PassengerCount = 0 },
                new Elevator { Id = 2, CurrentFloor = 5, PassengerCount = 0 }
            };
            var dispatcher4 = new DispatcherService(elevators4);
            var result4 = dispatcher4.AssignBestElevator(4);
            Assert.NotNull(result4);
            Assert.Equal(1, result4.Id); 

            
            var elevators5 = new List<Elevator>
            {
                new Elevator { Id = 1, CurrentFloor = 3, PassengerCount = Elevator.MaxCapacity },
                new Elevator { Id = 2, CurrentFloor = 2, PassengerCount = 2 } 
            };
            var dispatcher5 = new DispatcherService(elevators5);
            var result5 = dispatcher5.AssignBestElevator(4);
            Assert.NotNull(result5);
            Assert.Equal(2, result5.Id); 
        }
    }
}
