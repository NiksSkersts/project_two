namespace main
{
    public struct Settings
    {
        #region BasicWorldGen
        public const int X = 32;
        public const int Y = 32;
        public const int RenderSize = 32 ;
        public const int Seed = 0;
        public const int MaxLoadedChunks = 9;
        public const float Zoom = 2f;
        public const int MaxHeight = 255;
        //Max height is set by SimplexNoise
        #endregion
        #region Sine
        public const int VerticalShift = 200;
        public const int MaxTemp = 40;
        //Let's pretend that Global Warming ain't a thing in this world.
        //Desert is High Temps + near zero humidity.
        //Jungle - High Temps + A lot of humidity
        public const float Period = 0.016f;
        public const int PhaseShiftLeft = 400;
        #endregion
        public const float MovementAccel = 25f;

    }
}