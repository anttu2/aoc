namespace AoC2021.Tests;
public class Day1Tests : DayTestBase
{
    private readonly Day1 _day1;
    private int[] _testInput = new int[] {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263
            };

    public Day1Tests(ITestOutputHelper output) : base(output)
    {
        _day1 = new Day1();
    }

    [Fact]
    public void Part1()
    {
        var result = _day1.FindIncreaseCount(_testInput);

        Assert.Equal(7, result);
    }

    [Fact]
    public async void Part1RealData()
    {
        var realInput = await FileHelper.GetInputAs<int>(Day);
        var result = _day1.FindIncreaseCount(realInput);
        Output.WriteLine(result.ToString());
    }

    [Fact]
    public void Part2()
    {
        var result = _day1.FindIncreaseCountWithSlidingWindow(_testInput);

        Assert.Equal(5, result);
    }

    [Fact]
    public async void Part2RealData()
    {
        var realInput = await FileHelper.GetInputAs<int>(Day);
        var result = _day1.FindIncreaseCountWithSlidingWindow(realInput);
        Output.WriteLine(result.ToString());
    }
}
