
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;

namespace main.Settings
{
    public interface ICamera
    {
        public Vector2 GetMovementDirection();
        public BoxingViewportAdapter ViewportAdapter(GameWindow window, GraphicsDevice graphicsDevice);
        public float MovementSpeed { get; set; }
    }

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