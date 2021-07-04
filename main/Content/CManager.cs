using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace main.Content
{
    public static class CManager
    {
        private static IEnumerable<Texture2D> TileList;
        public static IEnumerable<Texture2D> TileTexture2D(ContentManager contentManager)
        {
            TileList = new[] {contentManager.Load<Texture2D>(@"test")};
            return TileList;
        }
    }
}