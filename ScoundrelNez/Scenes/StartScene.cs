using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoundrelNez.Components;

namespace ScoundrelNez.Scenes
{
    public class StartScene : Scene
    {

        public StartScene()
        {
            clearColor = Color.DarkGreen;
            addRenderer(new DefaultRenderer(0, null));
            Physics.spatialHashCellSize = 75;
            //var table = StartScene.stage.addElement(new Table());

        }

        public override void initialize()
        {
            base.initialize();


            var texture = content.Load<Texture2D>(Content.Textures.butterfly1);
            var entityOne = createEntity("butterfly");

            entityOne.position = (new Vector2(200, 200));
            entityOne.addComponent(new Sprite(texture));
            entityOne.addComponent(new BoxCollider());
            //entityOne.addComponent(new Movement());
            entityOne.addComponent(new SimpleMover());



        }
    }
}
