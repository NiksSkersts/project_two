using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;

namespace main.Settings
{
    public class WorldSettings : IWorld
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int TileSize { get; set; }
        public int SeaLine { get; set; }
    }
}