namespace AoC2021.Tests;
public class Day2Tests : DayTestBase
{
    private readonly Day2 _day2;
    private readonly string[] _testInput = {
        "forward 5", 
        "down 5", 
        "forward 8", 
        "up 3", 
        "down 8", 
        "forward 2"
    };

    public Day2Tests(ITestOutputHelper output) : base(output)
    {
        _day2 = new Day2();
    }

    [Fact]
    public void Part1()
    {
        var strategy = new Day2.Part1Strategy();
        _day2.RunInputOnStrategy(_testInput, strategy);
        
        Assert.Equal(150, strategy.Result);
    }

    [Fact]
    public async Task Part1RealData()
    {
        var realInput = await FileHelper.GetInputAsLines(Day);
        var strategy = new Day2.Part1Strategy();
        _day2.RunInputOnStrategy(realInput, strategy);

        Output.WriteLine(strategy.Result.ToString());
    }
    
    [Fact]
    public void Part2()
    {
        var strategy = new Day2.Part2Strategy();
        _day2.RunInputOnStrategy(_testInput, strategy);
        
        Assert.Equal(900, strategy.Result);
    }
    
    [Fact]
    public async Task Part2RealData()
    {
        var realInput = await FileHelper.GetInputAsLines(Day);
        var strategy = new Day2.Part2Strategy();
        _day2.RunInputOnStrategy(realInput, strategy);
        Output.WriteLine(strategy.Result.ToString());
    }
}
