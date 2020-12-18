using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode
{
    public class Day3
    {
        private readonly ITestOutputHelper _output;
        private const int Dim = 1000;

        public Day3(ITestOutputHelper output)
        {
            _output = output;
        }

        #region Part 1

        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void TestInput_Part1(int target, int steps)
        {
            Assert.Equal(steps, GetDistance(target));
        }

        [Fact]
        public void RealInput_Part1()
        {
            var dist = GetDistance(312051);

            _output.WriteLine(dist.ToString());
        }

        public int GetDistance(int target)
        {
            var matrix = InitializeMatrix();

            var origo = (x: Dim / 2, y: Dim / 2);
            matrix[origo.x][origo.y] = 1;

            var dir = Dir.Right;
            var num = 2;
            var currentPoint = (x: origo.x + 1, y: origo.y);

            while (num != target && currentPoint.x < Dim && currentPoint.y < Dim)
            {
                matrix[currentPoint.x][currentPoint.y] = num++;

                var newDir = dir + 1 > Dir.Down
                    ? Dir.Right
                    : dir + 1;

                var nextPoint = NextPoint(newDir, currentPoint);

                if (matrix[nextPoint.x][nextPoint.y] == 0)
                {
                    currentPoint = nextPoint;
                    dir = newDir;
                }
                else
                {
                    currentPoint = NextPoint(dir, currentPoint);
                }
            }

            return Math.Abs(origo.x - currentPoint.x) + Math.Abs(origo.y - currentPoint.y);
        }

        #endregion

        #region Part 2

        [Theory]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(10,26)]
        [InlineData(17, 147)]
        public void TestInput_Part2(int step, int value)
        {
            var squareTuple = GetSquareWithValueHigherOrEqualThan(value);

            Assert.Equal(step, squareTuple.step);
            Assert.Equal(value, squareTuple.value);
        }

        [Fact]
        public void RealInput_Part2()
        {
            var squareTuple = GetSquareWithValueHigherOrEqualThan(312051);

            _output.WriteLine(squareTuple.ToString());
        }

        private (int step, int value) GetSquareWithValueHigherOrEqualThan(int targetValue)
        {
            int[][] matrix = InitializeMatrix();

            var origo = (x: Dim / 2, y: Dim / 2);
            matrix[origo.x][origo.y] = 1;

            var dir = Dir.Right;
            var step = 2;
            var currentPoint = (x: origo.x + 1, y: origo.y);

            while (true)
            {
                var sumOfAdjacentSquares = matrix.GetSumOfAdjacentSquares(currentPoint);
                matrix[currentPoint.x][currentPoint.y] = sumOfAdjacentSquares;

                if (sumOfAdjacentSquares >= targetValue)
                {
                    break;
                }

                var newDir = dir + 1 > Dir.Down
                    ? Dir.Right
                    : dir + 1;

                var nextPoint = NextPoint(newDir, currentPoint);

                if (matrix[nextPoint.x][nextPoint.y] == 0)
                {
                    currentPoint = nextPoint;
                    dir = newDir;
                }
                else
                {
                    currentPoint = NextPoint(dir, currentPoint);
                }

                step++;
            }

            return (step, matrix[currentPoint.x][currentPoint.y]);
        }

        private static int[][] InitializeMatrix()
        {
            return Enumerable.Range(0, Dim)
                .Select(i => new int[Dim])
                .ToArray();
        }

        #endregion

        enum Dir
        {
            Right = 1,
            Up,
            Left,
            Down
        }

        private static (int x, int y) NextPoint(Dir newDir, (int x, int y) nextPoint)
        {
            switch (newDir)
            {
                case Dir.Right:
                    nextPoint.x += 1;
                    break;
                case Dir.Up:
                    nextPoint.y += 1;
                    break;
                case Dir.Left:
                    nextPoint.x -= 1;
                    break;
                case Dir.Down:
                    nextPoint.y -= 1;
                    break;
            }
            return nextPoint;
        }
    }

    public static class MatrixExtensions
    {
        public static int GetSumOfAdjacentSquares(this int[][] matrix, (int x, int y) point)
        {
            return
                matrix[point.x + 1][point.y] +
                matrix[point.x - 1][point.y] +
                matrix[point.x][point.y + 1] +
                matrix[point.x][point.y - 1] +
                matrix[point.x + 1][point.y + 1] +
                matrix[point.x - 1][point.y - 1] +
                matrix[point.x + 1][point.y - 1] +
                matrix[point.x - 1][point.y + 1];
        }
    }
}
