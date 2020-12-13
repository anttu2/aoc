using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public static class Extensions
    {
        private const StringSplitOptions DefaultSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

        public static string[] SplitByDoubleNewLine(this string input)
        {
            return input.Split("\r\n\r\n", DefaultSplitOptions);
        }

        public static string[] SplitByNewLine(this string input)
        {
            return input.Split("\r\n", DefaultSplitOptions);
        }

        public static string[] SplitByCustom(this string input, string token)
        {
            return input.Split(token, DefaultSplitOptions);
        }
    }
}
