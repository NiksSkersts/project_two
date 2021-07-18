using Dcrew.Camera;
using main.Content;
using main.Scenes;
using main.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.ViewportAdapters;
using Game = Microsoft.Xna.Framework.Game;

namespace main
{
    public class Game1 : Game
    {
        private readonly ScreenManager _screenManager;
        private MonoGame.Extended.Entities.World _world;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly KeyboardListener _keyboardListener;
        private OrthographicCamera _camera;

        public Game1()
        {
            
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            _keyboardListener = new KeyboardListener();
            

        }

        protected override void Initialize()
        {
            _camera = new OrthographicCamera(_graphics.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Textures.LoadTexture2D(Content);
            Ecs();
            // TODO: use this.Content to load your game content here
        }
        private void Ecs()
        {
            Components.Add(_screenManager);
            _world = new WorldBuilder()
                .AddSystem(new ChunkManager(_camera))
                .AddSystem(new RenderingSystem(_spriteBatch,_camera))
                .AddSystem(new CameraMovement(_camera))
                .Build();
        }

        protected override void Update(GameTime gameTime)
        {
            _world.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(transformMatrix:_camera.GetViewMatrix(new Vector2(Settings.RenderSize)));
            _world.Draw(gameTime);
            _spriteBatch.End();
        }
        private void LoadScreen1()
        {
            _screenManager.LoadScreen(new MainMenu(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        private void LoadScreen2()
        {
            _screenManager.LoadScreen(new Scenes.Game(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
    }
}