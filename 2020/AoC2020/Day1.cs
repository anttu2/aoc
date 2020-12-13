using System;
using System.Linq;

namespace AoC2020
{
    public class Day1
    {
        public int FindSumAndMultiplyTwo(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i+1; j < input.Length; j++)
                {
                    var sum = input[i] + input[j];
                    if (sum == 2020)
                    {
                        return input[i] * input[j];
                    }
                }
            }

            throw new Exception("No sum matching 2020 found");
        }

        public int FindSumAndMultiplyThree(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    for (int k = 0; k < input.Length; k++)
                    {
                        var sum = input[i] + input[j] + input[k];
                        if (sum == 2020)
                        {
                            return input[i] * input[j] * input[k];
                        }
                    }
                }
            }

            throw new Exception("No sum matching 2020 found");
        }
    }
}
