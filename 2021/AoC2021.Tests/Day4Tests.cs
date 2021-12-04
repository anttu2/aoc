namespace AoC2021.Tests;
public class Day4Tests : DayTestBase
{
    private readonly Day4 _day4;
    private readonly string _testInput = 
@"
7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
8  2 23  4 24
21  9 14 16  7
6 10  3 18  5
1 12 20 15 19

3 15  0  2 22
9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24 4
10 16 15 9 19
18  8 23 26 20
22 11 13 6 5
2 0 12 3 7
" ;

    public Day4Tests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void Part1()
    {
        var day4 = new Day4(_testInput);
        var result = day4.PlayAndCalculateWinningBoardScore(Day4.WinningStrategy.First);
        
        Assert.Equal(4512, result);
    }
    
    [Fact]
    public async Task Part1RealData()
    {
        var realInput = await FileHelper.GetInputAsText(Day);
        var day4 = new Day4(realInput);
        var result = day4.PlayAndCalculateWinningBoardScore(Day4.WinningStrategy.First);
    
        Output.WriteLine(result.ToString());
    }
    
    [Fact]
    public void Part2()
    {
        var day4 = new Day4(_testInput);
        var result = day4.PlayAndCalculateWinningBoardScore(Day4.WinningStrategy.Last);
        
        Assert.Equal(1924, result);
    }
    
    [Fact]
    public async Task Part2RealData()
    {
        var realInput = await FileHelper.GetInputAsText(Day);
        var day4 = new Day4(realInput);
        var result = day4.PlayAndCalculateWinningBoardScore(Day4.WinningStrategy.Last);
    
        Output.WriteLine(result.ToString());
    }
}
