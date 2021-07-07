using Microsoft.Xna.Framework;
using Nez;

namespace main.Components
{
    public class ObjLayerRenderer : RenderableComponent, IUpdatable
    {
        private Map.BuildingBlocks.Map Map;
        public override float Width => Settings.X*Settings.TileSize;
        public override float Height => Settings.Y*Settings.TileSize;

        public ObjLayerRenderer(Map.BuildingBlocks.Map map)
        {
            Map = map;
        }

        public override void Render(Batcher batcher, Camera camera)
        {
            DrawObjectLayer();
        }

        public void Update()
        {
        }
        private void DrawObjectLayer()
        {
            for (int x = 0; x < Settings.X; x++)
            {
                for (int y = 0; y < Settings.Y; y++)
                {
                    for (int i = 0; i < Settings.TileSize/Settings.GridSize; i++)
                    {
                        for (int j = 0; j < Settings.TileSize/Settings.GridSize; j++)
                        {
                            Graphics.Instance.Batcher.DrawHollowRect(
                                new Rectangle(
                                    new Point((i*Settings.GridSize)+(x*Settings.TileSize),(j*Settings.GridSize)+(y*Settings.TileSize)),
                                    new Point(Settings.GridSize,Settings.GridSize)),
                                new Color(Color.White, 0),0f);
                        }
                    }
                }
            }
        }
    }
}