using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace main.Camera
{
    public interface ICamera
    {
        public float Zoom { get; set; } //Camera Zoom Value
        public Matrix Transform { get; set; } //Camera Transform Matrix
        public Matrix InverseTransform { get; set; } //Inverse of Transform Matrix
        public Vector2 Pos { get; set; } //Camera Position
        public float Rotation { get; set; } //Camera Rotation Value (Radians)
        public Viewport Viewport { get; set; } //Cameras Viewport
        public MouseState MState { get; set; } //Mouse state
        public KeyboardState KeyState { get; set; } //Keyboard state
        public int Scroll { get; set; } //Previous Mouse Scroll Wheel Value
        public Matrix ViewMatrix();
        public Vector2 Movement();
        public void LoadDefaults();
        public float MovementSpeed { get; set; }
        public float MouseZoom();
        public float CameraRotation();
    }
}