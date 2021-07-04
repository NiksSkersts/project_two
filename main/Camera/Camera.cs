using System;
using System.ComponentModel;
using System.Reflection;
using main.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace main.Camera
{
    internal class TwoD
    {
        private int _viewportWidth;
        private int _viewportHeight;
        private Rectangle Bounds;
        private Vector2 _pos;
        private float _zoom;
        private Matrix _transform;

        public TwoD(Viewport viewport)
        {
            Bounds = viewport.Bounds;
            _zoom = 1f;
            Rotation = 0f;
        }

        public void Move(Vector2 amount)
        {
            _pos += amount;
        }

        public Vector2 Pos
        {
            get { return _pos; }
            set
            {
                float leftBarrier = (float)_viewportWidth *
                    .5f / _zoom;
                float rightBarrier = Bounds.Width -
                                     (float)_viewportWidth * .5f / _zoom;
                float topBarrier = Bounds.Height -
                                   (float)_viewportHeight * .5f / _zoom;
                float bottomBarrier = (float)_viewportHeight *
                    .5f / _zoom;
                _pos = value;
                if (_pos.X < leftBarrier)
                    _pos.X = leftBarrier;
                if (_pos.X > rightBarrier)
                    _pos.X = rightBarrier;
                if (_pos.Y > topBarrier)
                    _pos.Y = topBarrier;
                if (_pos.Y < bottomBarrier)
                    _pos.Y = bottomBarrier;
            }
        }
        
        public Matrix GetTransformation()
        {
            _transform = 
                Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                Matrix.CreateTranslation(new Vector3(_viewportWidth * 0.5f,
                    _viewportHeight * 0.5f, 0));

            return _transform;
        }

        public float Zoom
        {
            get { return _zoom;}
            set
            {
                _zoom = value;
                float zoomLowerLimit = 1f;
                if (_zoom < zoomLowerLimit)
                    _zoom = zoomLowerLimit;
                float zoomUpperLimit= 5;
                if (_zoom > zoomUpperLimit)
                    _zoom = zoomUpperLimit;
            } }

        public float Rotation { get; set; }
    }
}