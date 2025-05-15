using ElevatorSimulation.Helpers;
using Xunit;

namespace ElevatorSimulation.Tests.Helpers
{
    public class InputValidatorTests
    {
        [Theory]
        [InlineData(1, 10, true)]
        [InlineData(5, 10, true)]
        [InlineData(10, 10, true)]
        [InlineData(0, 10, false)]
        [InlineData(11, 10, false)]
        public void IsValidFloor_ShouldValidateCorrectly(int floor, int max, bool expected)
        {
            var result = InputValidator.IsValidFloor(floor, max);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(5, true)]
        [InlineData(0, false)]
        [InlineData(-2, false)]
        public void IsValidPassengerCount_ShouldValidateCorrectly(int count, bool expected)
        {
            var result = InputValidator.IsValidPassengerCount(count);
            Assert.Equal(expected, result);
        }
    }
}
