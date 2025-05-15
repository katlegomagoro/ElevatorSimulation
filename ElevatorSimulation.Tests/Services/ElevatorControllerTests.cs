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
            // Arrange
            var elevator = new Elevator { Id = 1, CurrentFloor = 1, Direction = ElevatorDirection.Down };

            // Act
            ElevatorController.MoveToFloor(elevator, 4);

            // Assert
            Assert.Equal(4, elevator.CurrentFloor);
            Assert.Equal(ElevatorDirection.Idle, elevator.Direction);
        }

        [Fact]
        public void MoveToFloor_ShouldNotChangePassengerCount()
        {
            // Arrange
            var elevator = new Elevator { Id = 1, CurrentFloor = 2, PassengerCount = 3 };

            // Act
            ElevatorController.MoveToFloor(elevator, 5);

            // Assert
            Assert.Equal(3, elevator.PassengerCount);
        }
    }
}