using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ButterFlyGameNez.Entities;
using System.Threading.Tasks;

namespace ScoundrelNez.Scenes
{
    public class HomeScene : Scene
    {
        public HomeScene()
        {
            clearColor = Color.DarkGreen;
            addRenderer(new DefaultRenderer(0, null));
        }

        public override void initialize()
        {
            base.initialize();
            
            // setDesignResolution(640, 480, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            //Screen.setSize(640 * 2, 480 * 2);
            //put this in game 1 file
            //setDesignResolution(1280, 768, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            //Screen.setSize(1280 , 768 );

            var tiledEntity = createEntity("tiled-map-entity");
            var tiledMap = content.Load<TiledMap>(Content.Tiled.tiledMapnew);

            //var tiledMap = content.Load<TiledMap>(Content.Tiled.tiledMap);
            var objectLayer = tiledMap.getObjectGroup("objects");
            var spawnObject = objectLayer.objectWithName("spawn");
            var tiledMapComponent = tiledEntity.addComponent(new TiledMapComponent(tiledMap, "main"));

            var playerEntity = createEntity("player", new Vector2(spawnObject.x, spawnObject.y));

            //var playerEntity = createEntity("player", new Vector2(200, 200));

            playerEntity.addComponent(new Player());
            playerEntity.addComponent(new BoxCollider(-8, -16, 16, 32));
            playerEntity.addComponent(new TiledMapMover(tiledMapComponent.collisionLayer));



        }
    }
}
