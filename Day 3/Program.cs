using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt");
            //var input = File.ReadLines("exampleInput.txt");

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/3
        /// </summary>
        private static int Part1(IEnumerable<string> input)
        {
            int counter = 0;

            for (int row = 0; row < input.Count(); row++)
            {
                counter = counter + (input.ElementAt(row)[row * 3 % input.ElementAt(0).Length] == '#' ? 1 : 0);
            }

            return counter;
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/3#part2
        /// </summary>
        private static int Part2(IEnumerable<string> input)
        {
            var counter = new Dictionary<int, int>() { { 11, 0 }, { 12, 0 }, { 31, 0 }, { 51, 0 }, { 71, 0 } };

            for (int row = 0; row < input.Count(); row++)
            {
                counter[11] = counter[11] + (input.ElementAt(row)[row * 1 % input.ElementAt(0).Length] == '#' ? 1 : 0);
                counter[31] = counter[31] + (input.ElementAt(row)[row * 3 % input.ElementAt(0).Length] == '#' ? 1 : 0);
                counter[51] = counter[51] + (input.ElementAt(row)[row * 5 % input.ElementAt(0).Length] == '#' ? 1 : 0);
                counter[71] = counter[71] + (input.ElementAt(row)[row * 7 % input.ElementAt(0).Length] == '#' ? 1 : 0);

                if (row % 2 == 0)
                {
                    counter[12] = counter[12] + (input.ElementAt(row)[row / 2 % input.ElementAt(0).Length] == '#' ? 1 : 0);
                }
            }

            return counter.Select(v => v.Value).Aggregate((a, b) => a * b);
        }
    }
}
