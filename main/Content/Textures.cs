using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace main.Content
{
    public static class Textures
    {
        //todo add other textures!
        public static void LoadTexture2D()
        {
             Cobble1= Core.Content.LoadTexture("MapObj/Cobble1");
             Dirt1= Core.Content.LoadTexture("MapObj/Dirt1");
             Dirt2= Core.Content.LoadTexture("MapObj/Dirt2");
             Dirt3= Core.Content.LoadTexture("MapObj/Dirt3");
             Dirt4= Core.Content.LoadTexture("MapObj/Dirt4");
             Dirt5= Core.Content.LoadTexture("MapObj/Dirt5");
             Grass1= Core.Content.LoadTexture("MapObj/Grass1");
             Grass2= Core.Content.LoadTexture("MapObj/Grass2");
             Grass3= Core.Content.LoadTexture("MapObj/Grass3");
             Grass4= Core.Content.LoadTexture("MapObj/Grass4");
             Grass5= Core.Content.LoadTexture("MapObj/Grass5");
             Grass6= Core.Content.LoadTexture("MapObj/Grass6");
             LGrass1= Core.Content.LoadTexture("MapObj/LGrass1");
             LGrass2= Core.Content.LoadTexture("MapObj/LGrass2");
             LGrass3= Core.Content.LoadTexture("MapObj/LGrass3");
             LGrass4= Core.Content.LoadTexture("MapObj/LGrass4");
             LGrass5= Core.Content.LoadTexture("MapObj/LGrass5");
             Sand1= Core.Content.LoadTexture("MapObj/Sand1");
             Sand2= Core.Content.LoadTexture("MapObj/Sand2");
             Sand3= Core.Content.LoadTexture("MapObj/Sand3");
             Water1= Core.Content.LoadTexture("MapObj/Water1");
        }
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