using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class Day5
    {
        const int RowRange = 127;
        const int ColRange = 8;
        const int RowLetterCount = 7;
        const int ColLetterCount = 3;
        const char RowLower = 'F';
        const char RowHigher = 'B';
        const char ColLower = 'L';
        const char ColHigher = 'R';
        private readonly IList<string> _boardingCards;

        public Day5(IEnumerable<string> boardingCards)
        {
            _boardingCards = boardingCards.ToList();
        }

        public int FindHighestSeatID()
        {
            return _boardingCards
                .Select(bc => GetSeat(bc).seatID)
                .Max();
        }

        public int FindMissingSeatID()
        {
            var seatIDs = _boardingCards
                .Select(bc => GetSeat(bc).seatID)
                .OrderBy(s => s);

            return Enumerable.Range(seatIDs.Min(), seatIDs.Count()).Except(seatIDs).First();
        }

        public (int row, int col, int seatID) GetSeat(string boardingCard)
        {
            int row = BinarySearch(boardingCard.Substring(0, RowLetterCount), RowRange, (RowLower, RowHigher));
            int col = BinarySearch(boardingCard.Substring(RowLetterCount, ColLetterCount), ColRange, (ColLower, ColHigher));

            return (row, col, row * 8 + col);
        }

        private static int BinarySearch(string boardingCardPart, int range, (char lower, char higher) dir)
        {
            int low = 0;
            int high = range;

            for (int i = 0; i < boardingCardPart.Length; i++)
            {
                var letter = boardingCardPart[i];
                var newRange = (high - low) / 2 + 1;

                if (letter == dir.higher)
                {
                    low = high - newRange + 1;
                }
                else if (letter == dir.lower)
                {
                    high -= newRange - 1;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Unknown character '{letter}'");
                }
            }

            return low;
        }
    }
}
