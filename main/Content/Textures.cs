using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace main.Content
{
    public static class Textures
    {
        private static ContentManager _contentManager;
        //todo add other textures!
        private static Texture2D GAtlas { get; set; }
        private static Texture2D WAtlas { get; set; }
        public static void LoadTexture2D(ContentManager contentManager)
        {
            _contentManager = contentManager;
            GAtlas = contentManager.Load<Texture2D>("GAtlas");
            WAtlas = contentManager.Load<Texture2D>("WAtlas");
            Grass = new SortedList<string, Texture>
             {
                 {"grass",new Texture(GAtlas,new Rectangle(0,0,32,32),new Vector2(0.5f,0.5f))},
                 {"water_q1",new Texture(GAtlas,new Rectangle(33,0,32,32),new Vector2(0.5f,0.5f))},
                 {"water_q2",new Texture(GAtlas,new Rectangle(66,0,32,32),new Vector2(0.5f,0.5f))},
                 {"water_q3",new Texture(GAtlas,new Rectangle(0,33,32,32),new Vector2(0.5f,0.5f))},
                 {"water_q7",new Texture(GAtlas,new Rectangle(33,33,32,32),new Vector2(0.5f,0.5f))},
                 {"water_q9",new Texture(GAtlas,new Rectangle(66,33,32,32),new Vector2(0.5f,0.5f))}
             };
             Water = new SortedList<string, Texture>()
             {
                 {"water", new Texture(WAtlas, new Rectangle(0, 0, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_full", new Texture(WAtlas, new Rectangle(33, 0, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_q1", new Texture(WAtlas, new Rectangle(66, 0, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_q2", new Texture(WAtlas, new Rectangle(0, 33, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_q3", new Texture(WAtlas, new Rectangle(33, 33, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_q4", new Texture(WAtlas, new Rectangle(0, 66, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_q6", new Texture(WAtlas, new Rectangle(33, 66, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_q7", new Texture(WAtlas, new Rectangle(66, 33, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_q8", new Texture(WAtlas, new Rectangle(66, 66, 32, 32), new Vector2(0.5f, 0.5f))},
                 {"water_q9", new Texture(WAtlas, new Rectangle(99, 0, 32, 32), new Vector2(0.5f, 0.5f))}
             };
        }

        public static SortedList<string, Texture> Grass { get; private set; }
        public static SortedList<string, Texture> Water { get; private set; }
    }
}