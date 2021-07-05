using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace main.Content
{
    public static class CManager
    {
        public static Texture2D Grass;
        public static Texture2D Tree;
        public static Texture2D DeepWater;
        public static Texture2D ShallowWater;
        public static Texture2D Sand;
        public static Texture2D Mountain;
        public static void LoadTextures(ContentManager contentManager)
        {
            contentManager.RootDirectory = "/home/niks_skersts/Sources/project_two/main/Content/MapObjects";
            Grass = contentManager.Load<Texture2D>(@"grass");
            Tree = contentManager.Load<Texture2D>(@"tree");
            DeepWater = contentManager.Load<Texture2D>(@"deep_water");
            ShallowWater = contentManager.Load<Texture2D>(@"shallow_water");
            Sand = contentManager.Load<Texture2D>(@"sand");
            Mountain = contentManager.Load<Texture2D>(@"mountain");


        }
    }
}