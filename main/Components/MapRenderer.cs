using System;
using main.Content;
using main.Map.BuildingBlocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace main.Components
{
    public class MapRenderer : RenderableComponent, IUpdatable
    {
        private World _world;
        public override float Width => Settings.X*Settings.TileSize;
        public override float Height => Settings.Y*Settings.TileSize;
        public override void Render(Batcher batcher, Camera camera)
        {
            DrawMap();
        }

        public MapRenderer(World world)
        {
            //todo - make textures have smoother transition on texture borders. e.g: water -> sand.
            _world = world;
        }

        private void DrawMap()
        {
            for (int x = 0; x < Settings.X; x++)
            {
                for (int y = 0; y < Settings.Y; y++)
                {
                    Draw(x,y);
                }
            }
        }

        private void Draw(int x, int y)
        {
            // todo recheck the function. Distorted image in result.
            //nvm, my brain died
            var terrainType = _world.Tiles[x, y].TerrainType;
            switch (terrainType)
            {
                case TerrainType.None:
                    break;
                case TerrainType.Water:
                    DrawFunc(Textures.Water1);
                    break;
                case TerrainType.Sand:
                    DrawFunc(Textures.Sand1);
                    break;
                case TerrainType.Grass:
                    DrawFunc(Textures.Grass1);
                    break;
                case TerrainType.Mountain:
                    DrawFunc(Textures.Cobble1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            void DrawFunc(Texture2D texture2D)
            {
                Graphics.Instance.Batcher.Draw(texture2D, 
                    new Rectangle(new Point(x*Settings.TileSize,Settings.TileSize*y), new Point(Settings.TileSize,Settings.TileSize)));
            }
        }

        public void Update()
        {
        }
    }
}