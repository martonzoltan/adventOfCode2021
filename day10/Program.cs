using System;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    class Program
    {
        static char[] openning = { '(', '[', '{', '<' };
        static List<long> scores = new List<long>();
        static int total = 0;
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
            foreach (var line in input)
            {
                long lineScore = 0;
                Stack<char> stackLine = new Stack<char>();
                bool good = true;

                foreach (char charachter in line)
                {
                    if (openning.Contains(charachter))
                    {
                        stackLine.Push(charachter);
                    }
                    else
                    {
                        var topToMatch = stackLine.Peek();
                        switch (charachter)
                        {
                            case ')':
                                if (topToMatch != '(')
                                {
                                    good = false;
                                    total += 3;
                                }
                                break;
                            case ']':
                                if (topToMatch != '[')
                                {
                                    good = false;
                                    total += 57;
                                }
                                break;
                            case '}':
                                if (topToMatch != '{')
                                {
                                    good = false;
                                    total += 1197;
                                }
                                break;
                            case '>':
                                if (topToMatch != '<')
                                {
                                    good = false;
                                    total += 25137;
                                }
                                break;
                        }
                        if (!good)
                        {
                            Console.WriteLine("Expected to close: " + topToMatch + " Found: " + charachter);
                            break;
                        }
                        else
                        {
                            stackLine.Pop();
                        }
                    }
                }
                if (!good)
                {
                    continue;
                }

                while (stackLine.Count != 0)
                {
                    switch (stackLine.Pop())
                    {
                        case '(': lineScore = lineScore * 5 + 1; break;
                        case '[': lineScore = lineScore * 5 + 2; break;
                        case '{': lineScore = lineScore * 5 + 3; break;
                        case '<': lineScore = lineScore * 5 + 4; break;
                    }
                }

                scores.Add(lineScore);
            }
            Console.WriteLine("Corrupted score: " + total);
            Console.WriteLine("Completed score: " + scores.OrderBy(x => x).Skip(scores.Count / 2).First());
        }
        private static void SecondPart()
        {

        }
    }
}
