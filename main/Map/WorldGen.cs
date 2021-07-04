using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using static main.Map.WorldSettings;

namespace main.Map
{
    public class WorldGen
    {
        private static bool[,,] world_array = new bool[X, Y, Z];

        public static void CreatePlains()
        {
            for (var x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    world_array[x, y, SeaLine] = true;
                }
            }
        }

        public static void Draw(GraphicsDevice graphicsDevice,SpriteBatch batch)
        {
            for (int z = 0; z < Z; z++)
            {
                for (int x = 0; x < X; x++)
                {
                    for (int y = 0; y < Y; y++)
                    {
                        if (world_array[x,y,z] ==true)
                        {
                            batch.DrawRectangle(
                                new RectangleF(new Point2(x*TileSize+1,y*TileSize+1),new Size2(TileSize,TileSize)),
                                new Color(Color.Red, 0f));
                        }
                    }
                }
                
            }
        }
    }
}