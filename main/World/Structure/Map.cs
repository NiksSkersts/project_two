using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework;

namespace main.World.Structure
{
    public abstract class Map
    {
        public static SortedList<(int width, int height), Chunk> _map = new SortedList<(int width, int height), Chunk>();

        public static void Enque(int x, int y)
        {
            for (var i = -32 + x; i <= 32 + x; i += 32)
            for (var j = -32 + y; j <= 32 + y; j += 32)
            {
                if (_map.ContainsKey((i,j))) continue;
                _map.Add((i,j), new Chunk((i,j)));
            }
        }
    }
}