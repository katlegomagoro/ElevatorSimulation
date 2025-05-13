using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Helpers
{
    public static class InputValidator
    {
        public static bool IsValidFloor(int floor, int maxFloors)
        {
            return floor >= 1 && floor <= maxFloors;
        }

        public static bool IsValidPassengerCount(int count)
        {
            return count > 0;
        }

        public static int PromptInt(string message)
        {
            int input;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
            }
            return input;
        }
    }
}
