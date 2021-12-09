using System.IO;

namespace AoC2021;

public class FileHelper
{
    public static async Task<string[]> GetInputAsLines(string day)
    {
        return await File.ReadAllLinesAsync($"InputData/{day}.txt");
    }

    public static async Task<T[]> GetInputAs<T>(string day)
    {
        var input = await GetInputAsLines(day);
        return input
            .Select(i => (T)Convert.ChangeType(i, typeof(T)))
            .ToArray();
    }

    public static async Task<string> GetInputAsText(string day)
    {
        return await File.ReadAllTextAsync($"InputData/{day}.txt");
    }
}