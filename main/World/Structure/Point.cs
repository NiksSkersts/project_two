using System;

namespace main.World.Structure
{
    public class Point : IComparable<Point>, IComparable
    {
        public long X { get; set; }
        public long Y { get; set; }

        public Point(long x, long y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(Point other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var xComparison = X.CompareTo(other.X);
            if (xComparison != 0) return xComparison;
            return Y.CompareTo(other.Y);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is Point other
                ? CompareTo(other)
                : throw new ArgumentException($"Object must be of type {nameof(Point)}");
        }
    }
}