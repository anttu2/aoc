using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2020
{
    public class Day2
    {
        Regex _pwdRuleRegex = new Regex(@"(?<min>\d+)-(?<max>\d+) (?<char>[a-z]): (?<pwd>[a-z]+)", RegexOptions.Compiled);
        private readonly string[] _passwords;

        public Day2(string[] passwords)
        {
            _passwords = passwords;
        }

        public int CountValidPasswordsPart1()
        {
            bool IsValidPart1(PwdData pwdData)
            {
                var charCount = pwdData.Pwd.Count(c => c == pwdData.Char);
                return charCount >= pwdData.Min && charCount <= pwdData.Max;
            }

            return _passwords
                .Select(ParseData)
                .Count(IsValidPart1);
        }

        public int CountValidPasswordsPart2()
        {
            bool IsValidPart2(PwdData pwdData)
            {
                var isPos1Char = pwdData.Pwd.ElementAt(pwdData.Min-1) == pwdData.Char;
                var isPos2Char = pwdData.Pwd.ElementAt(pwdData.Max-1) == pwdData.Char;
                return isPos1Char ^ isPos2Char;
            }

            return _passwords
                .Select(ParseData)
                .Count(IsValidPart2);
        }

        private PwdData ParseData(string pwdData)
        {
            var match = _pwdRuleRegex.Match(pwdData);

            return new PwdData
            {
                Min = int.Parse(match.Groups["min"].ToString()),
                Max = int.Parse(match.Groups["max"].ToString()),
                Char = match.Groups["char"].ToString()[0],
                Pwd = match.Groups["pwd"].ToString()
            };
        }

        record PwdData
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public char Char { get; set; }
            public string Pwd { get; set; }
        }
    }
}
