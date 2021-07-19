using System;
using main.Content;
using main.Systems;
using main.World.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace main
{
    public class Game1 : Game
    {
        private DefaultEcs.World _world = new DefaultEcs.World();
        private readonly Camera _camera = new Camera();
        private readonly DrawManager _drawManager;
        private readonly ChunkManager _chunkManager;
        private readonly SpriteBatch _spriteBatch;

        public Game1()
        {
            var graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height,
                PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width
            };

            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _drawManager = new DrawManager(_spriteBatch);
            _chunkManager = new ChunkManager(_camera);
        }

        protected override void Initialize()
        {
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
            _spriteBatch.Begin(transformMatrix: _camera.TranslationMatrix);
            _drawManager.Update(1);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}