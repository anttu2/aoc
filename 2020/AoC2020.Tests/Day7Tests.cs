
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public class Day7Tests : DayBase
    {
        public Day7Tests(ITestOutputHelper output) : base(output)
        {
        }

        private static string TestDataPart1 =
@"
light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.
";

        private static string TestDataPart2 =
@"
shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.
";

        [Fact]
        public void Part1()
        {
            var day = new Day7(TestDataPart1);
            var result = day.FindCountOfParentsContainingGoldBag();

            Assert.Equal(4, result);
        }

        [Fact]
        public async Task Part1DataAsync()
        {
            var data = await FileHelper.GetInputAsText(Day);

            var day = new Day7(data);
            var result = day.FindCountOfParentsContainingGoldBag();

            Output.WriteLine(result.ToString());
        }

        [Fact]
        public void Part2()
        {
            var day = new Day7(TestDataPart2);
            var result = day.FindCountOfContainedBagsInGoldBag();

            Assert.Equal(126, result);
        }

        [Fact]
        public async Task Part2DataAsync()
        {
            var data = await FileHelper.GetInputAsText(Day);

            var day = new Day7(data);
            var result = day.FindCountOfContainedBagsInGoldBag();

            Output.WriteLine(result.ToString());
        }
    }
}
