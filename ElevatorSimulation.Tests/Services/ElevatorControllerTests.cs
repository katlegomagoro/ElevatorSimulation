using ElevatorSimulation.Models;
using ElevatorSimulation.Services;
using Xunit;

namespace ElevatorSimulation.Tests.Services
{
    public class ElevatorControllerTests
    {
        [Theory]
        [InlineData(3, 5, ElevatorDirection.Up)]
        [InlineData(7, 2, ElevatorDirection.Down)]
        [InlineData(4, 4, ElevatorDirection.Idle)]
        public void GetDirectionToFloor_ReturnsCorrectDirection(int from, int to, ElevatorDirection expected)
        {
            // Arrange
            var elevator = new Elevator { Id = 1, CurrentFloor = from };

            // Act
            var actual = ElevatorController.GetDirectionToFloor(elevator, to);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MoveToFloor_ShouldUpdateCurrentFloor_AndResetDirection()
        {
            var elevator = new Elevator { Id = 1, CurrentFloor = 1, Direction = ElevatorDirection.Down };
            var output = new StringWriter();

            ElevatorController.MoveToFloor(elevator, 4, output); 

            Assert.Equal(4, elevator.CurrentFloor);
            Assert.Equal(ElevatorDirection.Idle, elevator.Direction);
        }


        [Fact]
        public void MoveToFloor_ShouldNotChangePassengerCount()
        {
            var elevator = new Elevator { Id = 1, CurrentFloor = 2, PassengerCount = 3 };

            using var output = new StringWriter();
            Console.SetOut(output);

            ElevatorController.MoveToFloor(elevator, 5);

            Assert.Equal(3, elevator.PassengerCount);
        }

    }
}