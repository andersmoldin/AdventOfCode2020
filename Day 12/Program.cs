using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

//var input = File.ReadLines("input.txt").Select(l => (Action: l.Substring(0, 1), Value: Convert.ToInt32(l.Substring(1)))).ToArray();
var input = File.ReadLines("exampleInput.txt").Select(l => (Action: l.Substring(0, 1), Value: Convert.ToInt32(l.Substring(1)))).ToArray();

// Print answers
Console.WriteLine((int)Direction.North + 1);
Console.WriteLine(Part1(input));
Console.WriteLine(Part2(input));

// Part 1
int Part1((string Action, int Value)[] sequence)
{
    var currentPositionAndDirection = (X: 0, Y: 0, Direction: Direction.East);

    foreach (var actionAndValue in sequence)
    {
        currentPositionAndDirection = Move(currentPositionAndDirection, actionAndValue);
    }

    return int.MinValue;
}

// Part 2
int Part2((string Action, int Value)[] sequence)
{
    return int.MinValue;
}

(int X, int Y, Direction Direction) Move((int X, int Y, Direction Direction) currentState, (string Action, int Value) actionAndValue)
{
    switch (actionAndValue.Action)
    {
        case "F":

            break;
        case "L":
        case "R":
            currentState.Direction = Turn(currentState, actionAndValue);
            break;
        
    }

    return (0, 0, Direction.East);
}

Direction Turn((int X, int Y, Direction Direction) currentState, (string Action, int Value) actionAndValue)
{
    var nitti = actionAndValue.Value / 90;
    var fyra = nitti % 4;
    var hej = actionAndValue.Action == "L" ? (actionAndValue.Value / 90 % 4 - currentState.Direction) : (actionAndValue.Value / 90 % 4 + currentState.Direction);

    return hej;
}

enum Direction
{
    North,
    East,
    South,
    West
}