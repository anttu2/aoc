using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2020
{
    public class Day4
    {
        private IList<Passport> _passports;

        public Day4(string passportData)
        {
            _passports = Parse(passportData);
        }

        private IList<Passport> Parse(string passportData)
        {
            var passportDatas = passportData.SplitByDoubleNewLine();

            return passportDatas.Select(p => new Passport(p.Trim())).ToList();
        }

        public int CountValidPassportsLax()
        {
            return _passports
                .Where(p => p.IsValidLax)
                .Count();
        }

        public int CountValidPassportsStrict()
        {
            return _passports
                .Where(p => p.IsValidStrict)
                .Count();
        }

        public record Passport
        {
            private Regex _fieldRegex = new Regex("(?<field>[a-z]{3}):(?<data>.+)", RegexOptions.Compiled);
            private Regex _validHairColor = new Regex("^#[0-9a-f]{6}$", RegexOptions.Compiled);
            private Regex _validEyeColor = new Regex("(amb|blu|brn|gry|grn|hzl|oth)", RegexOptions.Compiled);
            private Regex _validPassportID = new Regex(@"^\d{9}$", RegexOptions.Compiled);
            private Regex _heightRegex = new Regex(@"(?<value>\d+)(?<unit>(cm|in))", RegexOptions.Compiled);

            public Passport(string data)
            {
                var entries = data.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                foreach (var entry in entries)
                {
                    var match = _fieldRegex.Match(entry);

                    var field = match.Groups["field"].ToString();
                    var fieldData = match.Groups["data"].ToString();

                    switch (field)
                    {
                        case "byr":
                            BirthYear = int.Parse(fieldData);
                            break;
                        case "iyr":
                            IssueYear = int.Parse(fieldData);
                            break;
                        case "eyr":
                            ExpirationYear = int.Parse(fieldData);
                            break;
                        case "cid":
                            CountryID = int.Parse(fieldData);
                            break;
                        case "pid":
                            PassportID = fieldData;
                            break;
                        case "hgt":
                            Height = fieldData;
                            break;
                        case "hcl":
                            HairColor = fieldData;
                            break;
                        case "ecl":
                            EyeColor = fieldData;
                            break;
                        default:
                            break;
                    }
                }
            }

            public int? BirthYear { get; }
            public int? IssueYear { get; }
            public int? ExpirationYear { get; }
            public string Height { get; }
            public string HairColor { get; }
            public string EyeColor { get; }
            public string PassportID { get; }
            public int? CountryID { get; }

            public bool IsValidLax =>
                BirthYear.HasValue
                && IssueYear.HasValue
                && ExpirationYear.HasValue
                && !string.IsNullOrEmpty(Height)
                && !string.IsNullOrEmpty(HairColor)
                && !string.IsNullOrEmpty(EyeColor)
                && !string.IsNullOrEmpty(PassportID);

            public bool IsValidStrict =>
                IsValidLax
                && BirthYear is >= 1920 and <= 2002
                && IssueYear is >= 2010 and <= 2020
                && ExpirationYear is >= 2020 and <= 2030
                && HeightIsInRange(Height)
                && _validHairColor.IsMatch(HairColor)
                &&  _validEyeColor.IsMatch(EyeColor)                
                && _validPassportID.IsMatch(PassportID);

            private bool HeightIsInRange(string height)
            {
                var match = _heightRegex.Match(height);

                if (!match.Success)
                {
                    return false;
                }

                var value = int.Parse(match.Groups["value"].ToString());
                var unit = match.Groups["unit"].ToString();

                switch (unit)
                {
                    case "cm":
                        return value is >= 150 and <= 193;
                    case "in":
                        return value is >= 59 and <= 76;
                    default:
                        return false;
                }
            }
        }
    }
}
