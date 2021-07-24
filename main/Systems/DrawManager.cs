using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Collections.Pooled;
using DefaultEcs.System;
using main.Content;
using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Texture = main.World.Structure.Texture;

namespace main.Systems
{
    public class DrawManager : ISystem<int>
    {
        public bool IsEnabled { get; set; }
        private readonly SpriteBatch _spriteBatch;
        private readonly Camera _camera;
        private readonly SortedList<(int x, int y), Chunk<object>> _chunks =
            new SortedList<(int x, int y), Chunk<object>>(Settings.MaxLoadedChunks);

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
            #region Debug

            #endregion

            var newposx = (int) ((_camera.Pos.X / Settings.X) / Settings.X) * Settings.X;
            var newposy = (int) ((_camera.Pos.Y) / Settings.Y / Settings.Y) * Settings.Y;
            for (var i = -32 + (newposx); i <= 32 + (newposx); i += 32)
            {
                for (var j = -32 + (newposy); j <= 32 + (newposy); j += 32)
                {
                    if (_chunks.ContainsKey((i, j)) != false) continue;
                    _chunks.Add((i, j), ChunkMap.Map.Single(p => p.Key == (i, j)).Value);
                }
            }

            if (_chunks == null) return;
            foreach (var chunk in _chunks.AsEnumerable())
            {
                foreach (var tile in chunk.Value)
                {
                    switch (tile.Terrain)
                    {
                        case Texture.GrassSavana:
                            Render(Textures.GrassS, tile);
                            break;
                        case Texture.Grass:
                            Render(Textures.Grass, tile);
                            break;
                        case Texture.Water:
                            Render(Textures.Water, tile);
                            break;
                        case Texture.WaterDeep:
                            Render(Textures.AWaterDeep, tile);
                            break;
                        case Texture.Hill:
                            Render(Textures.ARock, tile);
                            break;
                        case Texture.Mountain:
                            Render(Textures.ARockHigh, tile);
                            break;
                        case Texture.Sand:
                            Render(Textures.ASand, tile);
                            break;
                        case Texture.Swamp:
                            Render(Textures.ASwamp, tile);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            while (_chunks.Count > Settings.MaxLoadedChunks)
            {
                _chunks.RemoveAt(0);
            }
        }

        private void Render<T>(Texture2D texture, Tile<T> tile)
        {
            _spriteBatch.Draw(
                texture,
                new Vector2(tile.X * Settings.X, tile.Y * Settings.Y),
                color: Color.White);
        }
    }
}