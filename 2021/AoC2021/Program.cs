
using AoC2021;

var dayName = args[0];
var dayPart = args[1];

var input = await FileHelper.GetInputAsText(dayName);
var dayType = Type.GetType($"AoC2021.{dayName}");
var day = (IDay)Activator.CreateInstance(dayType, input);

string output = null;

switch (dayPart)
{
    case "1":
        Console.WriteLine($"Running {dayName} part 1");
        output = await day.Part1(input, args);
        break;
    case "2":
        Console.WriteLine($"Running {dayName} part 2");
        output = await day.Part2(input, args);
        break;
    default:
        Console.WriteLine("Unknown day part. Expected 1 or 2");
        return;
}

Console.WriteLine($"Result: {output}");