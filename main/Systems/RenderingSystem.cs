using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities.Systems;
using Point = main.World.Structure.Point;

namespace main.Systems
{
    public class RenderingSystem : DrawSystem
    {
        private readonly SpriteBatch _batch;
        private readonly OrthographicCamera _camera;

        public RenderingSystem(SpriteBatch batch, OrthographicCamera camera)
        {
            _batch = batch;
            this._camera = camera;
        }

        public override void Draw(GameTime gameTime)
        {
            for (var i = (_camera.Position.ToPoint().X/(Settings.X))-Settings.X; i < (_camera.Position.ToPoint().X/(Settings.X))+Settings.X; i++)
            {
                for (var j = (_camera.Position.ToPoint().Y/(Settings.Y))-Settings.RenderSize; j < (_camera.Position.ToPoint().Y/(Settings.Y))+Settings.RenderSize; j++)
                {
                    if (Grid.Tiles.ContainsKey(new Point(i,j)))
                    {
                        _batch.Draw(Grid.Tiles[new Point(i, j)].Texture,
                            new Vector2(Grid.Tiles[new Point(i, j)].Location.X * Grid.Tiles[new Point(i, j)].Size.Width,
                                Grid.Tiles[new Point(i, j)].Location.Y * Grid.Tiles[new Point(i, j)].Size.Height),
                            Color.White);
                    }
                }
            }
        }
    }
}