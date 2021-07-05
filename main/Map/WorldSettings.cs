namespace main.Map
{
    public class WorldSettings
    {
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int Z { get; set; }
        public static int TileSize { get; set; }
        public static int SeaLine { get; set; }

        public WorldSettings()
        {
            Y = X = 80;
            Z = 64;
            TileSize = 16;
        }
    }
}