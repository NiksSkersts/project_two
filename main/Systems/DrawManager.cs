using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DefaultEcs.System;
using main.Content;
using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Texture = SharpDX.Direct3D9.Texture;

namespace main.Systems
{
    public class DrawManager : ISystem<int>
    {
        public bool IsEnabled { get; set; }
        private readonly SpriteBatch _spriteBatch;
        private readonly Camera _camera;
        private readonly Queue<(int width, int height)> _loaded = new Queue<(int width, int height)>(Settings.MaxLoadedChunks);
        public DrawManager(SpriteBatch spriteBatch, Camera camera)
        {
            _spriteBatch = spriteBatch;
            _camera = camera;
        }

        public void Dispose()
        {
        }

        public void Update(int state)
        {
            
            var tileposx = (int) (((_camera.Pos.ToPoint().X / Settings.X)/Settings.X)*Settings.X)-Settings.X/2;
            var tileposy = (int) (((_camera.Pos.ToPoint().Y / Settings.Y)/Settings.Y)*Settings.Y)-Settings.X/2;
            for (int x = -32+tileposx; x < 32+tileposx; x+=32)
            {
                for (int y = -32+tileposy; y < 32+tileposy; y+=32)
                {
                    if (!_loaded.Contains((x,y)))
                    {
                        Map.Enque(tileposx,tileposy);
                        _loaded.Enqueue((x,y));
                    }
                }
            }
            foreach (var chunk in _loaded)
            {
                for (int i = chunk.width; i < chunk.width+Settings.X; i++)
                {
                    for (int j = chunk.height; j < chunk.height+Settings.Y; j++)
                    {
                        var tileinfo = Map._map[chunk][(i, j)];
                        Render(tileinfo.Item1,tileinfo.Item2);
                    }
                }
            }

            while (_loaded.Count>Settings.MaxLoadedChunks)
            {
                _loaded.Dequeue();
            }
        }

        private void Render(Tile tile, Content.Texture texture)
        {
            _spriteBatch.Draw(
                texture.Sprite,
                new Vector2((tile.Coordinates.X) * Settings.X, (tile.Coordinates.Y) * Settings.Y),
                color: Color.White,
                effects: SpriteEffects.None,
                rotation: 0f,
                origin: texture.Origin,
                scale: 1,
                sourceRectangle: texture.SourceRectangle,
                layerDepth: 0);
        }
        
    }
}