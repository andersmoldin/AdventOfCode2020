using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

// Get input
var passports = File.ReadAllText("input.txt")
    .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None) // passports
    .Select(l => l.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) // passports with fields
        .Select(s => s.Split(':')).ToDictionary(p => p[0], p => p[1]) // passports with fields as key values
    );

// Print answers
Console.WriteLine(ValidPassportsPart1(passports).Count());
Console.WriteLine(ValidPassportsPart2(passports).Count());

// Part 1
IEnumerable<IDictionary<string, string>> ValidPassportsPart1(IEnumerable<IDictionary<string, string>> passports)
{
    return passports.Where(x => x.Count(y => y.Key != "cid") == 7);
}

// Part 2
IEnumerable<IDictionary<string, string>> ValidPassportsPart2(IEnumerable<IDictionary<string, string>> passports)
{
    var validPassportsFromPart1 = ValidPassportsPart1(passports);

    return validPassportsFromPart1.Where(IsValidPassportValues);
}

bool IsValidPassportValues(IDictionary<string, string> passportValues)
{
    return passportValues.All(IsValidValue);
}

bool IsValidValue(KeyValuePair<string, string> field)
{
    return field.Key switch
    {
        "byr" => Int32.Parse(field.Value) is >= 1920 and <= 2002,
        "iyr" => Int32.Parse(field.Value) is >= 2010 and <= 2020,
        "eyr" => Int32.Parse(field.Value) is >= 2020 and <= 2030,
        "hgt" => Regex.IsMatch(field.Value, "^(1([5-8][0-9]|9[0-3])cm|(59|6[0-9]|7[0-6])in)$"),
        "hcl" => Regex.IsMatch(field.Value, "^#([0-9]|[a-f]){6}$"),
        "ecl" => new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(field.Value),
        "pid" => field.Value.Length == 9,
        "cid" => true,
        _ => throw new Exception("Unknown field")
    };
}