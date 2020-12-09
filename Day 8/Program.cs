using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var input = File.ReadLines("input.txt").Select(l => l.Split(' ')).Select(i => new Operation(i[0], Convert.ToInt32(i[1]), false)).ToArray();
//var input = File.ReadLines("exampleInput.txt").Select(l => l.Split(' ')).Select(i => new Operation(i[0], Convert.ToInt32(i[1]), false)).ToArray();

//Print results
Console.WriteLine($"Part 1: {Part1(input)}");
Console.WriteLine($"Part 2: {Part2(input)}");

int Part1(Operation[] bootCode)
{
    var accumulator = 0;
    var currentOperation = 0;

    while (!bootCode.All(bc => bc.Executed))
    {
        var operation = bootCode[currentOperation];

        if (operation.Executed)
        {
            break;
        }

        operation.Executed = true;

        switch (operation.Instruction)
        {
            case "acc":
                accumulator += operation.Value;
                currentOperation++;
                break;
            case "jmp":
                currentOperation += operation.Value;
                break;
            case "nop":
                currentOperation++;
                break;
            default:
                throw new Exception("Unknown instruction.");
        }
    }

    return accumulator;
}

int Part2(Operation[] bootCode)
{
    bootCode = bootCode.Select(o => { o.Executed = false; return o; }).ToArray();
    var terminated = false;
    var accumulator = 0;

    for (int i = 0; i < bootCode.Length; i++)
    {
        bootCode[i].Instruction = bootCode[i].Instruction == "jmp" ? "nop" : bootCode[i].Instruction == "nop" ? "jmp" : "acc";

        if (bootCode[i].Instruction == "acc")
        {
            continue;
        }

        var infiniteLoop = false;
        var currentOperation = 0;
        accumulator = 0;

        while (!infiniteLoop)
        {
            if (currentOperation == bootCode.Length)
            {
                terminated = true;
                break;
            }

            var operation = bootCode[currentOperation];

            if (operation.Executed)
            {
                break;
            }

            operation.Executed = true;

            switch (operation.Instruction)
            {
                case "acc":
                    accumulator += operation.Value;
                    currentOperation++;
                    break;
                case "jmp":
                    currentOperation += operation.Value;
                    if (operation.Value == 0)
                    {
                        infiniteLoop = true;
                    }
                    break;
                case "nop":
                    currentOperation++;
                    break;
                default:
                    throw new Exception("Unknown instruction.");
            }
        }

        if (terminated)
        {
            break;
        }

        infiniteLoop = false;
        bootCode[i].Instruction = bootCode[i].Instruction == "jmp" ? "nop" : bootCode[i].Instruction == "nop" ? "jmp" : "acc";
        bootCode = bootCode.Select(o => { o.Executed = false; return o; }).ToArray();
    }

    return accumulator;
}

class Operation
{
    public string Instruction { get; set; }
    public int Value { get; set; }
    public bool Executed { get; set; }

    public Operation(string instruction, int value, bool executed)
    {
        Instruction = instruction;
        Value = value;
        Executed = executed;
    }
}