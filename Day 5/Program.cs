using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt").ToList();
            //var input = File.ReadLines("exampleInput.txt").ToList();

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/5
        /// </summary>
        private static int Part1(IEnumerable<string> boardingPasses)
        {
            return boardingPasses.Max(CalculateSeatId);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/5#part2
        /// </summary>
        private static int Part2(IEnumerable<string> boardingPasses)
        {
            var seatIds = boardingPasses.Select(CalculateSeatId);
            var emptySeat = Enumerable.Range(seatIds.Min(), seatIds.Count()).Except(seatIds).Single();
            return emptySeat;
        }


        // Make recursive?
        static int CalculateSeatId(string seat)
        {
            var rowBits = seat.Substring(0, 7);
            var columnBits = seat.Substring(7, 3);

            var row = BinarySpacePartitioning(rowBits, 0, 127, 64);
            var column = BinarySpacePartitioning(columnBits, 0, 7, 4);

            return row * 8 + column;

            int BinarySpacePartitioning(string rowBits, int min, int max, int stepCounter)
            {
                for (int i = 0; i < rowBits.Length; i++)
                {
                    switch (rowBits[i])
                    {
                        case 'F':
                        case 'L':
                            max -= stepCounter;
                            break;
                        case 'B':
                        case 'R':
                            min += stepCounter;
                            break;
                    }

                    stepCounter /= 2;
                }

                return min;
            }
        }
    }
}
