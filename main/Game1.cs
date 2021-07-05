using System.Threading;
using main.Map;
using main.Map.Drawing;
using main.Map.WorldGen;
using main.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using MonoGame.Extended.ViewportAdapters;

namespace main
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private OrthographicCamera _camera;
        private ICamera _cameraSettings;
        private IWorldGen _gen;
        private Vector2 _worldPosition;
        private IWorld _worldSettings;
        private ISettings _settings;
        private World _world;
        private IDraw _draw;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _cameraSettings = new Camera();
            _worldSettings = new WorldSettings();
            _settings = new Settings.Settings(_cameraSettings,_worldSettings);
            _gen = new RandomMapGenerator();
            _draw = new BatchDraw();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _settings.LoadSettings();
            _world = _gen.Generate(_worldSettings.X, _worldSettings.Y);
            _camera = new OrthographicCamera(_cameraSettings.ViewportAdapter(Window,_graphics.GraphicsDevice));
        }

        protected override void Update(GameTime gameTime)
        {
            _camera.Move(_cameraSettings.GetMovementDirection() * _cameraSettings.MovementSpeed * gameTime.GetElapsedSeconds());
            var mouseState = Mouse.GetState();
            _worldPosition = _camera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(new Color(Color.Black, 0f));
            var transformMatrix = _camera.GetViewMatrix();
            _spriteBatch.Begin(SpriteSortMode.Deferred,transformMatrix: transformMatrix);
            _draw.Draw(_world,_spriteBatch,_graphics.GraphicsDevice,Content,_worldSettings);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}