using System;
using System.Linq;
using main.World.Generation;
using main.World.Structs;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Collections;
using MonoGame.Extended.Entities.Systems;
using SD.Tools.BCLExtensions.CollectionsRelated;

namespace main.Systems
{
    public class CoordinateSystem : UpdateSystem
    {
        private readonly OrthographicCamera _camera;
        public static ObservableCollection<Tile>[] TilesArray;
        private readonly GenerateChunk _generateChunk;

        public CoordinateSystem(OrthographicCamera camera)
        {
            _camera = camera;
            _generateChunk = new GenerateChunk();
            TilesArray = new ObservableCollection<Tile>[4];
            for (int i = 0; i < 4; i++)
            {
                TilesArray[i] = new ObservableCollection<Tile>();
            }
        }

        public override void Update(GameTime gameTime)
        {
            CheckForChunkLoading();
        }

        private void CheckForChunkLoading()
        {
            int coordinateX=0;
            int coordinateY=0;
            var X = _camera.Position.X;
            var Y=_camera.Position.Y;
            if (_camera.Position.X<0 || _camera.Position.Y <0)
            {
                if (X <0)
                {
                    X *= -1;
                    coordinateX = ((int) X * -1)/Settings.X;
                }
                else
                {
                    coordinateX =(int) X / Settings.X;
                }

                if (Y<0)
                {
                    Y *= -1;
                    coordinateY = ( (int) Y * -1)/Settings.Y;
                }
                else
                {
                    coordinateY = (int) Y / Settings.Y;
                }
            }
            else
            {
                coordinateX = (int) X/Settings.X;
                coordinateY = (int) Y/Settings.Y;
            }

            int quadrant = Determinequadrant(coordinateX, coordinateY);
            if (quadrant==3)
            {
                for (int i = coordinateX; i < coordinateX+Settings.Tiles ; i++)
                {
                    for (int j = coordinateY; j > coordinateY-Settings.Tiles; j--)
                    {
                        CheckIfExists(3, new Point(i, j));
                    }
                }
            }else if (quadrant==2)
            {
                for (int i = coordinateX; i > coordinateX-Settings.Tiles ; i--)
                {
                    for (int j = coordinateY; j > coordinateY-Settings.Tiles; j--)
                    {
                        CheckIfExists(2, new Point(i, j));
                    }
                }
            }else if (quadrant==1)
            {
                for (int i = coordinateX; i < coordinateX+Settings.Tiles ; i++)
                {
                    for (int j = coordinateY; j < coordinateY+Settings.Tiles; j++)
                    {
                        CheckIfExists(2, new Point(i, j));
                    }
                }
            }else if (quadrant==0)
            {
                for (int i = coordinateX; i > coordinateX-Settings.Tiles ; i--)
                {
                    for (int j = coordinateY; j < coordinateY+Settings.Tiles; j++)
                    {
                        CheckIfExists(0, new Point(i, j));
                    }
                }
            }

            void CheckIfExists(int quadrant,Point point)
            {
                if (TilesArray[quadrant].Any(p => p.Coordinates.Equals(point))==false)
                {
                    var tile = _generateChunk.Create(point);
                    TilesArray[quadrant].Add(tile);
                        
                }
            }
        }

        private int Determinequadrant(int coordinateX, int coordinateY)
        {
            if (coordinateX<=0 && coordinateY>=0)
            {
                return 0;
            }
            if (coordinateX>=0 && coordinateY>=0)
            {
                return 1;
            }
            if (coordinateX<=0 && coordinateY<=0)
            {
                return 2;
            }
            if (coordinateX>=0 && coordinateY<=0)
            {
                return 3;
            }

            return 4;
        }
        
    }
}