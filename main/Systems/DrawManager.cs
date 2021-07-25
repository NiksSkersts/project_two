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
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using Texture = main.Content.Texture;

namespace main.Systems
{
    public class DrawManager : ISystem<int>
    {
        public bool IsEnabled { get; set; }
        private readonly SpriteBatch _spriteBatch;
        private readonly OrthographicCamera _camera;
        private readonly Queue<(int width, int height)> _loaded = new Queue<(int width, int height)>(Settings.MaxLoadedChunks);
        public DrawManager(SpriteBatch spriteBatch, OrthographicCamera camera)
        {
            _spriteBatch = spriteBatch;
            _camera = camera;
        }

        public void Dispose()
        {
        }

        public void Update(int state)
        {
            
            var tileposx = (int) (((_camera.Position.ToPoint().X / Settings.RenderSize)/Settings.RenderSize)*Settings.RenderSize);
            var tileposy = (int) (((_camera.Position.ToPoint().Y / Settings.RenderSize)/Settings.RenderSize)*Settings.RenderSize);
            for (int x = -Settings.RenderSize+tileposx; x < Settings.RenderSize+Settings.RenderSize+tileposx; x+=Settings.RenderSize)
            {
                for (int y = -Settings.RenderSize+tileposy; y < Settings.RenderSize+Settings.RenderSize+tileposy; y+=Settings.RenderSize)
                {
                    if (_loaded.Contains((x, y))) continue;
                    if (!Map._map.ContainsKey((x,y)))
                        Map._map.Add((x, y), new Chunk((x, y)));
                    _loaded.Enqueue((x, y));
                }
            }
            foreach (var chunk in _loaded)
            {
                for (int i = chunk.width; i < chunk.width+Settings.RenderSize; i++)
                {
                    for (int j = chunk.height; j < chunk.height+Settings.RenderSize; j++)
                    {
                        var tileinfo = Map._map[chunk][(i, j)];
                        Render(tileinfo.Item1,tileinfo.Item2,0); // render main

                    }
                }
            }

            foreach (var obj in Map.ObjMap)
            {
                RenderObj(obj);
            }

            while (_loaded.Count>Settings.MaxLoadedChunks)
            {
                _loaded.Dequeue();
            }
        }

        private void RenderObj(KeyValuePair<(int x, int y), Object> keyValuePair)
        {
            var (key, value) = keyValuePair;
            _spriteBatch.Draw(
                value.Texture,
                new Vector2((key.x) * Settings.X, (key.y) * Settings.Y),
                color: Color.White,
                effects: SpriteEffects.None,
                rotation: 0f,
                origin: Vector2.Zero, 
                scale: 1,
                sourceRectangle: null,
                layerDepth: 0);
        }

        private void Render(Tile tile, Texture texture, int layers)
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
                layerDepth: 1);
        }
        
    }
}