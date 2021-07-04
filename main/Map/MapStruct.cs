using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace main.Map
{
    public class MapStruct
    {
        private List<TileRow> allRows = new();
        int depth;

        // Constructor
        public MapStruct(ContentManager theContent, int theDepth, int rowLength)
        {
            depth = theDepth;
            TileRow thisRow;

            // Here we make a row of tiles for each level of depth
            for (var y = 0; y < depth; y++)
            {
                thisRow = new TileRow(rowLength, depth, theContent);
                allRows.Add(thisRow);
            }
        }

        ///
        /// Draw - this method invokes the draw method in each tile row, which then draws each tile
        ///
        public void DrawMap(SpriteBatch theBatch)
        {
            for (var y = 0; y < depth; y++)
            {
                allRows[y].DrawRow(theBatch, y);
            }
        }
    }
}