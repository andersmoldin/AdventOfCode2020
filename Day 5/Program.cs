using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadLines("input.txt").Select(int.Parse).ToList();
            var input = File.ReadLines("exampleInput.txt").Select(int.Parse).ToList();

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/5
        /// </summary>
        private static int Part1(IEnumerable<int> input)
        {
            return int.MinValue;
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/5#part2
        /// </summary>
        private static int Part2(IEnumerable<int> input)
        {
            return int.MinValue;
        }
    }
}
