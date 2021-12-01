namespace AoC2021.Tests;

public abstract class DayTestBase
{
    protected ITestOutputHelper Output;
    protected string Day => this.GetType().Name.Substring(0, 4);

    public DayTestBase(ITestOutputHelper output)
    {
        Output = output;
    }
}
