using main.World.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace main.World.Structs
{
    public struct Tile
    {
        public Texture2D Texture;
        public Point Coordinates;
        public float Height;
        public Tile(Texture2D texture, Point coordinates, float height)
        {
            Texture = texture;
            Coordinates = coordinates;
            Height = height;
        }
    }
}