using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace main.Content
{
    public readonly struct Texture
    {
        public Texture(Texture2D sprite, Rectangle sourceRectangle, Vector2 origin)
        {
            Sprite = sprite;
            SourceRectangle = sourceRectangle;
            Origin = origin;
        }
        public Texture2D Sprite { get;}
        public Rectangle SourceRectangle { get; }
        public Vector2 Origin { get; }
    }
}