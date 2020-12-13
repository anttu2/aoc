using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public class Day3Tests
    {
        private ITestOutputHelper _output;
        private const string Day = "day3";
        private static string TestForest =
@"
..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

        //Right 1, down 1.
        //Right 3, down 1. (This is the slope you already checked.)
        //Right 5, down 1.
        //Right 7, down 1.
        //Right 1, down 2.
        private static (int down,int right)[] Slopes = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };

        public string[] TestForestArray => TestForest.Trim().Split(Environment.NewLine);

        public Day3Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var day = new Day3(TestForestArray);
            var result = day.FindTreesInSlope(3,1);

            _output.WriteLine(day.Forest);

            Assert.Equal(7, result);
        }

        [Fact]
        public async Task Part1DataAsync()
        {
            var forestData = await FileHelper.GetInputAsLines(Day);

            var day = new Day3(forestData);
            var result = day.FindTreesInSlope(3, 1);

            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Part2()
        {
            var day = new Day3(TestForestArray);
            var result = day.MultiplyTreesInSlopes(Slopes);

            _output.WriteLine(day.Forest);

            Assert.Equal(336, result);
        }

        [Fact]
        public async Task Part2DataAsync()
        {
            var forestData = await FileHelper.GetInputAsLines(Day);

            var day = new Day3(forestData);
            var result = day.MultiplyTreesInSlopes(Slopes);

            _output.WriteLine(result.ToString());
        }



    }
}
