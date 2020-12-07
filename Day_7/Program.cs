using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

//var input = File.ReadLines("input.txt");
var input = File.ReadLines("exampleInput.txt");

Console.WriteLine($"Part 1: {Part1(input)}");
//Console.WriteLine($"Part 2: {Part2(input)}");

int Part1(IEnumerable<string> allRules)
{
    var processedRules = ReadRules(allRules);
    var newBags = 0;

    do
    {
        newBags = 0;



    } while (newBags != 0);

    return int.MinValue;
}

int ReadRules(IEnumerable<string> rules)
{
    var bags = rules
        .Select(r => Regex.Match(r, "^([a-z ]+) bags contain ((\\d+) ([0-9a-z ]+)(,[0-9a-z ]+)*|no other bags).$").Groups)
        .Select(g => new Bag(g[1].Value)
        //{
        //    Min = Convert.ToInt32(g[1].Value),
        //    Max = Convert.ToInt32(g[2].Value),
        //    Letter = Convert.ToChar(g[3].Value),
        //    Code = g[4].Value
        //}
        ).ToList();

    return int.MinValue;
}

class Bag
{
    public string Name { get; set; }
    public Dictionary<Bag, int> Bags { get; set; }
    public bool Processed { get; set; }

    public Bag(string name)
    {
        Name = name;
    }
}