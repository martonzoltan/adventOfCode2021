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
        }

        private static string[] GetInput()
        {
            var input = System.IO.File.ReadAllLines(@"input.txt");
            return input;
        }

        private static void FirstPart()
        {
            char[][] numbers = PrepareDiag();

            string number = "";
            for (int i = 0; i < 12; i++)
            {
                number += numbers[i].GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
            }
            string invertedData = new string(number.Select(ch => ch == '0' ? '1' : '0').ToArray());
            Console.WriteLine("Number:" + number);
            Console.WriteLine("Inverted:" + invertedData);
            Console.WriteLine("Result:" + Convert.ToInt32(invertedData, 2) * Convert.ToInt32(number, 2));
        }

        private static char[][] PrepareDiag()
        {
            var report = GetInput();
            char[][] numbers = new char[1000][];
            numbers[0] = new char[1000];
            numbers[1] = new char[1000];
            numbers[2] = new char[1000];
            numbers[3] = new char[1000];
            numbers[4] = new char[1000];
            numbers[5] = new char[1000];
            numbers[6] = new char[1000];
            numbers[7] = new char[1000];
            numbers[8] = new char[1000];
            numbers[9] = new char[1000];
            numbers[10] = new char[1000];
            numbers[11] = new char[1000];
            numbers[12] = new char[1000];

            int j = 0;

            foreach (var entry in report)
            {
                for (int i = 0; i < entry.Length; i++)
                {
                    numbers[i][j] = entry[i];
                }
                j++;
            }
            Console.WriteLine("Diagnostic numbers ready");
            return numbers;
        }
    }
}
