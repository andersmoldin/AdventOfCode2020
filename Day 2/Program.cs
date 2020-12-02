using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_2
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
        /// https://adventofcode.com/2020/day/2
        /// </summary>
        private static int Part1(IEnumerable<string> input)
        {
            var pattern = @"(\d+)\-(\d+)\ ([a-z])\:\ ([a-z]+)";

            var codesFlattened = input
                .Select(i => Regex.Match(i, pattern).Groups)
                .Select(g => new
                {
                    Min = Convert.ToInt32(g[1].Value),
                    Max = Convert.ToInt32(g[2].Value),
                    Letter = Convert.ToChar(g[3].Value),
                    Code = g[4].Value
                })
                .Count(c => c.Min <= c.Code.Count(f => f == c.Letter) &&
                            c.Max >= c.Code.Count(f => f == c.Letter));

            return codesFlattened;
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/2#part2
        /// </summary>
        private static int Part2(IEnumerable<string> input)
        {
            var pattern = @"(\d+)\-(\d+)\ ([a-z])\:\ ([a-z]+)";

            var codesFlattened = input
                .Select(i => Regex.Match(i, pattern).Groups)
                .Select(g => new
                {
                    Pos1 = Convert.ToInt32(g[1].Value),
                    Pos2 = Convert.ToInt32(g[2].Value),
                    Letter = Convert.ToChar(g[3].Value),
                    Code = g[4].Value
                })
                .Count(c => (c.Code[c.Pos1 - 1] == c.Letter && c.Code[c.Pos2 - 1] != c.Letter) ||
                (c.Code[c.Pos2 - 1] == c.Letter && c.Code[c.Pos1 - 1] != c.Letter));

            return codesFlattened;
        }
    }
}
