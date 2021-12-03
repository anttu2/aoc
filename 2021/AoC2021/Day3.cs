namespace AoC2021;
public class Day3
{
    public int CalculateGammaAndEpsilonFactor(string[] testInput)
    {
        var positionEpsilonHighCounts = new Dictionary<int, int>();
        var positionGammaHighCounts = new Dictionary<int, int>();
        
        foreach (string value in testInput)
        {
            for (int pos = 0; pos < value.Length; pos++)
            {
                if (!positionEpsilonHighCounts.ContainsKey(pos))
                {
                    positionEpsilonHighCounts[pos] = 0;
                }
                
                if (!positionGammaHighCounts.ContainsKey(pos))
                {
                    positionGammaHighCounts[pos] = 0;
                }
                
                positionEpsilonHighCounts[pos] += value[pos] == '1' ? 1 : 0;
                positionGammaHighCounts[pos] += value[pos] == '1' ? 0 : 1;
            }
        }

        string epsilonBinary = "";
        string gammaBinary = "";

        foreach (var i in positionEpsilonHighCounts.Keys)
        {
            epsilonBinary += positionEpsilonHighCounts[i] > positionGammaHighCounts[i] ? "1" : "0";
            gammaBinary += positionEpsilonHighCounts[i] > positionGammaHighCounts[i] ? "0" : "1";
        }

        var epsilon = Convert.ToInt32(epsilonBinary, 2);
        var gamma = Convert.ToInt32(gammaBinary, 2);

        return epsilon * gamma;
    }

    public int CalculateLifeSupportRating(string[] testInput)
    {
        var oxygenRating = GetRatingValue(testInput, count => count.ones >= count.zeros);
        var co2Rating = GetRatingValue(testInput, count => count.ones < count.zeros);

        return co2Rating * oxygenRating;
    }

    private static int GetRatingValue(string[] input, Func<(int ones, int zeros), bool> countComparison)
    {
        int inputLength = input.First().Length;
        var buffer = input;

        for (int pos = 0; pos < inputLength && buffer.Length > 1; pos++)
        {
            var oneCounts = buffer.Where(b => b[pos] == '1').ToArray();
            var zeroCounts = buffer.Where(b => b[pos] == '0').ToArray();

            buffer = countComparison((oneCounts.Length, zeroCounts.Length)) 
                ? oneCounts 
                : zeroCounts;
        }

        return Convert.ToInt32(buffer.Single(), 2);
    }
}
