using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using main.Content;
using Microsoft.Xna.Framework;

namespace main.World.Structure
{
    public abstract class Map
    {
        public static SortedList<(int width, int height), Chunk> _map = new SortedList<(int width, int height), Chunk>();
        public static SortedList<(int x, int y), Object> ObjMap = new SortedList<(int x, int y), Object>();
    }
}