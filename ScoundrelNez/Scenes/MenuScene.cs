using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.UI;
namespace ScoundrelNez.Scenes
{
    class MenuScene : BaseScene
    {
        private Table table;
        public override Table Table
        {
            get { return table; }
            set { table = value; }
        }

        public MenuScene()
        {

        }
        override
        public void initialize()
        {
            SetupScene();
            Table.add(new Label("Main Menu").setFontScale(5));
            Table.row().setPadTop(20);
            Table.add(new Label("Scoundrel Main Menu").setFontScale(2));
            Table.row().setPadTop(10);
            var playButton = Table.add(new TextButton("Play Game", Skin.createDefaultSkin())).setFillX().setMinHeight(30).getElement<TextButton>();
            playButton.onClicked += PlayButton_onClicked;
        }

        private void PlayButton_onClicked(Button obj)
        {
            Core.startSceneTransition(new TextureWipeTransition(() => new HomeScene())
            {
                transitionTexture = Core.content.Load<Texture2D>("nez/textures/textureWipeTransition/wink")
            });
        }
     }
}
