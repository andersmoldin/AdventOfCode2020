using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Finds the two addends that adds up to 2020
/// </summary>
(int First, int Second) FindTwoAddends(List<int> addends)
{
    for (int first = 0; first < addends.Count; first++)
    {
        for (int second = 0; second < first + 1; second++)
        {
            if (addends[first] + addends[second] == 2020)
            {
                return (addends[first], addends[second]);
            }
        }
    }

    throw new Exception("Could not find addends that equals 2020.");
}

/// <summary>
/// Finds the two addends that adds up to 2020
/// </summary>
(int First, int Second, int Third) FindThreeAddends(List<int> addends)
{
    for (int first = 0; first < addends.Count; first++)
    {
        for (int second = 0; second < first + 1; second++)
        {
            for (int third = 0; third < second + 1; third++)
            {
                if (addends[first] + addends[second] + addends[third] == 2020)
                {
                    return (addends[first], addends[second], addends[third]);
                }
            }
        }
    }

    throw new Exception("Could not find addends that equals 2020.");
}

// Example data and input data from https://adventofcode.com/2020/day/1
//var expenseReport = File.ReadLines("exampleInput.txt").Select(int.Parse).ToList();
var expenseReport = File.ReadLines("input.txt").Select(int.Parse).ToList();

//Run methods to find addends of 2020
var twoAddends = FindTwoAddends(expenseReport);
var threeAddends = FindThreeAddends(expenseReport);

//Print results
Console.WriteLine($"Part 1: {twoAddends.First * twoAddends.Second}");
Console.WriteLine($"Part 2: {threeAddends.First * threeAddends.Second * threeAddends.Third}");