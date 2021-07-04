using System;
using System.IO;
using main.Camera;
using main.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace main
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Camera.TwoD _camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "/home/niks_skersts/Sources/project_two/main/Content";
            IsMouseVisible = true;
            SetUpTile();
        }

        private static void SetUpTile()
        {
            Tile.TileSize = 32;
        }

        protected override void Initialize()
        {
            World.WorldHeight = 377;
            World.WorldWidth = 377;
            _camera = new TwoD(_graphics.GraphicsDevice.Viewport);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _camera.Move(new Vector2(y:5,x:0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _camera.Move(new Vector2(y:-5,x:0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _camera.Move(new Vector2(y:0,x:-5));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _camera.Move(new Vector2(y:0,x:5));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
            {
                _camera.Zoom += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
            {
                _camera.Zoom -= 1;
            }
            
            // Adjust zoom if the mouse wheel has moved
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var @struct = new MapStruct(Content,World.WorldHeight,World.WorldWidth);
            _spriteBatch.Begin(SpriteSortMode.BackToFront,BlendState.AlphaBlend,transformMatrix:_camera.GetTransformation());
            @struct.DrawMap(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}