using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace AdventOfCode
{
    public class Day9
    {
        private readonly ITestOutputHelper _output;

        public Day9(ITestOutputHelper output)
        {
            _output = output;
        }

        #region Part 1

        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void TestInput_Part1(string input, int correctPoints)
        {
            var result = CalculatePointsAndActiveCharsInString(input);

            Assert.Equal(correctPoints, result.point);
        }

        #endregion

        #region Part 2

        [Theory]
        [InlineData("<>", 0)]
        [InlineData("<random characters>", 17)]
        [InlineData("<<<<>", 3)]
        [InlineData("<{!>}>", 2)]
        [InlineData("<!!>", 0)]
        [InlineData("<!!!>>", 0)]
        [InlineData("<{o\"i!a,<{i<a>", 10)]
        public void TestInput_Part2(string input, int activeCharacters)
        {
            var result = CalculatePointsAndActiveCharsInString(input);

            Assert.Equal(activeCharacters, result.garbageChars);
        }

        #endregion

        [Fact]
        public async Task RealInput()
        {
            var input = File.ReadAllText("input_day9.txt");

            var points = CalculatePointsAndActiveCharsInString(input);

            _output.WriteLine(points.ToString());
        }

        private (int point, int garbageChars) CalculatePointsAndActiveCharsInString(string input)
        {
            int level = 0;
            int totalScore = 0;
            int garbageChars = 0;
            bool isGarbage = false;
            bool ignore = false;

            Enumerable.Range(0, input.Length)
                .ToList()
                .ForEach(index =>
                {
                    if (ignore)
                    {
                        ignore = false;
                        return;
                    }

                    var character = input[index];

                    if (isGarbage && character != '!' && character != '>')
                    {
                        garbageChars++;
                    }

                    switch (character)
                    {
                        case '{' when !isGarbage && !ignore:
                        {
                            level++;
                            totalScore += level;
                            break;
                        }
                        case '}' when !isGarbage && !ignore:
                        {
                            level--;
                            break;
                        }
                        case '<' when !isGarbage && !ignore:
                        {
                            isGarbage = true;
                            break;
                        }
                        case '>' when isGarbage && !ignore:
                        {
                            isGarbage = false;
                            break;
                        }
                        case '!':
                        {
                            ignore = true;
                            break;
                        }
                    }
                });

            return (totalScore, garbageChars);
        }
    }
}
