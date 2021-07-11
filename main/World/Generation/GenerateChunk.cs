using main.Content;
using main.World.Enum;
using main.World.Structs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collections;
using SimplexNoise;

namespace main.World.Generation
{
    public class GenerateChunk
    {
        private float _height;
        public Tile Create(Point coords) => new Tile(DetermineTerrain(coords),coords,_height);
        private Texture2D DetermineTerrain(Point _coords)
        {
            _height = GenerateHeightMap();
            if (_height<=80)
            {
                return Textures.AWaterDeep;
            } 
            if (_height<=85)
            {
                return Textures.ASand;
            }
            if (_height>=220)
            {
                return Textures.ARockHigh;
            }
            return Textures.AGrass;
            
            float GenerateHeightMap()
            {
                Noise.Seed = Settings.Seed;
                return Noise.CalcPixel2D(_coords.X, _coords.Y, 0.010f);
            }
        }
    }
}