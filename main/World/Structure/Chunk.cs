using System.Collections;
using System.Collections.Generic;
using main.World.Enum;

namespace main.World.Structure
{
    public class Chunk<T> : IReadOnlyCollection<Tile<T>>
    {
        private int Width { get; }
        private int Height { get; }
        public int Count { get; }
        private readonly T[,] _map;
        public Chunk(int height, int width )
        {
            Height = height;
            Width = width;
            _map = new T[Settings.X,Settings.Y];
        }

        public T this[int x, int y]
        {
            get => _map[x, y];
            set => _map[x, y] = value;
        }
        public IEnumerator<Tile<T>> GetEnumerator()
        {
            for (var x =Width-Settings.RenderSize/2;x< Width+Settings.RenderSize/2;x++)
            for (var y = Height-Settings.RenderSize/2; y < Height+Settings.RenderSize/2; y++)
            {
                yield return new Tile<T>(x, y);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}