namespace AoC2021;
public class Day1
{
    public int FindIncreaseCount(int[] testInput)
    {
        return Enumerable.Range(0, testInput.Length - 1)
            .Select(i => testInput[i+1] > testInput[i] ? 1 : 0)
            .Sum();
    }

    public int FindIncreaseCountWithSlidingWindow(int[] testInput)
    {
        var windows = Enumerable.Range(0, testInput.Length - 2)
            .Select(i => testInput[i] + testInput[i + 1] + testInput[i + 2])
            .ToArray();

        return FindIncreaseCount(windows);
    }
}
