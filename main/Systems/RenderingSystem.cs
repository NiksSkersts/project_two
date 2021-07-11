using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities.Systems;

namespace main.Systems
{
    public class RenderingSystem : DrawSystem
    {
        private readonly SpriteBatch _batch;

        public RenderingSystem(SpriteBatch batch)
        {
            _batch = batch;
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var tile in Grid.Tiles)
            {
                _batch.Draw(tile.Value.Texture,
                    new Vector2(tile.Key.X*tile.Value.Size.Width,tile.Key.Y*tile.Value.Size.Height),
                    Color.White
                    );
            }
        }
    }
}