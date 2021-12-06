namespace AoC2021.Tests;
public class Day5Tests : DayTestBase
{
    private readonly Day5 _day5;
    private readonly string _testInput = 
@"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2
" ;

    public Day5Tests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void Part1()
    {
        var day5 = new Day5(_testInput);
        var result = day5.CountOverlappingPoints();
        
        Assert.Equal(5, result);
    }
    
    [Fact]
    public async Task Part1RealData()
    {
        var realInput = await FileHelper.GetInputAsText(Day);
        var day5 = new Day5(realInput);
        var result = day5.CountOverlappingPoints();
    
        Output.WriteLine(result.ToString());
    }
    
    [Fact]
    public void Part2()
    {
        var day5 = new Day5(_testInput);
        var result = day5.CountOverlappingPoints();
        
        Assert.Equal(12, result);
    }
    
    [Fact]
    public async Task Part2RealData()
    {
        var realInput = await FileHelper.GetInputAsText(Day);
        var day5 = new Day5(realInput);
        var result = day5.CountOverlappingPoints();
    
        Output.WriteLine(result.ToString());
    }
}
