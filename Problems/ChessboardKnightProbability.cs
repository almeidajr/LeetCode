// DESCRIPTION: https://leetcode.com/problems/knight-probability-in-chessboard/

namespace Problems;

public sealed class ChessboardKnightProbability
{
    private readonly Point[] _possibleMoves =
    {
        new(1, 2),
        new(2, 1),
        new(2, -1),
        new(1, -2),
        new(-1, -2),
        new(-2, -1),
        new(-2, 1),
        new(-1, 2)
    };

    public double KnightProbability(int n, int k, int row, int column)
    {
        var board = new Board(n);
        var startPoint = new Point(row, column);

        if (!board.Contains(startPoint)) return Probability.Min;
        if (k <= 0) return Probability.Max;

        var current = new double[board.Size, board.Size];
        current[row, column] = 1;
        foreach (var _ in Enumerable.Range(1, k))
        {
            var next = new double[board.Size, board.Size];
            for (var i = 0; i < board.Size; i++)
            {
                for (var j = 0; j < board.Size; j++)
                {
                    foreach (var possibleMove in _possibleMoves)
                    {
                        var point = new Point(i, j).Move(possibleMove);
                        next[i, j] += board.Contains(point) ? current[point.Row, point.Column] : 0;
                    }
                }
            }

            current = next;
        }


        var probability = new Probability(Math.Pow(_possibleMoves.Length, k));
        for (var i = 0; i < board.Size; i++)
        {
            for (var j = 0; j < board.Size; j++)
            {
                probability.Add(current[i, j]);
            }
        }

        return probability.Calculate();
    }

    private class Point
    {
        internal Point(int row, int column)
        {
            Row = row;
            Column = column;
        }

        internal int Row { get; }
        internal int Column { get; }

        internal Point Move(Point point)
        {
            return new Point(Row + point.Row, Column + point.Column);
        }
    }

    private class Board
    {
        private const int Minimum = 0;
        private readonly int _maximum;

        internal Board(int size)
        {
            Size = size;
            _maximum = size - 1;
        }

        internal int Size { get; }

        internal bool Contains(Point point)
        {
            var horizontal = point.Row >= Minimum && point.Row <= _maximum;
            var vertical = point.Column >= Minimum && point.Column <= _maximum;
            return horizontal && vertical;
        }
    }

    private class Probability
    {
        public const double Min = 0;
        public const double Max = 1;

        private readonly double _possible;
        private double _favorable;

        internal Probability(double possible)
        {
            _possible = possible;
        }

        internal void Add(double cases)
        {
            _favorable += cases;
        }

        internal double Calculate()
        {
            return _favorable / _possible;
        }
    }
}