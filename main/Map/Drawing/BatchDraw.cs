using System.Linq;
using main.Map.BuildingBlocks;
using main.Map.WorldGen;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using main.Content;
using main.Settings;
using Microsoft.Xna.Framework;

namespace main.Map.Drawing
{
    public class BatchDraw : IDraw
    {
        private IWorld _world;
        public void Draw(World world, SpriteBatch batch, GraphicsDevice device, ContentManager contentManager,
            IWorld worldSettings)
        {
            _world = worldSettings;
            for (int x = 0; x < world._x; x++)
            {
                for (int y = 0; y < world._y; y++)
                {
                    CallBatch(batch,device,world.Tiles[x,y],contentManager,x,y);
                }
                
            }
        }
        

        private void CallBatch(SpriteBatch batch,GraphicsDevice device,Tile tiles, ContentManager contentManager,int x,int y)
        {
            if (tiles.TerrainType == TerrainType.Grass)
            {
                DrawRect("grass");
            }else if (tiles.TerrainType == TerrainType.None)
            {
                DrawRect("tree");
            }else if (tiles.TerrainType == TerrainType.Sand)
            {
                DrawRect("sand");
            }else if (tiles.TerrainType == TerrainType.Water)
            {
                DrawRect("shallow_water");
            }else if (tiles.TerrainType == TerrainType.Mountain)
            {
                DrawRect("mountain");
            }

            void DrawRect(string terrain)
            {
                batch.Draw(
                    CManager.TileTexture2D(contentManager).Single(p=>p.Name.Equals(terrain)),
                    new Vector2(x*_world.TileSize,y*_world.TileSize),
                    new Rectangle(
                        new Point(x*_world.TileSize,y*_world.TileSize),
                        new Point((x*_world.TileSize)+_world.TileSize,(y*_world.TileSize)+_world.TileSize)),
                    Color.Aqua);
            }
        }
    }
}