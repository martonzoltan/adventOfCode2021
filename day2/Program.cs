using System;
using System.Collections.Generic;

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

        private static string[] GetInput()
        {
            var input = System.IO.File.ReadAllLines(@"input.txt");
            return input;
        }

        private static void FirstPart()
        {
            var listOfInstructions = GetInput();
            int horizontal = 0;
            int depth = 0;
            foreach (var entry in listOfInstructions)
            {
                var instruction = entry.Split(" ")[0];
                int value = Int32.Parse(entry.Split(" ")[1]);
                if (instruction == "forward")
                {
                    horizontal += value;
                }
                if (instruction == "down")
                {
                    depth += value;
                }
                if (instruction == "up")
                {
                    depth -= value;
                }
            }
            Console.WriteLine("Depth: " + depth);
            Console.WriteLine("Horizontal pos: " + horizontal);
            Console.WriteLine("Value = " + depth * horizontal);
        }

        private static void SecondPart()
        {
            var listOfInstructions = GetInput();
            int horizontal = 0;
            int aim = 0;
            int depth = 0;
            foreach (var entry in listOfInstructions)
            {
                var instruction = entry.Split(" ")[0];
                int value = Int32.Parse(entry.Split(" ")[1]);
                if (instruction == "forward")
                {
                    horizontal += value;
                    if (aim > 0)
                    {
                        depth += aim * value;
                    }
                }
                if (instruction == "down")
                {
                    aim += value;
                }
                if (instruction == "up")
                {
                    aim -= value;
                }
            }
            Console.WriteLine("Depth: " + depth);
            Console.WriteLine("Horizontal pos: " + horizontal);
            Console.WriteLine("Value = " + depth * horizontal);

        }
    }
}
