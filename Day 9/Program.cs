using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var input = (Code: File.ReadLines("input.txt").Select(long.Parse).ToArray(), Preamble: 25);
//var input = (Code: File.ReadLines("exampleInput.txt").Select(long.Parse).ToArray(), Preamble: 5);

//Print results
Console.WriteLine($"Part 1: {Part1(input.Code, input.Preamble)}");
Console.WriteLine($"Part 2: {Part2(input.Code, Part1(input.Code, input.Preamble))}");


long Part1(long[] xmasCode, int preamble = 25)
{
	long? notSumOfAnyPreviousInPreamble = null;

	for (int currentValue = preamble; currentValue < xmasCode.Length; currentValue++)
	{
		for (int firstAddend = currentValue - preamble; firstAddend < currentValue; firstAddend++)
		{
            if (notSumOfAnyPreviousInPreamble.HasValue)
            {
				continue;
            }

            for (int secondAddend = firstAddend + 1; secondAddend < currentValue; secondAddend++)
            {
				if (notSumOfAnyPreviousInPreamble.HasValue)
				{
					continue;
				}

				if (xmasCode[firstAddend] + xmasCode[secondAddend] == xmasCode[currentValue])
                {
					notSumOfAnyPreviousInPreamble = xmasCode[currentValue];
                }
            }
		}

        if (!notSumOfAnyPreviousInPreamble.HasValue)
        {
			return xmasCode[currentValue];
        }

		notSumOfAnyPreviousInPreamble = null;
	}

	throw new Exception("Could not find weakness in XMAS code.");
}

long Part2(long[] xmasCode, long invalidNumber)
{
    for (int i = 0; i < xmasCode.Length; i++)
    {
		var j = i + 1;
		var contiguousSet = new List<long> { xmasCode[i], xmasCode[i + 1] };

		while (contiguousSet.Sum() <= invalidNumber)
        {
            if (contiguousSet.Sum() == invalidNumber)
            {
				return contiguousSet.Min() + contiguousSet.Max();
            }

			j++;
			contiguousSet.Add(xmasCode[j]);
		}
	}

	return long.MinValue;
}