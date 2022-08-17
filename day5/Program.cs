using System;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    class Program
    {
        static int matrixSize = 1000;
        static int[][] matrix = new int[matrixSize][];

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
            for (int i = 0; i < matrixSize; i++)
            {
                matrix[i] = new int[matrixSize];
            }
            foreach (var line in input)
            {
                var coordinatePairs = line.Split(" -> ");
                int x1 = Convert.ToInt32(coordinatePairs[0].Split(",")[0]);
                int y1 = Convert.ToInt32(coordinatePairs[0].Split(",")[1]);
                int x2 = Convert.ToInt32(coordinatePairs[1].Split(",")[0]);
                int y2 = Convert.ToInt32(coordinatePairs[1].Split(",")[1]);
                if (x1 == x2)
                {
                    for (int i = Math.Min(y1, y2); i <= Math.Max(y1, y2); i++)
                    {
                        matrix[i][x1]++;
                    }
                }
                if (y1 == y2)
                {
                    for (int i = Math.Min(x1, x2); i <= Math.Max(x1, x2); i++)
                    {
                        matrix[y1][i]++;
                    }
                }
                if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
                {
                    var holder = x1;
                    x1 = y1;
                    y1 = holder;
                    holder = x2;
                    x2 = y2;
                    y2 = holder;

                    if (x1 < x2 && y1 < y2)
                    {
                        var diagonalStepper = y1;
                        for(int i = x1; i <= x2 ; i++)
                        {
                            matrix[i][diagonalStepper]++;
                            diagonalStepper++;
                        }
                    }

                    if (x1 > x2 && y1 < y2)
                    {
                        var diagonalStepper = y1;
                        for(int i = x1; i >= x2 ; i--)
                        {
                            matrix[i][diagonalStepper]++;
                            diagonalStepper++;
                        }
                    }

                    if (x1 < x2 && y1 > y2)
                    {
                        var diagonalStepper = y1;
                        for(int i = x1; i <= x2 ; i++)
                        {
                            matrix[i][diagonalStepper]++;
                            diagonalStepper--;
                        }
                    }

                    if (x1 > x2 && y1 > y2)
                    {
                        var diagonalStepper = y1;
                        for(int i = x1; i >= x2 ; i--)
                        {
                            matrix[i][diagonalStepper]++;
                            diagonalStepper--;
                        }
                    }
                }
            }
            //PrintMatrix();
            CheckResults();
        }

        static void CheckResults()
        {
            int counter = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[i][j] >= 2)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine($"Total crossing: {counter}");
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine("");
            }
        }



    }
}
