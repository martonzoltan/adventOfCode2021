using System;
using System.Collections.Generic;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting calculation...");
            FirstPart();
            SecondPart();
        }

        private static string[] GetInput()
        {
            var input = System.IO.File.ReadAllLines(@"input.txt");
            return input;
        }

        private static void FirstPart()
        {
            var listOfDepth = GetInput();
            int counter = 0;
            int prevDepth = 36000;
            foreach (var entry in listOfDepth)
            {
                int parsedEntry = Int32.Parse(entry);
                if (parsedEntry > prevDepth)
                {
                    counter++;
                }
                prevDepth = parsedEntry;
            }
            Console.WriteLine("Depth increases: " + counter);
        }

        private static void SecondPart()
        {
            var listOfDepth = GetInput();
            List<int> slidingValues = new List<int>();
            for (int i = 0; i < listOfDepth.Length - 2; i++)
            {
                int firstNumber = Int32.Parse(listOfDepth[i]);
                int secondNumber = Int32.Parse(listOfDepth[i + 1]);
                int thirdNumber = Int32.Parse(listOfDepth[i + 2]);
                slidingValues.Add(firstNumber + secondNumber + thirdNumber);
            }
            int counter = 0;
            int prevDepth = 36000;
            foreach (var entry in slidingValues)
            {
                if (entry > prevDepth)
                {
                    counter++;
                }
                prevDepth = entry;
            }
            Console.WriteLine("Rolling depth increases: " + counter);
        }
    }
}
