
using Microsoft.Xna.Framework;

namespace main.Settings
{
    public interface IWorld
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int TileSize { get; set; }
        public int SeaLine { get; set; }
    }

    public interface ISettings
    {
        public void LoadSettings();
    }
}