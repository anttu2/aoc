using System.Text.RegularExpressions;

namespace AoC2021;

public class Day6 : IDay
{
    private Optimized _optimized;
    private Optimized2 _optimized2;

    class LanternFish
    {
        public int DaysUntilSpawn { get; private set; } = 8;

        public LanternFish()
        {
        }
        
        public LanternFish(int daysUntilSpawn)
        {
            DaysUntilSpawn = daysUntilSpawn;
        }

        public LanternFish? DayPassed()
        {
            DaysUntilSpawn--;

            LanternFish newFish = null;

            if (DaysUntilSpawn < 0)
            {
                DaysUntilSpawn = 6;
                newFish = new LanternFish();
            }

            return newFish;
        }
    }

    private List<LanternFish> _fishes = new();

    public Day6(string input)
    {
        ParseFishes(input);
        _optimized = new Optimized(input);
        _optimized2 = new Optimized2(input);
    }

    private void ParseFishes(string testInput)
    {
        var fishDays = testInput.Split(",");

        foreach (var fishDay in fishDays)
        {
            _fishes.Add(new LanternFish(int.Parse(fishDay)));
        }
    }

    public int RunSimulationAndCountFishes(int daysToRun)
    {
        for (int i = 0; i < daysToRun; i++)
        {
            var newFishesToAdd = new List<LanternFish>();
            foreach (var fish in _fishes.AsParallel())
            {
                var newFish = fish.DayPassed();

                if (newFish != null)
                {
                    newFishesToAdd.Add(newFish);
                }
            }
            
            _fishes.AddRange(newFishesToAdd);
        }

        return _fishes.Count();
    }
    
    public class Optimized
    {
        private readonly List<List<byte>> _fishBuckets = new();

        public Optimized(string fishData)
        {
            ParseFishes(fishData);
        }
        
        private void ParseFishes(string fishData)
        {
            var fishDays = fishData.Split(",");
        
            foreach (var fishDay in fishDays)
            {
                _fishBuckets.Add(new List<byte> {byte.Parse(fishDay)});
            }
        }
        
        public long RunSimulationAndCountFishes(int daysToRun)
        {
            for (int i = 0; i < daysToRun; i++)
            {
                Console.WriteLine($"Day: {i}");
                
                Parallel.ForEach(_fishBuckets, fishBucket =>
                    // foreach (var fishBucket in _fishBuckets)
                {
                    var bucketSize = fishBucket.Count;
                    for (int j = 0; j < bucketSize; j++)
                    {
                        var fishDay = --fishBucket[j];

                        if (fishDay == byte.MaxValue)
                        {
                            fishBucket[j] = 6;
                            fishBucket.Add(8);
                        }
                    }
                //}
                });
            }
        
            return _fishBuckets.Select(fb => fb.LongCount()).Sum();
        }
    }

    public class Optimized2
    {
        private long[] _fishCounts = new long[9];

        public Optimized2(string input)
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
    }

    public Task<string> Part1(string input, params string[] args)
    {
        var count = RunSimulationAndCountFishes(int.Parse(args.Last()));
        return Task.FromResult(count.ToString());
    }

    public Task<string> Part2(string input, params string[] args)
    {
        var count = _optimized2.RunSimulationAndCountFishes(int.Parse(args.Last()));
        return Task.FromResult(count.ToString());
    }
}