using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var answersFromEveryGroupOnThePlane = File.ReadAllText("input.txt")
    .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None);
//var answersFromEveryGroupOnThePlane = File.ReadAllText("exampleInput.txt")
//    .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None);

Console.WriteLine(Part1(answersFromEveryGroupOnThePlane));
Console.WriteLine(Part2(answersFromEveryGroupOnThePlane));

int Part1(string[] answersFromEveryGroupOnThePlane)
{
    var positiveAnswers = answersFromEveryGroupOnThePlane
        .Select(groupAnswer => groupAnswer.Split(Environment.NewLine))
        .Select(x => x.SelectMany(y => y)
        .ToHashSet());

    return positiveAnswers.Select(x => x.Count).Sum();
}

int Part2(string[] answersFromEveryGroupOnThePlane)
{
    var groupedAnswers = answersFromEveryGroupOnThePlane
        .Select(groupAnswer => groupAnswer.Split(Environment.NewLine));

    var alphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
    var sumOfAnswersFromGroupsWhereEveryoneAnsweredYes = 0;

    foreach (var group in groupedAnswers)
    {
        var counter = 0;

        foreach (var letter in alphabet)
        {
            if (group.All(x => x.Contains(letter)))
            {
                counter++;
            }
        }

        sumOfAnswersFromGroupsWhereEveryoneAnsweredYes += counter;
    }

    return sumOfAnswersFromGroupsWhereEveryoneAnsweredYes;
}

// Found a beautiful solution on Reddit:
var all = File.ReadAllText("input.txt")
    .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None)
    .Select(l => l.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

Console.WriteLine(all.Sum(one => one.SelectMany(s => s).Distinct().Count()));
Console.WriteLine(all.Sum(one => one.Select(s => (IEnumerable<char>)s).Aggregate((s1, s2) => s1.Intersect(s2)).Count()));