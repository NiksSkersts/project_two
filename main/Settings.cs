namespace main
{
    public abstract class Settings
    {
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int Z { get; set; }
        public static float CameraMovementSpeed { get; set; }
        public static int BiomeSize { get; set; }
        //Layers
        public static int[] Layers { get; set; }
        public static int Seed { get; set; }
        //Maplayer =0
        //obj layer =1;
    }
}