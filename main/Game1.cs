using System;
using main.Content;
using main.Systems;
using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Texture = main.World.Structure.Texture;

namespace main
{
    public class Game1 : Game
    {
        private DefaultEcs.World _world = new DefaultEcs.World();
        private readonly Camera _camera = new Camera();
        private DrawManager _drawManager;
        private ChunkManager _chunkManager;
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;

        public Game1()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2,
                PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2,
                GraphicsProfile = GraphicsProfile.Reach
            };
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _drawManager = new DrawManager(_spriteBatch,_camera);
            _chunkManager = new ChunkManager(_camera);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Textures.LoadTexture2D(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            _camera.Update(1);
            _camera.ViewportWidth = GraphicsDevice.Viewport.Width;
            _camera.ViewportHeight = GraphicsDevice.Viewport.Height;
            _chunkManager.Update(1);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(transformMatrix: _camera.TranslationMatrix, sortMode: SpriteSortMode.BackToFront,samplerState: SamplerState.PointClamp);
            _drawManager.Update(1);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}