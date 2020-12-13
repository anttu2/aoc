using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public class Day4Tests
    {
        private ITestOutputHelper _output;
        private const string Day = "day4";
        private static string TestDataPart1 =
@"
ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in
";

        private const string TestDataPart2Invalid  =
@"
eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:2807544665
";

        private const string TestDataPart2Valid =
@"
pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719
";

        public Day4Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var day = new Day4(TestDataPart1);
            var result = day.CountValidPassportsLax();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task Part1DataAsync()
        {
            var forestData = await FileHelper.GetInputAsText(Day);

            var day = new Day4(forestData);
            var result = day.CountValidPassportsLax();

            _output.WriteLine(result.ToString());
        }

        [Theory]
        [InlineData(TestDataPart2Valid, 4)]
        [InlineData(TestDataPart2Invalid, 0)]
        public void Part2(string data, int validCount)
        {
            var day = new Day4(data);
            var result = day.CountValidPassportsStrict();

            Assert.Equal(validCount, result);
        }

        [Fact]
        public async Task Part2DataAsync()
        {
            var forestData = await FileHelper.GetInputAsText(Day);

            var day = new Day4(forestData);
            var result = day.CountValidPassportsStrict();

            //foreach (var item in result)
            //{
            //    _output.WriteLine(item.PassportID);
            //}

            _output.WriteLine(result.ToString());
        }
    }
}
