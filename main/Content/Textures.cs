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
            Cobble1= contentManager.Load<Texture2D>("MapObj/Cobble1");
             Dirt1= contentManager.Load<Texture2D>("MapObj/Dirt1");
             Dirt2= contentManager.Load<Texture2D>("MapObj/Dirt2");
             Dirt3= contentManager.Load<Texture2D>("MapObj/Dirt3");
             Dirt4= contentManager.Load<Texture2D>("MapObj/Dirt4");
             Dirt5= contentManager.Load<Texture2D>("MapObj/Dirt5");
             Grass1= contentManager.Load<Texture2D>("MapObj/Grass1");
             Grass2= contentManager.Load<Texture2D>("MapObj/Grass2");
             Grass3= contentManager.Load<Texture2D>("MapObj/Grass3");
             Grass4= contentManager.Load<Texture2D>("MapObj/Grass4");
             Grass5= contentManager.Load<Texture2D>("MapObj/Grass5");
             Grass6= contentManager.Load<Texture2D>("MapObj/Grass6");
             LGrass1= contentManager.Load<Texture2D>("MapObj/LGrass1");
             LGrass2= contentManager.Load<Texture2D>("MapObj/LGrass2");
             LGrass3= contentManager.Load<Texture2D>("MapObj/LGrass3");
             LGrass4= contentManager.Load<Texture2D>("MapObj/LGrass4");
             LGrass5= contentManager.Load<Texture2D>("MapObj/LGrass5");
             Sand1= contentManager.Load<Texture2D>("MapObj/Sand1");
             Sand2= contentManager.Load<Texture2D>("MapObj/Sand2");
             Sand3= contentManager.Load<Texture2D>("MapObj/Sand3");
             Water1= contentManager.Load<Texture2D>("MapObj/Water1");
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

        public static Texture2D Cobble1 { get; set; }
        public static Texture2D Dirt1 { get; set; }
        public static Texture2D Dirt2 { get; set; }
        public static Texture2D Dirt3 { get; set; }
        public static Texture2D Dirt4 { get; set; }
        public static Texture2D Dirt5 { get; set; }
        public static Texture2D Grass1 { get; set; }
        public static Texture2D Grass2 { get; set; }
        public static Texture2D Grass3 { get; set; }
        public static Texture2D Grass4 { get; set; }
        public static Texture2D Grass5 { get; set; }
        public static Texture2D Grass6 { get; set; }
        public static Texture2D LGrass1 { get; set; }
        public static Texture2D LGrass2 { get; set; }
        public static Texture2D LGrass3 { get; set; }
        public static Texture2D LGrass4 { get; set; }
        public static Texture2D LGrass5 { get; set; }
        public static Texture2D Sand1 { get; set; }
        public static Texture2D Sand2 { get; set; }
        public static Texture2D Sand3 { get; set; }
        public static Texture2D Water1 { get; set; }
        





    }
}