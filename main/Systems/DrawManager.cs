using DefaultEcs.System;
using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace main.Systems
{
    public class DrawManager : ISystem<int>
    {
        private readonly SpriteBatch _spriteBatch;

        public DrawManager(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Dispose()
        {
        }

        public void Update(int state)
        {
            foreach (var chu in ChunkMap.Map.Values)
            {
                foreach (var tile in chu)
                {
                    _spriteBatch.Draw(
                        tile.Terrain,
                        new Vector2(tile.X*Settings.RenderSize,tile.Y*Settings.RenderSize),
                        Color.White);
                }
            }
        }

        public bool IsEnabled { get; set; }
    }
}