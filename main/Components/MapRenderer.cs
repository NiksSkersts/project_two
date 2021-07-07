using System;
using main.Content;
using main.Map.BuildingBlocks;
using main.Map.Generation.Arrays;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace main.Components
{
    public class MapRenderer : RenderableComponent, IUpdatable
    {
        private Camera _camera;
        private Map.BuildingBlocks.Map Map;
        public override float Width => Settings.X*Settings.TileSize;
        public override float Height => Settings.Y*Settings.TileSize;
        public override void Render(Batcher batcher, Camera camera)
        {
            _camera = camera;
            DrawMapLayer();
        }
        public MapRenderer(Map.BuildingBlocks.Map map)
        {
            //todo - make textures have smoother transition on texture borders. e.g: water -> sand.
            Map = map;
        }

        private void DrawMapLayer()
        {
            for (int x = (int) (_camera.Bounds.X/Settings.TileSize); x <= ((_camera.Bounds.Width+_camera.Bounds.X)/Settings.TileSize) ; x++)
            {
                for (int y = (int) (_camera.Bounds.Y/Settings.TileSize) ; y <= ((_camera.Bounds.Y+_camera.Bounds.Height)/Settings.TileSize); y++)
                {
                    if (x>=32 || y>=32 || x<0 || y<0)
                    {
                        return;
                    }
                    else
                    {
                        Draw(x,y);
                    }

                }
            }
            
        }
        private void Draw(int x, int y)
        {
            // todo recheck the function. Distorted image in result.
            //nvm, my brain died
            var terrainType = Map.MapLayer.Tiles[x, y].TerrainType;
            switch (terrainType)
            {
                case TerrainType.None:
                    break;
                case TerrainType.Water:
                    DrawFunc(Textures.AWaterShallow);
                    break;
                case TerrainType.Sand:
                    DrawFunc(Textures.ASand);
                    break;
                case TerrainType.Grass:
                    DrawFunc(Textures.AGrass);
                    break;
                case TerrainType.Mountain:
                    DrawFunc(Textures.ARock);
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