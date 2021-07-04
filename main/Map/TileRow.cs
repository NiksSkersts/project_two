using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace main.Map
{
    public class TileRow
    {
        private List<Tile> Row = new();
        private int rowLength;

        public TileRow(int theLength, int yIndex, ContentManager theContent)
        {
            rowLength = theLength;

            // Here the tiles are created and added to the row
            for (int x = 0; x < rowLength; x++)
            {
                var thisTile = new Tile(theContent);
                Row.Add(thisTile);
            }
        }

        /// 
        /// Draw -- invokes the draw method of each tile in the row
        /// 
        public void DrawRow(SpriteBatch theBatch, int currentY)
        {
            for (var x = 0; x < rowLength; x++)
            {
                Row[x].Draw(theBatch, x,currentY);
            }
        }
    }
}