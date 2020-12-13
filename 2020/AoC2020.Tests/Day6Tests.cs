using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public class Day6Tests : DayBase
    {
        public Day6Tests(ITestOutputHelper output) : base(output)
        {
        }

        private static string TestData =
@"
abc

a
b
c

ab
ac

a
a
a
a

b
";

        [Fact]
        public void Part1()
        {
            var day = new Day6(TestData);
            var result = day.SumAllDistinctAnswers();

            Assert.Equal(11, result);
        }

        [Fact]
        public async Task Part1DataAsync()
        {
            var formsData = await FileHelper.GetInputAsText(Day);

            var day = new Day6(formsData);
            var result = day.SumAllDistinctAnswers();

            Output.WriteLine(result.ToString());
        }

        [Fact]
        public void Part2()
        {
            var day = new Day6(TestData);
            var result = day.SumAllGroupDistinctAnswers();

            Assert.Equal(6, result);
        }

        [Fact]
        public async Task Part2DataAsync()
        {
            var formsData = await FileHelper.GetInputAsText(Day);

            var day = new Day6(formsData);
            var result = day.SumAllGroupDistinctAnswers();

            Output.WriteLine(result.ToString());
        }
    }
}
