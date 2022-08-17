using System;
using System.Collections.Generic;
using System.Linq;

namespace day1
{
    class Program
    {
        static string polymer = "SCVHKHVSHPVCNBKBPVHV";
        static Dictionary<string, string> coding = new Dictionary<string, string>();
        static int steps = 1;

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
            foreach (var line in input)
            {
                coding.Add(line.Split(" -> ")[0], line.Split(" -> ")[1]);
            }

            string newPolymer = string.Empty;
            while (steps <= 40)
            {
                for (int i = 0; i < polymer.Length - 1; i++)
                {
                    var firstLetter = polymer[i];
                    var secondLetter = polymer[i + 1];
                    string currentPair = $"{firstLetter}{secondLetter}";
                    var middleLetter = coding[currentPair];
                    newPolymer += firstLetter + middleLetter;
                }
                newPolymer += polymer[polymer.Length - 1];
                polymer = newPolymer;
                newPolymer = string.Empty;
                steps++;
                Console.WriteLine(steps);
            }
            var mostOccurance = polymer.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();
            var leastOccurance = polymer.GroupBy(x => x).OrderBy(x => x.Count()).FirstOrDefault();
            Console.WriteLine(mostOccurance.Count() - leastOccurance.Count());
        }
    }
}
