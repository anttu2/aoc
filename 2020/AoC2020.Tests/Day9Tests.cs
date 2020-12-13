
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public class Day9Tests : DayBase
    {
        public Day9Tests(ITestOutputHelper output) : base(output)
        {
        }

        private static string TestData =
@"
35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576
";

        [Fact]
        public void Part1()
        {
            var day = new Day9(TestData, 5);
            var result = day.FindFirstInvalidNumber();

            Assert.Equal(127, result);
        }

        [Fact]
        public async Task Part1DataAsync()
        {
            var data = await FileHelper.GetInputAsText(Day);

            var day = new Day9(data, 25);
            var result = day.FindFirstInvalidNumber();

            Output.WriteLine(result.ToString());
        }

        [Fact]
        public void Part2()
        {
            var day = new Day9(TestData, 5);
            var result = day.FindContigousSumOfAndGetSumOfSmallestAndLargestNum(127);

            Assert.Equal(62, result);
        }

        [Fact]
        public async Task Part2DataAsync()
        {
            var data = await FileHelper.GetInputAsText(Day);

            var day = new Day9(data, 25);
            var num = day.FindFirstInvalidNumber();
            var result = day.FindContigousSumOfAndGetSumOfSmallestAndLargestNum(num);

            Output.WriteLine(result.ToString());
        }
    }
}
