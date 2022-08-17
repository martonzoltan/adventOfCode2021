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
            FirstPart();
            //SecondPart();
        }

        private static string GetInput()
        {
            var input = System.IO.File.ReadAllLines(@"input.txt");
            return input[0];
        }

        private static void FirstPart()
        {
            var input = GetInput();
            var fishNumbers = input.Split(",").Select(Int32.Parse).ToList();
            int day = 0;
            while (day < 80)
            {
                List<int> newDay = new List<int>();
                int newBabiesToday = 0;
                foreach (var item in fishNumbers)
                {
                    if (item == 0)
                    {
                        newDay.Add(8);
                        newBabiesToday++;
                    }
                    else
                    {
                        newDay.Add(item - 1);
                    }
                }
                newDay.AddRange(Enumerable.Repeat(6, newBabiesToday));
                day++;
                fishNumbers = newDay;
                Console.WriteLine(day);

            }
            Console.WriteLine(fishNumbers.Count());
        }

        private static void SecondPart()
        {

        }
    }
}
