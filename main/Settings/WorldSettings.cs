using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace main.Settings
{
    public class WorldSettings
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int TileSize { get; set; }
        public void LoadSettings()
        {
            X = Y = 64;
            TileSize = 64;
        }
    }
}