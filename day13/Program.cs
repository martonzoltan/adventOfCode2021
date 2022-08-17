using System;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    class Program
    {
        static int matrixRows = 895;
        static int matrixColumns = 1311;
        static int[][] matrix = new int[matrixRows][];
        static List<(string, int)> folds = new List<(string, int)> { ("x", 655), ("y", 447), ("x", 327), ("y", 223), ("x", 163), ("y", 111), ("x", 81), ("y", 55), ("x", 40), ("y", 27), ("y", 13), ("y", 6) };
        static int xFolds = 1;
        static int yFolds = 1;

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
            InitMatrix();
            foreach (var line in input)
            {
                int xCoord = Convert.ToInt32(line.Split(",")[0]);
                int yCoord = Convert.ToInt32(line.Split(",")[1]);
                matrix[yCoord][xCoord]++;
            }
            foreach (var fold in folds)
            {
                if (fold.Item1 == "x")
                {
                    for (int i = 0; i < matrixRows / yFolds; i++)
                    {
                        for (int j = fold.Item2 + 1; j < matrixColumns / xFolds; j++)
                        {
                            if (matrix[i][j] == 1)
                            {
                                var stepleft = j - fold.Item2;
                                matrix[i][j - stepleft * 2] = 1;
                            }
                        }
                    }
                    xFolds *= 2;
                }

                if (fold.Item1 == "y")
                {
                    for (int i = fold.Item2 + 1; i < matrixRows / yFolds; i++)
                    {
                        for (int j = 0; j < matrixColumns / xFolds; j++)
                        {
                            if (matrix[i][j] == 1)
                            {
                                var stepUp = i - fold.Item2;
                                matrix[i - stepUp * 2][j] = 1;
                            }
                        }
                    }
                    yFolds *= 2;
                }
            }
            PrintMatrix();
            CountDots();
        }

        private static void CountDots()
        {
            var counter = 0;
            for (int i = 0; i < matrixRows / yFolds; i++)
            {
                for (int j = 0; j < matrixColumns / xFolds; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine($"Number of dots: {counter}");
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrixRows / yFolds; i++)
            {
                for (int j = 0; j < matrixColumns / xFolds; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        Console.Write("|");

                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }

        private static void InitMatrix()
        {
            for (int i = 0; i < matrixRows; i++)
            {
                matrix[i] = new int[matrixColumns];
            }
        }
    }
}
