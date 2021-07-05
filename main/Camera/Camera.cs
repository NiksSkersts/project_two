using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace main.Camera
{
    public class Camera : ICamera
    {
        private int _scroll;
        private float _zoom;
        private KeyboardState _keyState;
        private float _rotation;
        public float Zoom { get; set; }
        public float MovementSpeed { get; set; }
        public Matrix Transform { get; set; }

        public Matrix InverseTransform { get; set; }

        public Vector2 Pos { get; set; }

        public float Rotation { get; set; }

        public Viewport Viewport { get; set; }

        public MouseState MState { get; set; }

        public KeyboardState KeyState { get; set; }

        public int Scroll { get; set; }

        public void LoadDefaults()
        {
            Zoom = 1.0f;
            Scroll = 1;
            Rotation = 0.0f;
            Pos = Vector2.Zero;
            MovementSpeed = 200f;
            MathHelper.Clamp(Zoom, 0.01f, 10.0f);
        }
        public Matrix ViewMatrix()
        {
            Transform =    Matrix.CreateRotationZ(Rotation) * 
                            Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * 
                            Matrix.CreateTranslation(Pos.X, Pos.Y, 0);
            InverseTransform = Matrix.Invert(Transform);
            return Transform;
        }

        public Vector2 Movement()
        {
            var movementDirection = Vector2.Zero;
            var _keyState = Keyboard.GetState();
            if (_keyState.IsKeyDown(Keys.Down))
            {
                movementDirection += Vector2.UnitY;
            }else if (_keyState.IsKeyDown(Keys.Up))
            {
                movementDirection -= Vector2.UnitY;
            }else if (_keyState.IsKeyDown(Keys.Left))
            {
                movementDirection -= Vector2.UnitX;
            }else if (_keyState.IsKeyDown(Keys.Right))
            {
                movementDirection += Vector2.UnitX;
            }
            return movementDirection;
        }

        public float MouseZoom()
        {
            var _mState = Mouse.GetState();
            if (_mState.ScrollWheelValue > _scroll)
            {
                _zoom += 0.1f;
                _scroll = _mState.ScrollWheelValue;
            }
            else if (_mState.ScrollWheelValue < _scroll)
            {
                _zoom -= 0.1f;
                _scroll = _mState.ScrollWheelValue;
            }

            return _zoom;
        }

        public float CameraRotation()
        {
            _keyState = Keyboard.GetState();
            if (_keyState.IsKeyDown(Keys.OemPlus))
            {
                _rotation -= 0.1f;
            }
            if (_keyState.IsKeyDown(Keys.OemMinus))
            {
                _rotation += 0.1f;
            }

            return _rotation;
        }
    }
}