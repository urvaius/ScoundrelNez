using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.UI;
namespace ScoundrelNez.Scenes
{
    abstract class BaseScene : Scene
    {
        abstract public Table Table { get; set; }
        public BaseScene()
        {

        }
        public void SetupScene()
        {
            addRenderer(new DefaultRenderer());
            var UICanvas = createEntity("ui-canvas").addComponent(new UICanvas());
            Table = UICanvas.stage.addElement(new Table());
            Table.setFillParent(true).top().padLeft(10).padTop(50);
        }

    }
}
