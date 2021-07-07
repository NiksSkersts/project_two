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
                private Vector2 movement;
        
                public CameraMovement()
                {
                    Up = new VirtualButton();
                    Down = new VirtualButton();
                    Left = new VirtualButton();
                    Right = new VirtualButton();
                    Up.AddKeyboardKey(Keys.Up);
                    Down.AddKeyboardKey(Keys.Down);
                    Left.AddKeyboardKey(Keys.Left);
                    Right.AddKeyboardKey(Keys.Right);
                }
                public Vector2 Movement()
                {
                    
                    if (Up.IsDown)
                    {
                        movement += new Vector2(0,-1);
                    }
        
                    if (Down.IsDown)
                    {
                        movement += new Vector2(0,+1);
                    }
        
                    if (Left.IsDown)
                    {
                        movement += new Vector2(-1,0);
                    }
        
                    if (Right.IsDown)
                    {
                        movement += new Vector2(1,0);
                    }
                    return movement*100;
                }
    }
}