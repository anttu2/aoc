using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode
{
    public class Day6
    {
        private readonly ITestOutputHelper _output;

        public Day6(ITestOutputHelper output)
        {
            _output = output;
        }

        #region Part 1

        [Theory]
        [InlineData("0\t2\t7\t0", 5)]
        public void TestInput_Part1(string memoryBanksString, int stepsToFindDuplicate)
        {
            var memoryBanks = ParseMemoryBanks(memoryBanksString);

            var steps = CountRedistributionsUntilSameFound(memoryBanks);

            Assert.Equal(stepsToFindDuplicate, steps.first);
        }

        #endregion

        #region Part 2

        [Theory]
        [InlineData("0\t2\t7\t0", 4)]
        public void TestInput_Part2(string memoryBanksString, int stepsToFindDuplicateSecondTime)
        {
            var memoryBanks = ParseMemoryBanks(memoryBanksString);

            var steps = CountRedistributionsUntilSameFound(memoryBanks);

            Assert.Equal(stepsToFindDuplicateSecondTime, steps.second);
        }

        #endregion

        [Fact]
        public void RealInput_Part1And2()
        {
            var memoryBanks = ParseMemoryBanks(RealInput);

            var steps = CountRedistributionsUntilSameFound(memoryBanks);

            _output.WriteLine($"Part 1: {steps.first}, Part 2: {steps.second}");
        }

        private (int first, int second) CountRedistributionsUntilSameFound(IList<int> memoryBanks)
        {
            var bankHash = new HashSet<string>();
            var firstTimeIterations = 0;
            var secondTimeIterations = 0;

            while (true)
            {
                var exists = !bankHash.Add(GetBankHash(memoryBanks));

                if (exists)
                {
                    if (firstTimeIterations == 0)
                    {
                        firstTimeIterations = bankHash.Count;
                        bankHash.Clear();
                        bankHash.Add(GetBankHash(memoryBanks));
                    }
                    else
                    {
                        secondTimeIterations = bankHash.Count;
                        break;
                    }
                }

                var maxBankValue = memoryBanks.Max();
                var indexOfFirstMax = memoryBanks.IndexOf(maxBankValue);
                memoryBanks[indexOfFirstMax] = 0;

                Enumerable.Range(indexOfFirstMax + 1, maxBankValue)
                    .ToList()
                    .ForEach(i =>
                    {
                        var round = i / memoryBanks.Count;
                        memoryBanks[i - round * memoryBanks.Count]++;
                    });
            }

            return (firstTimeIterations, secondTimeIterations);
        }

        private static string GetBankHash(IList<int> memoryBanks)
        {
            return String.Join(";", memoryBanks);
        }

        private IList<int> ParseMemoryBanks(string memBanks)
        {
            return memBanks.Trim().Split("\t").Select(int.Parse).ToList();
        }

        private const string RealInput = @"11	11	13	7	0	15	5	5	4	4	1	1	7	1	15	11";
    }
}
