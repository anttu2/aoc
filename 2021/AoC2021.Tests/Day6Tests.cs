namespace AoC2021.Tests;
public class Day6Tests : DayTestBase
{
    private readonly Day6 _day6;
    private readonly string _testInput = "3,4,3,1,2" ;

    public Day6Tests(ITestOutputHelper output) : base(output)
    {
    }

    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    public void Part1(int daysToRun, int expectedFishCount)
    {
        var day6 = new Day6(_testInput);
        var result = day6.RunSimulationAndCountFishes(daysToRun);
        
        Assert.Equal(expectedFishCount, result);
    }
    
    [Fact]
    public async Task Part1RealData()
    {
        var realInput = await FileHelper.GetInputAsText(Day);
        var day6 = new Day6(realInput);
        var result = day6.RunSimulationAndCountFishes(80);
    
        Output.WriteLine(result.ToString());
    }
    
    
    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    [InlineData(256,26984457539)]
    public void Part2(int daysToRun, long expectedFishCount)
    {
        var day6 = new Day6.Optimized(_testInput);
        var result = day6.RunSimulationAndCountFishes(daysToRun);
        
        Assert.Equal(expectedFishCount, result);
    }
    
    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    [InlineData(256,26984457539)]
    public void Part2Optimized(int daysToRun, long expectedFishCount)
    {
        var day6 = new Day6.Optimized2(_testInput);
        var result = day6.RunSimulationAndCountFishes(daysToRun);
        
        Assert.Equal(expectedFishCount, result);
    }
    //
    // [Fact]
    // public async Task Part2RealData()
    // {
    //     var realInput = await FileHelper.GetInputAsText(Day);
    //     var day6 = new Day6(realInput);
    //     var result = day6.CountOverlappingPoints();
    //
    //     Output.WriteLine(result.ToString());
    // }
}
