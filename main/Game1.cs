using System;
using main.Camera;
using main.Content;
using main.Map.Drawing;
using main.Map.WorldGen;
using main.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace main
{
    public class Game1 : Nez.Core
    {
        private ICamera _camera;
        private IWorldGen _gen;
        private Vector2 _worldPosition;
        private IWorld _worldSettings;
        private ISettings _settings;
        private World _world;
        private IDraw _draw;


        public Game1()
        {
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _camera = new Camera.Camera();
            _worldSettings = new WorldSettings();
            _settings = new Settings.Settings(_worldSettings);
            _gen = new RandomMapGenerator();
            _draw = new BatchDraw();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _camera.LoadDefaults();
            CManager.LoadTextures(Content);
            _settings.LoadSettings();
            _world = _gen.Generate(_worldSettings.X, _worldSettings.Y);
        }

        protected override void Update(GameTime gameTime)
        {
            var cameraPos = _camera.Movement() * _camera.MovementSpeed;
            _camera.Pos -= cameraPos;
            _camera.Zoom = _camera.MouseZoom();
            _camera.Rotation = _camera.CameraRotation();
            Console.WriteLine(_camera.Pos);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            DrawMap();
            base.Draw(gameTime);
        }

        private void DrawMap()
        {
            Graphics.Instance.Batcher.Begin(transformationMatrix:_camera.ViewMatrix());
            _draw.Draw(_world,Content,_worldSettings);
            Graphics.Instance.Batcher.End();
        }
    }
}