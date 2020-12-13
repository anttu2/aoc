using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class Day9
    {
        private long[] _xmasMessage;
        private readonly int _preamble;

        public Day9(string xmasMessage, int preamble)
        {
            _xmasMessage = Parse(xmasMessage);
            _preamble = preamble;
        }

        private long[] Parse(string xmasMessage)
        {
            return xmasMessage
                .SplitByNewLine()
                .Select(l => long.Parse(l))
                .ToArray();
        }

        public long FindFirstInvalidNumber()
        {
            for (int i = _preamble; i < _xmasMessage.Length; i++)
            {
                var num = _xmasMessage[i];
                var pre = _xmasMessage.AsSpan(i - _preamble, _preamble);
                var found = false; 

                for (int j = 0; j < _preamble; j++)
                {
                    for (int k = j; k < _preamble; k++)
                    {
                        if (pre[j] + pre[k] == num)
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    return num;
                }
            }

            throw new Exception("No invalid number found");
        }

        public long FindContigousSumOfAndGetSumOfSmallestAndLargestNum(long sumToFind)
        {
            for (int i = 0; i < _xmasMessage.Length - 1; i++)
            {
                var sum = 0L;
                var range = 2;
                
                while(sum < sumToFind)
                {
                    var rangeArray = _xmasMessage.AsSpan(i, range).ToArray();
                    sum = rangeArray.Sum();
                    
                    if (sum == sumToFind)
                    {
                        return rangeArray.Min() + rangeArray.Max();
                    }
                    
                    range++;
                }
            }

            throw new Exception("Couldn't find sum");
        }
    }
}
