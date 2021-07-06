using main.Content;
using main.Map.BuildingBlocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace main.Entities
{
    public class MapRenderer : RenderableComponent, IUpdatable
    {
        private World _world;
        public override float Width => Settings.X*Settings.X;
        public override float Height => Settings.Y*Settings.Y;

        public MapRenderer(World world)
        {
            _world = world;
        }

        public override void Render(Batcher batcher, Camera camera)
        {
            
            DrawMap();
        }

        public void Update()
        {
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
            DrawFunc();
            // todo recheck the function. Distorted image in result.
            void DrawFunc()
            {
                Graphics.Instance.Batcher.Draw(Textures.Grass1,
                    new Rectangle(
                        new Point(
                            x*Settings.TileSize,Settings.TileSize*y),
                        new Point((x*Settings.TileSize)+Settings.TileSize,(y*Settings.TileSize)+Settings.TileSize))
                );
            }
        }
    }
}