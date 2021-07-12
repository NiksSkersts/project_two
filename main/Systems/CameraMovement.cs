using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Input;
using MonoGame.Extended.Input.InputListeners;

namespace main.Systems
{
    public class CameraMovement : UpdateSystem
    {
        private readonly OrthographicCamera _orthographicCamera;

        public CameraMovement(OrthographicCamera orthographicCamera)
        {
            _orthographicCamera = orthographicCamera;
        }
        

        public override void Update(GameTime gameTime)
        {
            _orthographicCamera.Zoom = 0.4f;
            Keys[] currentPressedKeys = Keyboard.GetState().GetPressedKeys();
                foreach (var key in currentPressedKeys)
                {
                    switch (key)
                    {
                        case Keys.Up:
                            _orthographicCamera.Move(new Vector2(0, -1));
                            break;
                        case Keys.Down:
                            _orthographicCamera.Move(new Vector2(0, 1));
                            break;
                        case Keys.Left:
                            _orthographicCamera.Move(new Vector2(-1, 0));
                            break;
                        case Keys.Right:
                            _orthographicCamera.Move(new Vector2(1, 0));
                            break;
                    }
                }
        }
    }
}