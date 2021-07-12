using System.Collections;
using System.Collections.Generic;
using System.Linq;
using main.Content;
using Microsoft.Xna.Framework.Graphics;
using SimplexNoise;

namespace main.World.Structure
{
    public class Grid
    {
        public static SortedList<Point,Tile> Tiles = new SortedList<Point, Tile>();
        public static void Create(Point start)
        {
            for (var i = (start.X/Settings.X)-(Settings.X); i < (start.X/Settings.X)+(Settings.X); i++)
            {
                for (var j = (start.Y/Settings.Y)-(Settings.RenderSize); j < (start.Y/Settings.Y)+(Settings.RenderSize); j++)
                {
                    if (Tiles.ContainsKey(new Point(i,j))==false)
                    {
                        var height = DetermineHeight(new Point(i,j));
                        var terrain = DetermineTerrain(height);
                        Tiles[new Point(i, j)] = new Tile(terrain, height, new Point(i, j));
                    }
                }
            }
            static float DetermineHeight(Point point)
            {
                Noise.Seed = Settings.Seed;
                return Noise.CalcPixel2D((int)point.X,(int)point.Y,0.01f);
            }

            static Texture2D DetermineTerrain(float height)
            {
                if (height >= 210) return Textures.ARockHigh;
                if (height <= 85) return Textures.ASand;
                if (height <= 80) return Textures.AWaterDeep;
                return Textures.AGrass;
            }
        }
    }
}