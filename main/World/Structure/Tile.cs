using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collections;
using SD.Tools.BCLExtensions.CollectionsRelated;

namespace main.World.Structure
{
    public struct Tile
    {
        public Texture2D Texture;
        public float Height;
        public Size2 Size;
        public Point Location;
        public Tile(Texture2D texture, float height, Point location)
        {
            Size = new Size2(Settings.X, Settings.Y);
            Texture = texture;
            Height = height;
            Location = location;
        }
    }
}