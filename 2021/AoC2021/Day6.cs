using System.Text.RegularExpressions;

namespace AoC2021;

public class Day6 : IDay
{
    private long[] _fishCounts = new long[9];

    public Day6(string input)
    {
        ParseFishes(input);
    }

    private void ParseFishes(string fishData)
    {
        var fishDays = fishData.Split(",");

        foreach (var fishDay in fishDays)
        {
            var daysOld = int.Parse(fishDay);
            _fishCounts[daysOld]++;
        }
    }

    public long RunSimulationAndCountFishes(int daysToRun)
    {
        for (int day = 0; day < daysToRun; day++)
        {
            var newbies = _fishCounts[0];

            for (int i = 1; i <= 8; i++)
            {
                _fishCounts[i - 1] = _fishCounts[i];
            }

            _fishCounts[6] += newbies;
            _fishCounts[8] = newbies;
        }

        return _fishCounts.Sum();
    }

    public Task<string> Part1(string input, params string[] args)
    {
        var count = RunSimulationAndCountFishes(int.Parse(args.Last()));
        return Task.FromResult(count.ToString());
    }

    public Task<string> Part2(string input, params string[] args)
    {
        return Part1(input, args);
    }
}