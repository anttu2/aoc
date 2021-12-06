using System.Text.RegularExpressions;

namespace AoC2021;

public class Day5
{
    private int[][] _grid;

    public Day5(string testInput)
    {
        ParseGrid(testInput);
    }

    public int CountOverlappingPoints()
    {
        return _grid.SelectMany(p => p).Count(p => p > 1);
    }

    private void ParseGrid(string testInput)
    {
        var regex = new Regex(@"(?<x1>\d+),(?<y1>\d+) -> (?<x2>\d+),(?<y2>\d+)");

        var coordinatePairs = testInput.Split("\r\n");

        var parsedPairs = coordinatePairs
            .Where(pair => !string.IsNullOrWhiteSpace(pair))
            .Select(pair => regex.Match(pair))
            .Select(match => new
            {
                x1 = int.Parse(match.Groups["x1"].Value),
                y1 = int.Parse(match.Groups["y1"].Value),
                x2 = int.Parse(match.Groups["x2"].Value),
                y2 = int.Parse(match.Groups["y2"].Value)
            })
            .ToList();

        var maxX = parsedPairs.Max(p => p.x1 > p.x2 ? p.x1 : p.x2);
        var maxY = parsedPairs.Max(p => p.y1 > p.y2 ? p.y1 : p.y2);

        _grid = new int[maxX+1][];

        for (int x = 0; x <= maxX; x++)
        {
            _grid[x] = new int[maxY+1];
        }

        foreach (var pair in parsedPairs)
        {
            if (pair.x1 == pair.x2)
            {
                var x = pair.x1;
                var yStart = Math.Min(pair.y1, pair.y2);
                var yEnd = Math.Max(pair.y1, pair.y2);

                for (int y = yStart; y <= yEnd; y++)
                {
                    _grid[x][y]++;
                }
            }
            else if (pair.y1 == pair.y2)
            {
                var y = pair.y1;
                var xStart = Math.Min(pair.x1, pair.x2);
                var xEnd = Math.Max(pair.x1, pair.x2);

                for (int x = xStart; x <= xEnd; x++)
                {
                    _grid[x][y]++;
                }
            }
            else
            {
                var xStart = Math.Min(pair.x1, pair.x2);
                var xEnd = Math.Max(pair.x1, pair.x2);
                var yStart = Math.Min(pair.y1, pair.y2);
                var yEnd = Math.Max(pair.y1, pair.y2);

                var points = pair.x1 < pair.x2 ? new { Start = (pair.x1, pair.y1), End = (pair.x2, pair.y2)} : new { Start = (pair.x2, pair.y2), End = (pair.x1, pair.y1)};
                
                Func<int,int> incOp = points.Start.y1 > points.End.y2 ? p => --p : p => ++p;
                Func<int,bool> compOp = pair.y1 > pair.y2 ? p => p >= pair.y2 : p => p <= pair.y2;
                
                for ((int x, int y) = (points.Start.x1, points.Start.y1); x <= points.End.x2 && compOp(y); x++, y = incOp(y))
                {
                    
                        _grid[x][y]++;
                    
                }
            }
        }
    }
}