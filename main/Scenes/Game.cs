using main.Components;
using main.Map.BuildingBlocks;
using main.Map.Generation;
using main.Map.Generation.Arrays;
using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;

namespace main.Scenes
{
    //Dunno why, but my FPS increased twofold.
    //Were I over-rendering my scene?
    //It's plausible.
    //Var _obj calls render method as well, so it's possible that I kept rendering it two times.
    //That's the best I can think of, because I just rendered nearly 4 times more rectangles and got twice as much FPS. Fascinating.
    public class Game : BaseScene
    {
        private Map.BuildingBlocks.Map Map;
        private CameraMovement _cameraMovement;
        public override void Initialize()
        {
            base.Initialize();
            SetupRendering();
            SetupCamera();
            AddRenderer(new DefaultRenderer());
            Map = new Map.BuildingBlocks.Map();
        }

        private void SetupRendering()
        {
            //var _obj = CreateEntity("obj").AddComponent(new ObjLayerRenderer(Map));
            var _map = CreateEntity("map").AddComponent(new MapRenderer(Map));
            //_obj.RenderLayer = 0;
            _map.RenderLayer = 1;
        }

        private void SetupCamera()
        {
            _cameraMovement = CreateEntity("character").AddComponent(new CameraMovement());
            _cameraMovement.Entity.SetPosition(Vector2.One);
            Camera.Entity.AddComponent(new FollowCamera(_cameraMovement.Entity));
        }
        public override void OnStart()
        {
            ClearColor = Color.Black;
            base.OnStart();
            Camera.RawZoom = 8;

        }

        public override void Update()
        {
            //Camera.Entity.Position += _cameraMovement.Movement(Camera);
            //Camera.ZoomIn(_cameraMovement.Zoom());
            base.Update();
        }
        
        public override Table Table { get; set; }
    }
}