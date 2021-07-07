using System;
using System.Xml;
using main.Map.BuildingBlocks;
using main.Map.Generation.Arrays;

namespace main.Map.Generation
{
    public class GridGen
    {
        //Array of an obj arrays?
        //Grid Array contains an array of 16 objs.
        //One GridArray represents one MapArray tile of 32x32.
        //Tile is divided in 16 subtiles - each 8x8. 
        //GridLayers are meant to be used for placing buildings and smaller objects, like trees.
        //Larger objs [that make sense - like huge forest or mountain] will still be placed in MapArray to limit the amount of texture rendering.
        public GridArray[,] GenerateGrid(MapArray mapArray)
        {
            int ticker = 0;
            var tileGrid = new GridArray[Settings.X,Settings.Y];
            for (int x = 0; x < Settings.X; x++)
            {
                for (int y = 0; y < Settings.Y; y++)
                {
                    switch (mapArray.Tiles[x, y].TerrainType)
                    {
                        case TerrainType.Grass:
                            tileGrid[x,y]=AddToSubGrid(ObjectType.Grass);
                            break;
                        case TerrainType.None:
                            tileGrid[x,y] = AddToSubGrid(ObjectType.Empty);
                            break;
                        case TerrainType.Water:
                            tileGrid[x,y] = AddToSubGrid(ObjectType.NaturalBlock);
                            break;
                        case TerrainType.Sand:
                            tileGrid[x,y] = AddToSubGrid(ObjectType.Empty);
                            break;
                        case TerrainType.Mountain:
                            tileGrid[x,y] = AddToSubGrid(ObjectType.NaturalBlock);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            return tileGrid;
        }
        private GridArray AddToSubGrid( ObjectType objectType)
        {
            var tileSub = new GridArray(Settings.TileSize/Settings.GridSize,Settings.TileSize/Settings.GridSize);
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    tileSub.Obj[x, y]._objectType = objectType;
                }
            }

            return tileSub;
        }
    }
}