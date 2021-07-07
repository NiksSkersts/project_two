namespace main
{
    public abstract class Settings
    {

        public static int X { get; set; }
        public static int Y { get; set; }
        public static int Z { get; set; }
        public static int TileSize { get; set; }
        public static int GridSize { get; set; }
        public static int SubGridCount { get; set; }
        public static float CameraMovementSpeed { get; set; }
        public static int BiomeSize { get; set; }
    }
}