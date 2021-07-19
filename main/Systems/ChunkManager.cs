using DefaultEcs.System;
using main.World.Structure;
using Microsoft.Xna.Framework;

namespace main.Systems
{
    public class ChunkManager : ISystem<int>
    {
        private readonly Camera _camera;

        public ChunkManager(Camera camera)
        {
            _camera = camera;
        }

        public void Dispose()
        {
        }

        public void Update(int state)
        {
            ChunkMap.Enque(new Vector2(_camera.Pos.X/Settings.X,_camera.Pos.Y/Settings.Y));
        }

        public bool IsEnabled { get; set; }
    }
}