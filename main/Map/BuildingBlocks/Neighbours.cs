namespace main.Map.BuildingBlocks
{
    public class Neighbours
    {
        //Split into Quadrants
        // Q1 Q2 Q3
        // Q4 Q0 Q6
        // Q7 Q8 Q9
        // Q0 - Tile
        // Q[x>0] - Neighbouring Tile terraintype
        //Default: OutOfBounds;
        public TerrainType Q1 { get; set; }
        public TerrainType Q2 { get; set; }
        public TerrainType Q3 { get; set; }
        public TerrainType Q4 { get; set; }
        public TerrainType Q6 { get; set; }
        public TerrainType Q7 { get; set; }
        public TerrainType Q8 { get; set; }
        public TerrainType Q9 { get; set; }

        public Neighbours()
        {
            Q1 = TerrainType.OutOfBounds;
            Q2 = TerrainType.OutOfBounds;
            Q3 = TerrainType.OutOfBounds;
            Q4 = TerrainType.OutOfBounds;
            Q6 = TerrainType.OutOfBounds;
            Q7 = TerrainType.OutOfBounds;
            Q8 = TerrainType.OutOfBounds;
            Q9 = TerrainType.OutOfBounds;
        }
    }
}