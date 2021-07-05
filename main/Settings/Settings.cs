namespace main.Settings
{
    public class Settings : ISettings
    {
        private ICamera _camera;
        private IWorld _world;

        public Settings(ICamera camera, IWorld world)
        {
            _camera = camera;
            _world = world;
        }

        public void LoadSettings()
        {
            _camera.MovementSpeed = 200;
            _world.X = _world.Y = 32;
            _world.Z = 64;
            _world.TileSize = 16;
        }
    }
}