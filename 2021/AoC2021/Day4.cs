namespace AoC2021;

public class Day4
{
    class BingoBoard
    {
        class Number
        {
            public Number(int num)
            {
                Num = num;
            }

            public int Num { get; }
            public bool IsMarked { get; set; }
        }

        private readonly Number[][] _board =
        {
            new Number[5], new Number[5], new Number[5], new Number[5], new Number[5]
        };

        public BingoBoard(string board)
        {
            ParseBoard(board);
        }

        private void ParseBoard(string board)
        {
            var boardLines = board.Split("\r\n");

            for (int i = 0; i < boardLines.Length; i++)
            {
                var rowNumbers = boardLines[i]
                    .Split(" ")
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .ToArray();
                for (int j = 0; j < rowNumbers.Length; j++)
                {
                    _board[i][j] = new Number(Convert.ToInt32(rowNumbers[j]));
                }
            }
        }

        protected internal bool HasWinningRow()
        {
            var winningRowExists = _board.Any(r => r.All(n => n.IsMarked));
            var winningColExists = false;

            for (int i = 0; i < 5 && !winningColExists; i++)
            {
                winningColExists = _board.All(r => r[i].IsMarked);
            }

            return winningRowExists || winningColExists;
        }

        protected internal bool MarkNumberIfExists(int number)
        {
            var matches = _board
                .SelectMany(r => r.Where(n => n.Num == number))
                .ToList();
            
            matches.ForEach(n => n.IsMarked = true);

            return matches.Any();
        }

        public int SumNonMarkedNumbers()
        {
            return _board
                .SelectMany(r => r.Where(n => !n.IsMarked))
                .Sum(n => n.Num);
        }
    }

    private List<BingoBoard> BingoBoards { get; }
    private List<int> NumbersToPlay { get; }

    public Day4(string bingoInput)
    {
        var split = bingoInput
            .Split("\r\n\r\n")
            .Where(i => !string.IsNullOrWhiteSpace(i))
            .ToList();

        NumbersToPlay = split.First()
            .Split(",")
            .Select(n => Convert.ToInt32(n))
            .ToList();
        BingoBoards = split.Skip(1)
            .Select(b => new BingoBoard(b))
            .ToList();
    }

    public enum WinningStrategy
    {
        First,
        Last
    }

    public int PlayAndCalculateWinningBoardScore(WinningStrategy winningStrategy)
    {
        BingoBoard? winningBoard = null;
        var winningBoards = new List<BingoBoard>();
        var winningNumber = 0;
        var lastWon = false;

        foreach (int number in NumbersToPlay)
        {
            winningNumber = number;

            foreach (var board in BingoBoards)
            {
                var numberExists = board.MarkNumberIfExists(number);

                if (numberExists)
                {
                    winningBoard = board.HasWinningRow() ? board : null;
                }
                else
                {
                    continue;
                }

                if (winningBoard == null)
                {
                    continue;
                }

                if (winningStrategy == WinningStrategy.First)
                {
                    break;
                }

                if (!winningBoards.Contains(winningBoard))
                {
                    winningBoards.Add(winningBoard);
                }

                if (winningBoards.Count == BingoBoards.Count)
                {
                    lastWon = true;
                    break;
                }
            }

            if (winningStrategy == WinningStrategy.First && winningBoard != null)
            {
                break;
            }

            if (winningStrategy == WinningStrategy.Last && lastWon)
            {
                break;
            }
        }

        return winningBoard?.SumNonMarkedNumbers() * winningNumber ?? 0;
    }
}