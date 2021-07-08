using System.Collections.ObjectModel;
using main.Content;
using main.Scenes;
using main.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private World.BuildingBlocks.World _worldEnt;
        private MonoGame.Extended.Entities.World _world;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private OrthographicCamera _camera;
        private readonly KeyboardListener _keyboardListener;

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
            Defaults();
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Settings.X*10, Settings.Y*5);
            _camera = new OrthographicCamera(viewportAdapter);
            _worldEnt = new World.BuildingBlocks.World();
            CameraDefaults();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Textures.LoadTexture2D(Content);
            ECS();
            // TODO: use this.Content to load your game content here
        }
        private void ECS()
        {
            Components.Add(_screenManager);
            _world = new WorldBuilder()
                .AddSystem(new MapRenderer(_worldEnt,_spriteBatch))
                .AddSystem(new CameraMovement(_camera))
                .Build();
        }
        private static void Defaults()
        {
            Settings.TileSize = 32;
            Settings.Layers = new[] {0, 1};
            Settings.X=Settings.Y  = 32;
            Settings.CameraMovementSpeed = 3f;
            Settings.BiomeSize = 32;

        }

        private void CameraDefaults()
        {
            _camera.Position =Vector2.One;
            _camera.Zoom = 1f;
        }

        protected override void Update(GameTime gameTime)
        {
            _world.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var transfromMatrix = _camera.GetViewMatrix();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(transformMatrix:transfromMatrix);
            _world.Draw(gameTime);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            //base.Draw(gameTime);
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