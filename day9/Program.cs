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
            int[][] matrix = new int[100][];

            int currentLine = 0;
            foreach (var line in input)
            {
                matrix[currentLine] = new int[100];
                matrix[currentLine] = Array.ConvertAll(line.ToCharArray(), c => (int)Char.GetNumericValue(c));
                currentLine++;
            }
            int counter = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    bool good = true;
                    if (i != 0 && matrix[i - 1][j] <= matrix[i][j])
                    {
                        good = false;
                    }
                    if (i != 99 && matrix[i + 1][j] <= matrix[i][j])
                    {
                        good = false;
                    }
                    if (j != 0 && matrix[i][j - 1] <= matrix[i][j])
                    {
                        good = false;
                    }
                    if (j != 99 && matrix[i][j + 1] <= matrix[i][j])
                    {
                        good = false;
                    }
                    if (good)
                    {
                        counter += matrix[i][j] + 1;
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
