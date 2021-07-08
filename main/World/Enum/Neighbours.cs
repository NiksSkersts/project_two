#nullable enable
namespace main.World.Enum
{
    public class Neighbours
    {
        //Split into Quadrants
        // Q1 Q2 Q3
        // Q4 Q5 Q6
        // Q7 Q8 Q9
        // Q5 - Tile
        // Q[x>0] - Neighbouring Tile terraintype
        //Default: OutOfBounds;
        public object? Q1 { get; set; }
        public object? Q2 { get; set; }
        public object? Q3 { get; set; }
        public object? Q4 { get; set; }
        public object? Q5 { get; set; }
        
        public object? Q6 { get; set; }
        public object? Q7 { get; set; }
        public object? Q8 { get; set; }
        public object? Q9 { get; set; }
    }
}