using main.Map;
using main.Map.Drawing;
using main.Map.WorldGen;
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
        private Vector2 _worldPosition;
        private WorldSettings _worldSettings;
        private World _world;
        private IDraw _draw;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "/home/niks_skersts/Sources/project_two/main/Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);
            _camera = new OrthographicCamera(viewportAdapter);
            _worldSettings = new WorldSettings();
            IWorldGen gen = new RandomMapGenerator();
            _draw = new BatchDraw();
            _world = gen.Generate(WorldSettings.X, WorldSettings.Y);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            const float movementSpeed = 200;
            _camera.Move(GetMovementDirection() * movementSpeed * gameTime.GetElapsedSeconds());
            var mouseState = Mouse.GetState();
            _worldPosition = _camera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(new Color(Color.Black, 0f));
            
            var transformMatrix = _camera.GetViewMatrix();
            _spriteBatch.Begin(SpriteSortMode.Deferred,transformMatrix: transformMatrix);
            _draw.Draw(_world,_spriteBatch,_graphics.GraphicsDevice,Content);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        private Vector2 GetMovementDirection()
        {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                movementDirection += Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                movementDirection -= Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                movementDirection -= Vector2.UnitX;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                movementDirection += Vector2.UnitX;
            }
            return movementDirection;
        }
    }
}