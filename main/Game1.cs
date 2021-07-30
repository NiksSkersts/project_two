using System.Security.Cryptography;
using main.Content;
using main.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace main
{
    public class Game1 : Game
    {
        private OrthographicCamera _orthographicCamera;
        private DefaultEcs.World _world = new DefaultEcs.World();
        private DrawManager _drawManager;
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
            _orthographicCamera = new OrthographicCamera(new BoxingViewportAdapter(this.Window,GraphicsDevice,600,300,0,0));
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _drawManager = new DrawManager(_spriteBatch,_orthographicCamera);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Textures.LoadTexture2D(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            var currentPressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (var key in currentPressedKeys)
            {
                switch (key)
                {
                    case Keys.Up:
                        _orthographicCamera.Move(-Vector2.UnitY*Settings.MovementAccel);
                        break;
                    case Keys.Down:
                        _orthographicCamera.Move(Vector2.UnitY*Settings.MovementAccel);
                        break;
                    case Keys.Left:
                        _orthographicCamera.Move(-Vector2.UnitX*Settings.MovementAccel);
                        break;
                    case Keys.Right:
                        _orthographicCamera.Move(Vector2.UnitX*Settings.MovementAccel);
                        break;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(transformMatrix: _orthographicCamera.GetViewMatrix(new Vector2(Settings.RenderSize)), sortMode: SpriteSortMode.BackToFront,samplerState: SamplerState.PointWrap);
            _drawManager.Update(1);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}