using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Content;

namespace main.Content
{
    public static class Textures
    {
        //todo add other textures!
        public static void LoadTexture2D(ContentManager contentManager)
        {
            AGrass= contentManager.Load<Texture2D>("Artsy/noisy-grass");
             AGroundDark= contentManager.Load<Texture2D>("Artsy/noisy-grounddark");
             ALava= contentManager.Load<Texture2D>("Artsy/noisy-lava");
             ARock= contentManager.Load<Texture2D>("Artsy/noisy-rock");
             ARockHigh= contentManager.Load<Texture2D>("Artsy/noisy-rockhigh");
             ASand= contentManager.Load<Texture2D>("Artsy/noisy-sand");
             ASandWhite= contentManager.Load<Texture2D>("Artsy/noisy-sandwhite");
             ASwamp= contentManager.Load<Texture2D>("Artsy/noisy-swamp");
             AWaterDeep= contentManager.Load<Texture2D>("Artsy/noisy-waterdeep");
             AWaterShallow= contentManager.Load<Texture2D>("Artsy/noisy-watershallow");
             RectangleH = new Texture2D(contentManager.GetGraphicsDevice(), Settings.TileSize, Settings.TileSize);
        }
        public static Texture2D RectangleH { get; set; }
        public static Texture2D AWaterShallow { get; set; }

        public static Texture2D AWaterDeep { get; set; }

        public static Texture2D ASwamp { get; set; }

        public static Texture2D ASandWhite { get; set; }

        public static Texture2D ASand { get; set; }

        public static Texture2D ARockHigh { get; set; }

        public static Texture2D ARock { get; set; }

        public static Texture2D ALava { get; set; }

        public static Texture2D AGroundDark { get; set; }

        public static Texture2D AGrass { get; set; }






    }
}