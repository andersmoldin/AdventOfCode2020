using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            //var input = File.ReadAllText("exampleInput.txt");
            //var input = File.ReadAllText("invalid.txt");
            //var input = File.ReadAllText("valid.txt");

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/4
        /// </summary>
        private static int Part1(string input)
        {
            return input
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None)
                .Where(p => p.Contains("byr:") &&
                            p.Contains("iyr:") &&
                            p.Contains("eyr:") &&
                            p.Contains("hgt:") &&
                            p.Contains("hcl:") &&
                            p.Contains("ecl:") &&
                            p.Contains("pid:"))
                .Count();
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/4#part2
        /// </summary>
        private static int Part2(string input)
        {
            var passports = input
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None)
                .Select(p => p.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.None));

            return passports
                .Where(ValidatePassports)
                .Count();
        }

        private static bool ValidatePassports(string[] passports)
        {
            var pairs = passports.Select(p => p.Split(':')).ToDictionary(p => p[0], p => p[1]);

            if (!pairs.ContainsKey("byr") ||
                !pairs.ContainsKey("iyr") ||
                !pairs.ContainsKey("eyr") ||
                !pairs.ContainsKey("hgt") ||
                !pairs.ContainsKey("hcl") ||
                !pairs.ContainsKey("ecl") ||
                !pairs.ContainsKey("pid"))
            {
                return false;
            }

            foreach (var field in pairs)
            {
                switch (field.Key)
                {
                    case "byr":

                        var byr = Convert.ToInt32(field.Value);

                        if (byr > 2002 || byr < 1920)
                        {
                            return false;
                        }

                        break;

                    case "iyr":

                        var iyr = Convert.ToInt32(field.Value);

                        if (iyr > 2020 || iyr < 2010)
                        {
                            return false;
                        }

                        break;

                    case "eyr":

                        var eyr = Convert.ToInt32(field.Value);

                        if (eyr > 2030 || eyr < 2020)
                        {
                            return false;
                        }

                        break;

                    case "hgt":

                        if (field.Value.EndsWith("cm"))
                        {
                            var cm = Convert.ToInt32(field.Value.Substring(0, field.Value.Length - 2));

                            if (cm > 193 || cm < 150)
                            {
                                return false;
                            }
                        }
                        else if (field.Value.EndsWith("in"))
                        {
                            var inch = Convert.ToInt32(field.Value.Substring(0, field.Value.Length - 2));

                            if (inch > 76|| inch < 59)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                        break;

                    case "hcl":

                        var haircolor = @"^\#[0-9a-f]{6}$";

                        if (!Regex.IsMatch(field.Value, haircolor))
                        {
                            return false;
                        }

                        break;

                    case "ecl":

                        var eyecolor = @"^\b(?:amb|blu|brn|gry|grn|hzl|oth)\b$";

                        if (!Regex.IsMatch(field.Value, eyecolor))
                        {
                            return false;
                        }

                        break;

                    case "pid":

                        var passportId = @"^[0-9]{9}$";

                        if (!Regex.IsMatch(field.Value, passportId))
                        {
                            return false;
                        }

                        break;

                    case "cid":

                        Debug.WriteLine("Ignoring cid");

                        break;

                    default:
                        throw new Exception("Unknown field in passport");
                }
            }

            return true;
        }
    }
}
