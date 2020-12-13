using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public class Day2Tests
    {
        private ITestOutputHelper _output;
        private const string Day = "day2";
        private string[] _testInput = new string[] {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };

        public Day2Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var day = new Day2(_testInput);
            var result = day.CountValidPasswordsPart1();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task Part1DataAsync()
        {
            var passwordData = await FileHelper.GetInputAsLines(Day);
            var day = new Day2(passwordData);

            var result = day.CountValidPasswordsPart1();
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Part2()
        {
            var day = new Day2(_testInput);
            var result = day.CountValidPasswordsPart2();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task Part2DataAsync()
        {
            var passwordData = await FileHelper.GetInputAsLines(Day);
            var day = new Day2(passwordData);

            var result = day.CountValidPasswordsPart2();
            _output.WriteLine(result.ToString());
        }
    }
}
