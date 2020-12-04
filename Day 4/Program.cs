using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllText("input.txt").Split(new string[] { "\n\n" }, StringSplitOptions.None).ToList();
            var input = File.ReadAllText("exampleInput.txt").Split(new string[] { "\n\n" }, StringSplitOptions.None).ToList();

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/4
        /// </summary>
        private static int Part1(IEnumerable<string> input)
        {
            return input
                .Where(p => p.Contains("byr:") &&
                            p.Contains("iyr:") &&
                            p.Contains("eyr:") &&
                            p.Contains("hgt:") &&
                            p.Contains("hcl:") &&
                            p.Contains("ecl:") &&
                            p.Contains("pid:"))
                .Count();
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/4#part2
        /// </summary>
        private static int Part2(IEnumerable<string> input)
        {
            return input
                .Where(p =>
                {
                    var parts = p.Split(new string[] { " ", "\n" }, StringSplitOptions.None);


                    return true;
                })
                .Count();
        }
    }
}
