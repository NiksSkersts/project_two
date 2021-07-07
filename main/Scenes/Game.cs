using main.Components;
using main.Map.BuildingBlocks;
using main.Map.Generation;
using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;

namespace main.Scenes
{
    public class Game : BaseScene
    {
        private World _world;
        //private Camera _camera;
        private MapRenderer _map;
        private CameraMovement _cameraMovement;
        private FollowCamera _cameraf;
        public override void Initialize()
        {
            base.Initialize();
            var mapGen = new MapGen();
            _world = mapGen.Generate(Settings.X, Settings.Y);
            _map = CreateEntity("map").AddComponent(new MapRenderer(_world));
            //_camera = CreateEntity("camera").AddComponent(new Camera());
            _cameraMovement = CreateEntity("character").AddComponent(new CameraMovement());
            _cameraf = Camera.Entity.AddComponent(new FollowCamera(_cameraMovement.Entity));

        }
        public override void OnStart()
        {
            ClearColor = Color.Black;
            base.OnStart();
        }

        public override void Update()
        {
            Graphics.Instance.Batcher.Begin(Camera.TransformMatrix);
            _map.Render(Graphics.Instance.Batcher,Camera);
            Graphics.Instance.Batcher.End();
            _cameraMovement.Entity.Position = _cameraMovement.Movement();
            Camera.ZoomIn(_cameraMovement.Zoom());
            base.Update();
        }
        public override Table Table { get; set; }
    }
}