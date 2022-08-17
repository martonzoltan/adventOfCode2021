using System;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting calculation...");
            //FirstPart();
            SecondPart();
        }

        private static string GetInput()
        {
            var input = System.IO.File.ReadAllLines(@"input.txt");
            return input[0];
        }

        private static void FirstPart()
        {
            var input = GetInput();
            var submarinePozitions = input.Split(",").Select(Int32.Parse).ToList();
            int bestPosition = Convert.ToInt32(submarinePozitions.Average());
            int avgPoz = bestPosition;
            int bestFuelConsumption = CalculateFuelConsumption(submarinePozitions, bestPosition);
            while (true)
            {
                int tempPoz = bestPosition - 1;
                int tempFuel = CalculateFuelConsumption(submarinePozitions, tempPoz);
                if (tempFuel < bestFuelConsumption)
                {
                    bestFuelConsumption = tempFuel;
                    bestPosition--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"Best pos: {bestPosition} , Fuel: {bestFuelConsumption}");
        }

        private static int CalculateFuelConsumption(List<int> submarinePozitions, int bestPosition)
        {
            int fuel = 0;
            foreach (var item in submarinePozitions)
            {
                fuel += Math.Abs(item - bestPosition);
            }
            return fuel;
        }

        private static int CalculateFuelConsumptionSecondPart(List<int> submarinePozitions, int bestPosition)
        {
            int fuel = 0;
            foreach (var item in submarinePozitions)
            {
                int numberOfMovements = Math.Abs(item - bestPosition);
                fuel += (numberOfMovements * (numberOfMovements + 1)) / 2;
            }
            return fuel;
        }

        private static void SecondPart()
        {
            var input = GetInput();
            var submarinePozitions = input.Split(",").Select(Int32.Parse).ToList();
            int bestPosition = Convert.ToInt32(submarinePozitions.Average());
            int avgPoz = bestPosition;
            int bestFuelConsumption = CalculateFuelConsumptionSecondPart(submarinePozitions, bestPosition);
            while (true)
            {
                int tempPoz = bestPosition - 1;
                int tempFuel = CalculateFuelConsumptionSecondPart(submarinePozitions, tempPoz);
                if (tempFuel < bestFuelConsumption)
                {
                    bestFuelConsumption = tempFuel;
                    bestPosition--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"Best pos: {bestPosition} , Fuel: {bestFuelConsumption}");
        }
    }
}
