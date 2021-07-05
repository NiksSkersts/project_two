using System.Linq;
using main.Map.BuildingBlocks;
using main.Map.WorldGen;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using main.Content;
using main.Settings;
using Microsoft.Xna.Framework;
using Nez;

namespace main.Map.Drawing
{
    public class BatchDraw : IDraw
    {
        private IWorld _world;
        public void Draw(World world, ContentManager contentManager, IWorld worldSettings)
        {
            _world = worldSettings;
            for (int x = 0; x < world._x; x++)
            {
                for (int y = 0; y < world._y; y++)
                {
                    if (world.Tiles[x,y].TerrainType != TerrainType.None)
                    {
                        CallBatch(world.Tiles[x,y],contentManager,x,y);
                    }
                }
                
            }
        }

        private void CallBatch(Tile tiles, ContentManager contentManager,int x,int y)
        {
            if (tiles.TerrainType == TerrainType.Grass)
            {
                DrawRect(CManager.Grass);
            }else if (tiles.TerrainType == TerrainType.Sand)
            {
                DrawRect(CManager.Sand);
            }else if (tiles.TerrainType == TerrainType.Water)
            {
                DrawRect(CManager.DeepWater);
            }else if (tiles.TerrainType == TerrainType.Mountain)
            {
                DrawRect(CManager.Mountain);
            }

            void DrawRect(Texture2D texture2D)
            {
                Graphics.Instance.Batcher.Draw(texture2D,
                    new Vector2(x*_world.TileSize,y*_world.TileSize),
                    new Rectangle(
                        new Point(x*_world.TileSize,y*_world.TileSize),
                        new Point((x*_world.TileSize)+_world.TileSize,(y*_world.TileSize)+_world.TileSize)),
                    Color.Aqua);
            }
        }
    }
}