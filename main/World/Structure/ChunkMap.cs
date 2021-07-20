using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace main.World.Structure
{
    public class ChunkMap : IDisposable
    {
        public static SortedList<(int x, int y), Chunk<object>> Map { get; } =
            new SortedList<(int x, int y), Chunk<object>>();

        public static void Enque(Vector2 pos)
        {
            var (x, y) = pos;
            var newposx = (int) (x / Settings.X) * Settings.X;
            var newposy = (int) (y / Settings.Y) * Settings.Y;
            for (var i = -32 + newposx; i <= 32 + newposx; i += 32)
            for (var j = -32 + newposy; j <= 32 + newposy; j += 32)
            {
                if (Map.ContainsKey((i, j))) continue;
                Map.Add((i, j), new Chunk<object>(i, j));
            }
        }
        public void Dispose()
        {
        }
    }
}