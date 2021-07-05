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
        private static IEnumerable<Texture2D> TileList;
        public static IEnumerable<Texture2D> TileTexture2D(ContentManager contentManager)
        {
            contentManager.RootDirectory = "/home/niks_skersts/Sources/project_two/main/Content/MapObjects";
            TileList = new[]
            {
                contentManager.Load<Texture2D>(@"grass"),
                contentManager.Load<Texture2D>(@"tree"),
                contentManager.Load<Texture2D>(@"deep_water"),
                contentManager.Load<Texture2D>(@"shallow_water"),
                contentManager.Load<Texture2D>(@"sand"),
                contentManager.Load<Texture2D>(@"mountain")
            };
            return TileList;
        }
    }
}