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
        private UICanvas _canvas;
        private Camera _camera;
        private MapRenderer _map;
        private CameraMovement _cameraMovement;
        private Entity Character;
        public override void Initialize()
        {
            base.Initialize();
            _canvas = CreateEntity("game-canvas").AddComponent(new UICanvas());
            var mapGen = new MapGen();
            _world = mapGen.Generate(Settings.X, Settings.Y);
            _map = CreateEntity("map").AddComponent(new MapRenderer(_world));
            _camera = CreateEntity("camera").AddComponent(new Camera());
            Character = CreateEntity("character");
            _cameraMovement = Character.AddComponent(new CameraMovement());
            Camera.Entity.AddComponent(new FollowCamera(Character));

        }
        public override void OnStart()
        {
            ClearColor = Color.Black;
            base.OnStart();
        }

        public override void Update()
        {
            Graphics.Instance.Batcher.Begin(_camera.ViewProjectionMatrix);
            _map.Render(Graphics.Instance.Batcher,_camera);
            Graphics.Instance.Batcher.End();
            base.Update();
            Character.Position = _cameraMovement.Movement();
        }
        public override Table Table { get; set; }
    }
}