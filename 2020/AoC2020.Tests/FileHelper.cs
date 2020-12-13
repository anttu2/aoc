using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Tests
{
    public class FileHelper
    {
        public static async Task<string[]> GetInputAsLines(string day)
        {
            return await File.ReadAllLinesAsync($"Inputs/{day}.txt");
        }

        public static async Task<string> GetInputAsText(string day)
        {
            return await File.ReadAllTextAsync($"Inputs/{day}.txt");
        }
    }
}
