using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class Day3
    {
        private readonly char[][] _forest;
        private static char TreeChar = '#';

        public string Forest => DumpForest();

        private string DumpForest()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _forest.Length; i++)
            {
                var line = new string(_forest[i]);
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public Day3(string[] forest)
        {
            _forest = Parse(forest);
        }

        private char[][] Parse(string[] forest)
        {
            var forestChars = new char[forest.Length][];

            for (int i = 0; i < forest.Length; i++)
            {
                forestChars[i] = forest[i].ToCharArray();
            }

            return forestChars;
        }

        public long MultiplyTreesInSlopes(IEnumerable<(int right,int down)> slopes)
        {
            long product = 1;

            slopes
                .Select(s => FindTreesInSlope(s.right, s.down))
                // int not enough....
                //.Aggregate((p, s) => p * s);
                .ToList()
                .ForEach(t => product *= t);

            return product;
        }

        public int FindTreesInSlope(int right, int down)
        {
            var height = 0;
            var width = 0;
            var treeCount = 0;

            while (true)
            {
                // start from left side if right side reached
                if (width >= _forest.First().Length)
                {
                    width = Math.Max(0, width - _forest.First().Length);
                }

                // reached bottom of slope?
                if (height >= _forest.Length)
                {
                    return treeCount;
                }

                var isTree = _forest[height][width] == TreeChar;
                
                //debug
                //_forest[height][width] = isTree ? 'X' : 'O';

                treeCount += isTree ? 1 : 0;

                width += right;
                height += down;                
            }
        }
    }
}
