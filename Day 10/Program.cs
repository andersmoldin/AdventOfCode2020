using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var input = File.ReadLines("input.txt").Select(int.Parse).OrderBy(a => a).ToArray();
//var input = File.ReadLines("exampleInput.txt").Select(int.Parse).OrderBy(a => a).ToArray();
//var input = File.ReadLines("exampleInput2.txt").Select(int.Parse).OrderBy(a => a).ToArray();

// Print answers
Console.WriteLine(Part1(input));
Console.WriteLine(Part2(input));

// Part 1
int Part1(int[] adapters)
{
    var differences = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 1 } };

    for (int i = 0; i < adapters.Length; i++)
    {
        if (i == 0)
        {
            differences[Math.Abs(0 - adapters[i])]++;
        }
        else
        {
            differences[Math.Abs(adapters[i - 1] - adapters[i])]++;
        }
    }

    return differences.Where(d => d.Value > 0).Select(d => d.Value).Aggregate((a, b) => a * b);
}

// Part 2
int Part2(IEnumerable<int> adapters)
{
    return int.MinValue;
}