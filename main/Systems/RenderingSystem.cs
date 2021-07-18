using System;
using System.Linq;
using Dcrew.Camera;
using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities.Systems;
using Point = Microsoft.Xna.Framework.Point;

namespace main.Systems
{
    public class RenderingSystem : DrawSystem
    {
        private readonly SpriteBatch _batch;
        private readonly OrthographicCamera _camera;
        public RenderingSystem(SpriteBatch batch, OrthographicCamera camera)
        {
            _camera = camera;
            _batch = batch;
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var chunk in ChunkMap.Map.Values)
            {
                foreach (var tile in chunk)
                {
                    _batch.Draw(
                        tile.Terrain,
                        new Rectangle(new Point(tile.X*Settings.RenderSize,tile.Y*Settings.RenderSize),new Point(Settings.RenderSize)),
                        Color.White);   
                }
            }
        }
    }
}