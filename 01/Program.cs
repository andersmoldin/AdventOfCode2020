using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Finds the two addends that adds up to 2020
/// </summary>
(int First, int Second) Find2020(List<int> addends)
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

//var expenseReport = File.ReadLines("exampleInput.txt").Select(int.Parse).ToList();
var expenseReport = File.ReadLines("input.txt").Select(int.Parse).ToList();

var addends = Find2020(expenseReport);

Console.WriteLine($"Part 1: {addends.First * addends.Second}");
Console.WriteLine($"Part 2: {addends.First * addends.Second}");