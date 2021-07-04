using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using main.Content;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace main.Map
{
    public class Tile
    {
        public static int TileSize { get; set; }
        private Texture2D Grass;
        private Texture2D Dirt;

        public Tile(ContentManager contentManager)
        {
            Grass = CManager.TileTexture2D(contentManager).First();
        }

        public void Draw(SpriteBatch batch, int drawX, int drawY)
        {
            batch.Draw(Grass,new Rectangle(location:new Point(x:(drawX*TileSize),y:(drawY*TileSize)),size:new Point(value: TileSize)),Color.Aqua);
        }
    }
}