using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public class Day5Tests
    {
        private ITestOutputHelper _output;
        private const string Day = "day5";


        public Day5Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void Part1(string boardingCard, int row, int col, int seatID)
        {
            var day = new Day5(Enumerable.Empty<string>());
            var result = day.GetSeat(boardingCard);

            Assert.Equal(row, result.row);
            Assert.Equal(col, result.col);
            Assert.Equal(seatID, result.seatID);
        }

        [Fact]
        public async Task Part1DataAsync()
        {
            var boardingCards = await FileHelper.GetInputAsLines(Day);

            var day = new Day5(boardingCards);
            var result = day.FindHighestSeatID();

            _output.WriteLine(result.ToString());
        }

        [Fact]
        public async Task Part2DataAsync()
        {
            var boardingCards = await FileHelper.GetInputAsLines(Day);

            var day = new Day5(boardingCards);
            var result = day.FindMissingSeatID();

            _output.WriteLine(result.ToString());
        }
    }
}
