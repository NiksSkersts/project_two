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
        private readonly SpriteBatch _spriteBatch;
        private readonly Camera _camera;
        private PooledQueue<Chunk<object>> PooledQueue = new PooledQueue<Chunk<object>>(Settings.MaxLoadedChunks);
        private PooledQueue<(int x, int y)> Keys = new PooledQueue<(int x, int y)>(Settings.MaxLoadedChunks);

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
            // foreach (var tile in ChunkMap.Map.SelectMany(chunk => chunk.Value))
            // {
            //     _spriteBatch.Draw(
            //         tile.Terrain,
            //         new Vector2(tile.X*Settings.RenderSize,tile.Y*Settings.RenderSize),
            //         Color.White);
            // }
            var newposx =(int) ((_camera.Pos.X/Settings.X) / Settings.X) * Settings.X;
            var newposy =(int) ((_camera.Pos.Y)/Settings.Y / Settings.Y) * Settings.Y;
            
            for (int i = -32+(newposx); i <= 32+(newposx); i += 32)
            {
                for (int j = -32+(newposy); j <= 32+(newposy); j +=32)
                {
                    if (Keys.Contains((i, j)) != false) continue;
                    PooledQueue.Enqueue(ChunkMap.Map.Single(p=>p.Key == (i,j)).Value);
                    Keys.Enqueue(ChunkMap.Map.Single(p=>p.Key == (i,j)).Key);
                }
            }
            // foreach (var t in ChunkMap.Map.Where(pair => pair.Key == (newposx,newposy)).Select(p=>p))
            // {
            //     if (Keys.Contains((newposx,newposy))==false)
            //     {
            //         PooledQueue.Enqueue(t.Value);
            //         Keys.Enqueue(t.Key);
            //     }
            // }
            foreach (var chunk in PooledQueue.AsEnumerable())
            {
                foreach (var tile in chunk)
                {
                    _spriteBatch.Draw(
                        tile.Terrain,
                        new Vector2(tile.X*Settings.RenderSize,tile.Y*Settings.RenderSize),
                        Color.White);
                }
            }

            if (PooledQueue.Count>Settings.MaxLoadedChunks)
            {
                PooledQueue.Dequeue();
                Keys.Dequeue();
            }
        }

        public bool IsEnabled { get; set; }
    }
}