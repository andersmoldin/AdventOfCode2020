using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

//var input = File.ReadLines("input.txt");
var input = File.ReadLines("exampleInput.txt");
//var input = File.ReadLines("exampleInput2.txt");

Console.WriteLine($"Part 1: {Part1(input)}");
Console.WriteLine($"Part 2: {Part2(input)}");

int Part1(IEnumerable<string> allRules)
{
    var bags = ReadRules(allRules);
    return NumberOfPossibleContainingBags("shiny gold", bags);
}

int Part2(IEnumerable<string> allRules)
{
    var bags = ReadRules2(allRules);
    return -1;
}

Dictionary<string, string> ReadRules(IEnumerable<string> rules)
{
    return rules
        .Select(s => s.Split(" bags contain "))
        .ToDictionary(p => p[0], p => p[1]);
}

int NumberOfPossibleContainingBags(string bagToEvaluate, Dictionary<string, string> bags)
{
    int newBags = 0;
    var bagsThatCanContainEvaluatedBag = new HashSet<string> { bagToEvaluate };

    do
    {
        newBags = 0;

        for (int i = 0; i < bagsThatCanContainEvaluatedBag.Count; i++)
        {
            foreach (var bag in bags.Where(b => b.Value != "no other bags."))
            {
                if (bag.Value.Contains(bagsThatCanContainEvaluatedBag.ElementAt(i)) &&
                    !bagsThatCanContainEvaluatedBag.Contains(bag.Key))
                {
                    bagsThatCanContainEvaluatedBag.Add(bag.Key);
                    newBags++;
                }
            }
        }

    } while (newBags != 0);

    return bagsThatCanContainEvaluatedBag.Count(b => b != bagToEvaluate);
}

int ReadRules2(IEnumerable<string> rules)
{
    var allBags = new HashSet<Bag>();

    foreach (var rule in rules)
    {
        var match = Regex.Match(rule, "^([a-z ]+) bags contain ((\\d+) ([0-9a-z ]+)(,[0-9a-z ]+)*|no other bags).$").Groups;

        var bag = new Bag(match[1].Value);

        foreach (var bagInThisBag in match[2].Value.Split(", "))
        {
            allBags.Add(new Bag());
        }
    }
    
    var bags = rules
        .Select(r => Regex.Match(r, "^([a-z ]+) bags contain ((\\d+) ([0-9a-z ]+)(,[0-9a-z ]+)*|no other bags).$").Groups)
        .Select(g => new Bag(g[1].Value + g[2].Value)
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