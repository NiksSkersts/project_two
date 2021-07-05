using main.Map.BuildingBlocks;

namespace main.Map.WorldGen
{
    public class World
    {
        public readonly int _x;
        public readonly int _y;
        public Tile[,] Tiles;

        public World(int x, int y)
        {
            _x = x;
            _y = y;
            Tiles = new Tile[_x, _y];
            SetDefaultMap();
            
        }
        private void SetDefaultMap()
        {
            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    Tiles[x, y] = new Tile();
                }
            }
        }
    }
}