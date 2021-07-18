using System;
using Dcrew.Camera;
using main.World.Structure;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Entities.Systems;

namespace main.Systems
{
    public class ChunkManager : UpdateSystem
    {
        private readonly OrthographicCamera _camera;
        private readonly ChunkMap _chunkMap;
        public ChunkManager(OrthographicCamera camera)
        {
            this._camera = camera;
            _camera.Zoom = Settings.Zoom;
            _chunkMap = new ChunkMap();
            
        }
        public override void Update(GameTime gameTime)
        {
            _chunkMap.Enque((int)_camera.Position.X,(int)_camera.Position.Y);
            Console.WriteLine(_camera.Position);
        }
    }
}