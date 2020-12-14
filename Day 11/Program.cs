using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var input = File.ReadLines("input.txt").Select(l => l.ToCharArray()).ToArray();
//var input = File.ReadLines("exampleInput.txt").Select(l => l.ToCharArray()).ToArray();

// Print answers
Console.WriteLine(Part1(input));
Console.WriteLine(Part2(input));

// Part 1
int Part1(char[][] layout)
{
    var positionsToChange = new Dictionary<(int X, int Y), char>();

    do
    {
        positionsToChange = GetPositionsToChange(layout);
        layout = ChangePositions(positionsToChange, layout);
    } while (positionsToChange.Count > 0);

    return layout.SelectMany(s => s).Count(s => s == '#');
}

// Part 2
int Part2(char[][] adapters)
{
    return int.MinValue;
}

Dictionary<(int X, int Y), char> GetPositionsToChange(char[][] layout)
{
    var positionsToChange = new Dictionary<(int X, int Y), char>();

    for (int row = 0; row < layout.Length; row++)
    {
        for (int column = 0; column < layout[row].Length; column++)
        {
            var adjacentSeats = GetAdjacentSeats(layout, row, column);

            switch (layout[row][column])
            {
                case 'L':
                    if (!adjacentSeats.Any(s => s == '#'))
                    {
                        positionsToChange.Add((row, column), '#');
                    }
                    break;
                case '#':
                    if (adjacentSeats.Count(s => s == '#') >= 4)
                    {
                        positionsToChange.Add((row, column), 'L');
                    }
                    break;
                case '.':
                    break;
                default:
                    throw new Exception($"Unknown character in positin ({row},{column})!");
            }
        }
    }

    return positionsToChange;
}

char[] GetAdjacentSeats(char[][] layout, int row, int column)
{
    var adjacentSeats = "";

    for (int i = 1; i >= -1; i--)
    {
        for (int j = 1; j >= -1; j--)
        {
            if (row + i >= 0 && column + j >= 0 && row + i < layout.Length && column + j < layout[0].Length && !(i == 0 && j == 0))
            {
                adjacentSeats += layout[row + i][column + j];
            }
        }
    }

    return adjacentSeats.ToCharArray();
}

char[][] ChangePositions(Dictionary<(int X, int Y), char> positionsToChange, char[][] layout)
{
    for (int row = 0; row < layout.Length; row++)
    {
        for (int column = 0; column < layout[row].Length; column++)
        {
            if (positionsToChange.ContainsKey((row, column)))
            {
                layout[row][column] = positionsToChange[(row, column)];
            }
        }
    }

    return layout;
}