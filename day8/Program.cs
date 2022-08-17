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

        private static string[] GetInput()
        {
            var input = System.IO.File.ReadAllLines(@"input.txt");
            return input;
        }

        private static void FirstPart()
        {
            var input = GetInput();
            int counter = 0;
            foreach (var item in input)
            {
                var codeList = item.Split("|")[1].Split(" ").ToList();
                int[] lengthsToCheck = new int[] { 2, 4, 3, 7 };
                foreach (var code in codeList)
                {
                    if (lengthsToCheck.Contains(code.Length))
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
        private static void SecondPart()
        {

        }
    }
}
