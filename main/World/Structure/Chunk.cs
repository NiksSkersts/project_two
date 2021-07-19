using System.Collections;
using System.Collections.Generic;
using main.Content;
using Microsoft.Xna.Framework.Graphics;
using SimplexNoise;

namespace main.World.Structure
{
    public class Chunk<T> : IReadOnlyCollection<Tile<T>>
    {
        public int Width { get; }
        public int Height { get; }
        private readonly T[,] _map;
        public Chunk(int height, int width )
        {
            Height = height;
            Width = width;
            _map = new T[Settings.X,Settings.Y];
        }

        public T this[int x, int y]
        {
            get => this._map[x, y];
            set => this._map[x, y] = value;
        }
        public IEnumerator<Tile<T>> GetEnumerator()
        {
            for (var x =Width-Settings.RenderSize/2;x< Width+Settings.RenderSize/2;x++)
            for (var y = Height-Settings.RenderSize/2; y < Height+Settings.RenderSize/2; y++)
            {
                yield return new Tile<T>(x, y, this);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get; }
    }

    public readonly struct Tile<T>
    {
        private readonly Chunk<T> _chunk;
        public int X { get; }
        public int Y { get; }
        public Texture2D Terrain { get; }

        public Tile(int y, int x, Chunk<T> chunk)
        {
            Y = y;
            X = x;
            _chunk = chunk;
            Terrain = DetermineTerrain(DetermineHeight(x, y));
        }

        public T Value => this._chunk[this.X, this.Y];
        private static float DetermineHeight(int x, int y)
        {
            Noise.Seed = Settings.Seed;
            return Noise.CalcPixel2D(x,y,0.001f);
        }

        private static Texture2D DetermineTerrain(float height)
        {
            if (height >= 210) return Textures.ARockHigh;
            if (height <= 85) return Textures.ASand;
            if (height <= 80) return Textures.AWaterDeep;
            return Textures.AGrass;
        }
    }
}