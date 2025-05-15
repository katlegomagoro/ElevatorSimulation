using ElevatorSimulation.Models;
using ElevatorSimulation.Services;
using System;
using System.IO;
using Xunit;

namespace ElevatorSimulation.Tests.Services
{
    public class PassengerRequestHandlerTests
    {
        [Fact]
        public void BoardPassengers_AllPassengersFit_PrintsCorrectMessageAndUpdatesCount()
        {
            // Arrange
            var elevator = new Elevator { Id = 1, PassengerCount = 2 };
            int passengersToBoard = 3;

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            PassengerRequestHandler.BoardPassengers(elevator, passengersToBoard);

            // Assert
            Assert.Equal(5, elevator.PassengerCount);
            var output = sw.ToString();
            Assert.Contains("3 passenger(s) boarded Elevator 1", output);
        }

        [Fact]
        public void BoardPassengers_ExceedsCapacity_PrintsOnlyPartialBoarded()
        {
            // Arrange
            var elevator = new Elevator { Id = 2, PassengerCount = 9 };
            int passengersToBoard = 5;

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            PassengerRequestHandler.BoardPassengers(elevator, passengersToBoard);

            // Assert
            Assert.Equal(10, elevator.PassengerCount);
            var output = sw.ToString();
            Assert.Contains("Only 1 passenger(s) can board Elevator 2", output);
        }

        [Fact]
        public void BoardPassengers_ZeroPassengers_PrintsErrorAndDoesNotChangeState()
        {
            // Arrange
            var elevator = new Elevator { Id = 3, PassengerCount = 5 };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            PassengerRequestHandler.BoardPassengers(elevator, 0);

            // Assert
            Assert.Equal(5, elevator.PassengerCount);
            var output = sw.ToString();
            Assert.Contains("Passenger count must be greater than 0", output);
        }

        [Fact]
        public void UnloadPassengers_ResetsPassengerCountAndPrints()
        {
            var elevator = new Elevator { Id = 4, PassengerCount = 7 };

            using var sw = new StringWriter();
            Console.SetOut(sw);

        
            PassengerRequestHandler.UnloadPassengers(elevator);

            Assert.Equal(0, elevator.PassengerCount);
            var output = sw.ToString();
            Assert.Contains("Unloading 7 passenger(s) from Elevator 4", output);
        }
    }
}
