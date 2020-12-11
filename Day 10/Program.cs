using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var input = File.ReadLines("input.txt").Select(int.Parse).ToList();
//var input = File.ReadLines("exampleInput.txt").Select(int.Parse).ToList();

// Print answers
Console.WriteLine(Part1(input));
Console.WriteLine(Part2(input));

// Part 1
int Part1(IEnumerable<int> adapters)
{
    return int.MinValue;
}

// Part 2
int Part2(IEnumerable<int> adapters)
{
    return int.MinValue;
}