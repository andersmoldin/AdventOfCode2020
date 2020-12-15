using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//var input = File.ReadLines("input.txt").ToArray();
var input = File.ReadLines("exampleInput.txt").ToArray();

// Print answers
Console.WriteLine(Part1(input));
Console.WriteLine(Part2(input));

// Part 1
int Part1(string[] sequence)
{
    var positionAndDirection = (X: 0, Y: 0, Direction: 'E');

    foreach (var actionAndValue in sequence)
    {
        positionAndDirection = Move(positionAndDirection, actionAndValue);
    }

    return int.MinValue;
}

// Part 2
int Part2(string[] sequence)
{
    return int.MinValue;
}

(int X, int Y, char Direction) Move((int X, int Y, char Direction) currentState, string actionAndValue)
{
    var action = actionAndValue.Substring(0, 1);

    switch (action)
    {
        case "F":

            break;
        case "L":
        case "R":
            currentState.Direction = Turn(currentState, action);
            break;
        
    }

    return (0, 0, 'E');
}

char Turn((int X, int Y, char Direction) currentState, string action)
{
    // Need to mod 90 on value to know how far to turn
    return currentState.Direction switch
    {
        'E' => action == "L" ? 'N' : 'S',
        'S' => action == "L" ? 'E' : 'W',

    };
}

