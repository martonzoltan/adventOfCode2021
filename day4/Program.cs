using System;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    class Program
    {
        const string calls = "31,50,79,59,39,53,58,95,92,55,40,97,81,22,69,26,6,23,3,29,83,48,18,75,47,49,62,45,35,34,1,88,54,16,56,77,28,94,52,15,0,87,93,90,60,67,68,85,80,51,20,96,61,66,63,91,8,99,70,13,71,17,7,38,44,43,5,25,72,2,57,33,82,78,89,21,30,11,73,84,4,46,14,19,12,10,42,32,64,98,9,74,86,27,24,65,37,41,76,36";
        
        //const string calls ="7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1";
        static List<(int, bool)[,]> allBoards = new List<(int, bool)[,]>();
        static int lastCompletedChecksum = 0;

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
            var boards = GetInput();

            var numbers = calls.Split(",").Select(Int32.Parse).ToList();
            var board = new (int, bool)[5, 5];
            var lineNumber = 0;
            foreach (var line in boards)
            {
                if (line != "")
                {
                    var currentLine = line.Split(" ").Where(x => x != "").ToArray();
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        board[lineNumber, i] = (Convert.ToInt32(currentLine[i]), false);
                    }
                    lineNumber++;
                }
                else
                {
                    allBoards.Add(board);
                    board = new (int, bool)[5, 5];
                    lineNumber = 0;
                }
            }
            foreach (var number in numbers)
            {
                MarkNumberOnBoards(number);
                Console.WriteLine(number);
                int completedCheck = CheckIfComplete();
                if (completedCheck != -1)
                {
                    lastCompletedChecksum = number * completedCheck;
                }
            }
            Console.WriteLine(lastCompletedChecksum);
            //PrintBoards();
        }

        private static int CheckIfComplete()
        {
            foreach (var board in allBoards)
            {
                bool bingo = true;

                // Check horizontal
                for (int i = 0; i < 5; i++)
                {
                    bingo = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (!board[i, j].Item2)
                        {
                            bingo = false;
                            break;
                        }
                    }
                    if (bingo)
                    {
                        break;
                    }
                }
                if (bingo)
                {
                    int boardSum = CalcBoardSum(board);
                        allBoards.Remove(board);
                    return boardSum;
                }

                // Check vertical
                for (int i = 0; i < 5; i++)
                {
                    bingo = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (!board[j, i].Item2)
                        {
                            bingo = false;
                            break;
                        }
                    }
                    if (bingo)
                    {
                        break;
                    }
                }
                if (bingo)
                {
                    int boardSum = CalcBoardSum(board);
                        allBoards.Remove(board);
                    return boardSum;
                }
            }
            return -1;
        }

        private static int CalcBoardSum((int, bool)[,] board)
        {
            int boardScore = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!board[i, j].Item2)
                    {
                        boardScore += board[i, j].Item1;
                    }
                }
            }
            return boardScore;
        }

        private static void MarkNumberOnBoards(int number)
        {
            foreach (var board in allBoards)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i, j].Item1 == number)
                        {
                            board[i, j].Item2 = true;
                        }
                    }
                }
            }
        }

        private static void PrintBoards()
        {
            foreach (var board in allBoards)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write($"{board[i, j].Item1} ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
    }
}
