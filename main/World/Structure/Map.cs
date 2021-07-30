using System.Collections.Generic;

namespace main.World.Structure
{
    public abstract class Map
    {
        public static readonly SortedList<(int width, int height), Chunk> _map = new SortedList<(int width, int height), Chunk>();
        public static SortedList<(int x, int y), Object> ObjMap = new SortedList<(int x, int y), Object>();
    }
}