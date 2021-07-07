using main.Map.BuildingBlocks;

namespace main.Map.Generation.Arrays
{
    public class GridArray
    {
        //Create an object map.
        private readonly int _x;
        private readonly int _y;
        public Object[,] Obj; //Height map

        public GridArray(int x, int y)
        {
            _x = x;
            _y = y;
            Obj = new Object[_x, _y];
            SetDefaultMap();
            
        }
        private void SetDefaultMap()
        {
            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    Obj[x, y] = new Object();
                }
            }
        }
    }
}