using System.Collections.Generic;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace main.Systems
{
    public class Camera : ISystem<float>
    {
        private float _zoom; // Camera Zoom
        public Matrix Transform; // Matrix Transform
        public Vector2 Pos; // Camera Position
        public bool IsEnabled { get; set; }

        // Height and width of the viewport window which we need to adjust
        // any time the player resizes the game window.
        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }
        private Vector2 ViewportCenter => new Vector2( ViewportWidth * 0.5f, ViewportHeight * 0.5f );
        public Camera()
        {
            _zoom = Settings.Zoom;
            Pos = Vector2.Zero;
        }
        // Sets and gets zoom
        private float Zoom
        {
            // Negative zoom will flip image. Zoom  Disabled.
            get => _zoom;
            set { _zoom = _zoom; if (_zoom < 0.1f) _zoom = 0.1f; } 
        }
        // Get set position
        private Vector2 Position
        {
            get => Pos;
            set => Pos = value;
        }
        public Matrix TranslationMatrix =>
            Matrix.CreateTranslation( -(int) Pos.X, -(int) Pos.Y, 0 ) *
            Matrix.CreateScale( new Vector3( Zoom, Zoom, 1 ) ) *
            Matrix.CreateTranslation( new Vector3( ViewportCenter, 0 ) );

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Update(float state)
        {
            var currentPressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (var key in currentPressedKeys)
            {
                switch (key)
                {
                    case Keys.Up:
                        Pos -= Vector2.UnitY*100;
                        break;
                    case Keys.Down:
                        Pos += Vector2.UnitY*100;
                        break;
                    case Keys.Left:
                        Pos -= Vector2.UnitX*100;
                        break;
                    case Keys.Right:
                        Pos += Vector2.UnitX*100;
                        break;
                    case Keys.OemPlus:
                        Zoom += 0.5f;
                        break;
                    case Keys.OemMinus:
                        Zoom -= 0.5f;
                        break;
                }
            }
        }
    }
}