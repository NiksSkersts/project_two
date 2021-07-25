using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using Texture = main.Content.Texture;

namespace main.World.Structure
{
    public readonly struct Object
    {
        public readonly Texture2D Texture;
        public Object(Texture2D texture)
        {
            Texture = texture;
        }
    }
}