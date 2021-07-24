using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace main.Content
{
    public static class Textures
    {
        //todo add other textures!
        public static void LoadTexture2D(ContentManager contentManager)
        {
            AGrass= contentManager.Load<Texture2D>("Artsy\\noisy-grass");
             AGroundDark= contentManager.Load<Texture2D>("Artsy\\noisy-grounddark");
             ALava= contentManager.Load<Texture2D>("Artsy\\noisy-lava");
             ARock= contentManager.Load<Texture2D>("Artsy\\noisy-rock");
             ARockHigh= contentManager.Load<Texture2D>("Artsy\\noisy-rockhigh");
             ASand= contentManager.Load<Texture2D>("Artsy\\noisy-sand");
             ASandWhite= contentManager.Load<Texture2D>("Artsy\\noisy-sandwhite");
             ASwamp= contentManager.Load<Texture2D>("Artsy\\noisy-swamp");
             AWaterDeep= contentManager.Load<Texture2D>("Artsy\\noisy-waterdeep");
             Water= contentManager.Load<Texture2D>("Artsy\\water");
             //New Textures
             Grass= contentManager.Load<Texture2D>("Artsy\\grass");
             GrassS= contentManager.Load<Texture2D>("Artsy\\grass_s");
        }

        public static Texture2D Grass { get; set; }
        public static Texture2D GrassS { get; set; }

        public static Texture2D Water { get; set; }

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