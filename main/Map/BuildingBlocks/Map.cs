using main.Map.Generation;
using main.Map.Generation.Arrays;

namespace main.Map.BuildingBlocks
{
    public class Map
    {
        public Map()
        {
            var genMap = new MapGen();
            var genGrid = new GridGen();
            MapLayer = genMap.Generate(Settings.X,Settings.Y);
            ObjectLayer = genGrid.GenerateGrid(MapLayer);
        }

        public GridArray[,] ObjectLayer { get; set; }
        public MapArray MapLayer { get; set; }
    }
}