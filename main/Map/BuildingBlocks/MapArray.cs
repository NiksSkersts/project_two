namespace main.Map.BuildingBlocks
{
    public class World
    {
        //Create a simplex height map.
        //Height map is used to assign terrain types to tiles.
        private readonly int _x;
        private readonly int _y;
        public Tile[,] Tiles; //Height map

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