using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace main.Components
{
    public class CameraMovement : Component
    {
                private VirtualButton Up;
                private VirtualButton Down;
                private VirtualButton Left;
                private VirtualButton Right;
                private VirtualButton OemPlus;
                private VirtualButton OemMinus;
                private Vector2 movement;
        
                public CameraMovement()
                {
                    Up = new VirtualButton();
                    Down = new VirtualButton();
                    Left = new VirtualButton();
                    Right = new VirtualButton();
                    OemPlus = new VirtualButton();
                    OemMinus = new VirtualButton();
                    Up.AddKeyboardKey(Keys.Up);
                    Down.AddKeyboardKey(Keys.Down);
                    Left.AddKeyboardKey(Keys.Left);
                    Right.AddKeyboardKey(Keys.Right);
                    OemPlus.AddKeyboardKey(Keys.OemPlus);
                    OemMinus.AddKeyboardKey(Keys.OemMinus);
                }
                public Vector2 Movement(Camera camera)
                {
                    float movementY=0;
                    float movementX=0;
                    
                    if (Up.IsDown)
                    {
                        movementY += -1;
                    }
        
                    if (Down.IsDown)
                    {
                        movementY += 1;
                    }
        
                    if (Left.IsDown)
                    {
                        movementX += -1;
                    }
        
                    if (Right.IsDown)
                    {
                        movementX += 1;
                    }

                    if (camera.Bounds.X+movementX<=0||camera.Bounds.Right+movementX>=Settings.X*Settings.TileSize)
                    {
                        return new Vector2(0, 0);
                    }
                    if (camera.Bounds.Y+movementY<=0 || camera.Bounds.Bottom+movementY>=Settings.Y*Settings.TileSize)
                    {
                        return new Vector2(0, 0);
                    }
                    
                    return movement*Settings.CameraMovementSpeed;
                }

                public float Zoom()
                {
                    float zoom = 0;
                    if (OemPlus.IsDown)
                    {
                        zoom += 0.1f;
                    }

                    if (OemMinus.IsDown)
                    {
                        zoom -= 0.1f;
                    }

                    return zoom;
                }
    }
}