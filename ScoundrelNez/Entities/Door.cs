using Microsoft.Xna.Framework;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Nez.Textures;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Nez.Tiled;
using Nez;

namespace ScoundrelNez.Entities
{
    public class Door : Component, ITriggerListener, IUpdatable
    {

        BoxCollider _boxCollider;
        bool IUpdatable.enabled => throw new System.NotImplementedException();

        int IUpdatable.updateOrder => throw new System.NotImplementedException();


        public override void onAddedToEntity()
        {
            base.onAddedToEntity();
            var texture = entity.scene.content.Load<Texture2D>(Content.Textures.powerup);
            _boxCollider = entity.getComponent<BoxCollider>();


        }
        public void onTriggerEnter(Collider other, Collider local)
        {
            Debug.log("triggerEnter:{0}", other.entity.name);
        }

        public void onTriggerExit(Collider other, Collider local)
        {
            Debug.log("triggerEnter:{0}", other.entity.name);
        }

        void IUpdatable.update()
        {
            
        }
    }
}
