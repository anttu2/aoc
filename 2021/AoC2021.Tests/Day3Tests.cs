namespace AoC2021.Tests;
public class Day3Tests : DayTestBase
{
    private readonly Day3 _day3;
    private readonly string[] _testInput = {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
    };

    public Day3Tests(ITestOutputHelper output) : base(output)
    {
        _day3 = new Day3();
    }

    [Fact]
    public void Part1()
    {
        var result = _day3.CalculateGammaAndEpsilonFactor(_testInput);
        
        Assert.Equal(198, result);
    }
    
    [Fact]
    public async Task Part1RealData()
    {
        var realInput = await FileHelper.GetInputAsLines(Day);
        var result = _day3.CalculateGammaAndEpsilonFactor(realInput);
    
        Output.WriteLine(result.ToString());
    }
    
    [Fact]
    public void Part2()
    {
        var result = _day3.CalculateLifeSupportRating(_testInput);
        
        Assert.Equal(230, result);
    }
    
    [Fact]
    public async Task Part2RealData()
    {
        var realInput = await FileHelper.GetInputAsLines(Day);
        var result = _day3.CalculateLifeSupportRating(realInput);
    
        Output.WriteLine(result.ToString());
    }
}
