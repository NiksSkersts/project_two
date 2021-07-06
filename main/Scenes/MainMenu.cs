using System;
using Nez;
using Nez.UI;

//well, at least menu works as expected.
namespace main.Scenes
{
    public class MainMenu : BaseScene
    {
        public override void Initialize()
        {
            SetupBasic();
            Table.Row().SetPadTop(20);
            Table.Add(new Label("Main Menu").SetFontScale(5));
            Table.Row().SetPadTop(20);
            var button = Table.Add(new TextButton("Play", Skin.CreateDefaultSkin())).SetMinHeight(30).SetFillX().GetElement<TextButton>();
            button.OnClicked += buttonOnClick_Play;
        }

        private void buttonOnClick_Play(Button obj)
        {
            Core.Scene = new Game();
        }

        public override Table Table { get; set; }
    }
}