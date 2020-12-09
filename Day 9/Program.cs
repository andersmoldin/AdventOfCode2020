using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//var input = File.ReadLines("input.txt").Select(int.Parse).ToArray();
var input = File.ReadLines("exampleInput.txt").Select(int.Parse).ToArray();

//Print results
Console.WriteLine($"Part 1: {Part1(input, 5)}");
//Console.WriteLine($"Part 2: {Part2(input)}");


int Part1(int[] xmasCode, int preamble)
{
	int? notSumOfAnyPreviousInPreamble = null;

	var validValues = new HashSet<int>();

	for (int currentValue = preamble; currentValue < xmasCode.Length/* - preamble*/; currentValue++)
	{
		for (int firstAddend = currentValue - preamble; firstAddend < preamble; firstAddend++)
		{
            if (notSumOfAnyPreviousInPreamble.HasValue)
            {
				continue;
            }

            for (int secondAddend = firstAddend + 1; secondAddend < preamble; secondAddend++)
            {
				if (xmasCode[firstAddend] + xmasCode[secondAddend] == xmasCode[currentValue])
                {
					notSumOfAnyPreviousInPreamble = xmasCode[currentValue];

					validValues.Add(xmasCode[currentValue]);

					continue;
                }
            }
		}

        if (!notSumOfAnyPreviousInPreamble.HasValue)
        {
			return xmasCode[currentValue];
        }

		notSumOfAnyPreviousInPreamble = null;
	}

	var hej1 = validValues.Except(xmasCode).ToList();
	var hej2 = xmasCode.Except(validValues).ToList();

	return int.MinValue;
}