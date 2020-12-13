
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public class Day8Tests : DayBase
    {
        public Day8Tests(ITestOutputHelper output) : base(output)
        {
        }

        private static string TestData =
@"
nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6
";

        [Fact]
        public void Part1()
        {
            var day = new Day8(TestData);
            var result = day.GetAccumulatorOnFirstLoop();

            Assert.Equal(5, result);
        }

        [Fact]
        public async Task Part1DataAsync()
        {
            var data = await FileHelper.GetInputAsText(Day);

            var day = new Day8(data);
            var result = day.GetAccumulatorOnFirstLoop();

            Output.WriteLine(result.ToString());
        }

        [Fact]
        public void Part2()
        {
            var day = new Day8(TestData);
            var result = day.HealBootSeqAndGetAccumulatorOnSuccesfulExecution();

            Assert.Equal(8, result);
        }

        [Fact]
        public async Task Part2DataAsync()
        {
            var data = await FileHelper.GetInputAsText(Day);

            var day = new Day8(data);
            var result = day.HealBootSeqAndGetAccumulatorOnSuccesfulExecution();

            Output.WriteLine(result.ToString());
        }
    }
}
