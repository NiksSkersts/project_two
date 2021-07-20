using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Collections.Pooled;
using DefaultEcs.System;
using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace main.Systems
{
    public class DrawManager : ISystem<int>
    {
        public bool IsEnabled { get; set; }
        private readonly SpriteBatch _spriteBatch;
        private readonly Camera _camera;
        private readonly PooledQueue<Chunk<object>> _pooledQueue = new PooledQueue<Chunk<object>>(Settings.MaxLoadedChunks);
        private readonly PooledQueue<(int x, int y)> _keys = new PooledQueue<(int x, int y)>(Settings.MaxLoadedChunks);

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
            // foreach (var tile in ChunkMap.Map.SelectMany(chunk => chunk.Value))
            // {
            //     _spriteBatch.Draw(
            //         tile.Terrain,
            //         new Vector2(tile.X * Settings.RenderSize, tile.Y * Settings.RenderSize),
            //         Color.White);
            // }
            // foreach (var t in ChunkMap.Map.Where(pair => pair.Key == (newposx,newposy)).Select(p=>p))
            // {
            //     if (Keys.Contains((newposx,newposy))==false)
            //     {
            //         PooledQueue.Enqueue(t.Value);
            //         Keys.Enqueue(t.Key);
            //     }
            // }
            #endregion
            var newposx = (int) ((_camera.Pos.X / Settings.X) / Settings.X) * Settings.X;
            var newposy = (int) ((_camera.Pos.Y) / Settings.Y / Settings.Y) * Settings.Y;
            for (var i = -32 + (newposx); i <= 32 + (newposx); i += 32)
            {
                for (var j = -32 + (newposy); j <= 32 + (newposy); j += 32)
                {
                    if (_keys.Contains((i, j)) != false) continue;
                    _pooledQueue.Enqueue(ChunkMap.Map.Single(p => p.Key == (i, j)).Value);
                    _keys.Enqueue(ChunkMap.Map.Single(p => p.Key == (i, j)).Key);
                }
            }

            if (_pooledQueue == null) return;
            foreach (var chunk in _pooledQueue.AsEnumerable())
            {
                foreach (var tile in chunk)
                {
                    _spriteBatch.Draw(tile.Terrain,
                        new Vector2(tile.X * Settings.RenderSize, tile.Y * Settings.RenderSize), Color.White);
                }
            }

            if (_pooledQueue.Count <= Settings.MaxLoadedChunks) return;
            _pooledQueue.Dequeue();
            _keys.Dequeue();
        }
    }
}