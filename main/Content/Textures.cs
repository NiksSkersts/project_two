using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace main.Content
{
    public static class Textures
    {
        //todo add other textures!
        public static void LoadTexture2D()
        {
            Grass1 = Core.Content.LoadTexture("grass_tile");
        }
        public static Texture2D Grass1 { get; set; }
    }
}