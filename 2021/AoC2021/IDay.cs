namespace AoC2021;

public interface IDay
{
    Task<string> Part1(string input, params string[] args);
    Task<string> Part2(string input, params string[] args);
}