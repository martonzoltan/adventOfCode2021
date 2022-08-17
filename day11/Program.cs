using System;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    class Program
    {
        class Octopus
        {
            public int value { get; set; }
            public bool alreadyEmitedFlashed { get; set; }
            public bool alreadyReachedFlashValue { get; set; }
        }
        static Octopus[][] matrix = new Octopus[10][];
        static bool stillFlashing = true;
        static int flashCount = 0;
        static bool fullFlashFound = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting calculation...");
            Solve();
        }

        private static string[] GetInput()
        {
            var input = System.IO.File.ReadAllLines(@"input.txt");
            return input;
        }

        private static void Solve()
        {
            var input = GetInput();

            for (int i = 0; i < 10; i++)
            {
                matrix[i] = new Octopus[10];
                for (int j = 0; j < 10; j++)
                {
                    matrix[i][j] = new Octopus { value = (int)Char.GetNumericValue(input[i][j]), alreadyEmitedFlashed = false, alreadyReachedFlashValue = false };
                }
            }
            int steps = 1;
            while (!fullFlashFound)
            {
                ResetStep();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        IncreasePoz(i, j);
                    }
                }
                while (stillFlashing)
                {
                    stillFlashing = false;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (matrix[i][j].value == 0 && !matrix[i][j].alreadyEmitedFlashed)
                            {
                                FlashOctopus(i, j);
                            }
                        }
                    }
                }
                CheckIfAllFlash();
                if (fullFlashFound)
                {
                    break;
                }
                if (steps == 100)
                {
                    Console.WriteLine($"Part 1, total flashes: {flashCount} ");
                }
                steps++;
            }
            Console.WriteLine($"Part 2, step when all flash achieved: {steps} ");
        }

        private static void ResetStep()
        {
            stillFlashing = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    matrix[i][j].alreadyEmitedFlashed = false;
                    matrix[i][j].alreadyReachedFlashValue = false;
                }
            }
        }

        private static void CheckIfAllFlash()
        {
            bool allGood = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matrix[i][j].value != 0)
                    {
                        allGood = false;
                        break;
                    }
                }
                if (!allGood)
                {
                    break;
                }
            }
            if (allGood)
            {
                fullFlashFound = true;
            }
        }

        private static void FlashOctopus(int i, int j)
        {
            matrix[i][j].alreadyEmitedFlashed = true;
            //increase over
            if (i != 0 && !matrix[i - 1][j].alreadyReachedFlashValue)
            {
                IncreasePoz(i - 1, j);
                if (!matrix[i - 1][j].alreadyEmitedFlashed)
                {
                    stillFlashing = true;
                }
            }

            // increase below
            if (i != 9 && !matrix[i + 1][j].alreadyReachedFlashValue)
            {
                IncreasePoz(i + 1, j);
                if (!matrix[i + 1][j].alreadyEmitedFlashed)
                {
                    stillFlashing = true;
                }
            }

            // increase left
            if (j != 0 && !matrix[i][j - 1].alreadyReachedFlashValue)
            {
                IncreasePoz(i, j - 1);
                if (!matrix[i][j - 1].alreadyEmitedFlashed)
                {
                    stillFlashing = true;
                }
            }

            // increase right
            if (j != 9 && !matrix[i][j + 1].alreadyReachedFlashValue)
            {
                IncreasePoz(i, j + 1);
                if (!matrix[i][j + 1].alreadyEmitedFlashed)
                {
                    stillFlashing = true;
                }
            }

            // increase diagonal left top
            if (j != 0 && i != 0 && !matrix[i - 1][j - 1].alreadyReachedFlashValue)
            {
                IncreasePoz(i - 1, j - 1);
                if (!matrix[i - 1][j - 1].alreadyEmitedFlashed)
                {
                    stillFlashing = true;
                }
            }

            // increase diagonal left bottom
            if (j != 0 && i != 9 && !matrix[i + 1][j - 1].alreadyReachedFlashValue)
            {
                IncreasePoz(i + 1, j - 1);
                if (!matrix[i + 1][j - 1].alreadyEmitedFlashed)
                {
                    stillFlashing = true;
                }
            }

            // increase diagonal right top
            if (j != 9 && i != 0 && !matrix[i - 1][j + 1].alreadyReachedFlashValue)
            {
                IncreasePoz(i - 1, j + 1);
                if (!matrix[i - 1][j + 1].alreadyEmitedFlashed)
                {
                    stillFlashing = true;
                }
            }

            // increase diagonal left top
            if (j != 9 && i != 9 && !matrix[i + 1][j + 1].alreadyReachedFlashValue)
            {
                IncreasePoz(i + 1, j + 1);
                if (!matrix[i + 1][j + 1].alreadyEmitedFlashed)
                {
                    stillFlashing = true;
                }
            }
        }

        private static void IncreasePoz(int i, int j)
        {
            if (matrix[i][j].value == 9)
            {
                matrix[i][j].value = 0;
                matrix[i][j].alreadyReachedFlashValue = true;
                flashCount++;
            }
            else
            {
                matrix[i][j].value++;
            }
        }
    }
}
