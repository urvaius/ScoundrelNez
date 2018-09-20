using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace ScoundrelNez.Components
{
    public class SimpleMover : Component, IUpdatable
    {
        float _speed = 600f;
        Mover _mover;
        Sprite _sprite;


        public override void onAddedToEntity()
        {
            _sprite = this.getComponent<Sprite>();
            _mover = new Mover();
            entity.addComponent(_mover);
        }


        void IUpdatable.update()
        {
            var moveDir = Vector2.Zero;

            if (Input.isKeyDown(Keys.Left))
            {
                moveDir.X = -1f;
                if (_sprite != null)
                    _sprite.flipX = true;
            }
            else if (Input.isKeyDown(Keys.Right))
            {
                moveDir.X = 1f;
                if (_sprite != null)
                    _sprite.flipX = false;
            }

            if (Input.isKeyDown(Keys.Up))
                moveDir.Y = -1f;
            else if (Input.isKeyDown(Keys.Down))
                moveDir.Y = 1f;


            if (moveDir != Vector2.Zero)
            {
                var movement = moveDir * _speed * Time.deltaTime;

                CollisionResult res;
                if (_mover.move(movement, out res))
                    Debug.drawLine(entity.transform.position, entity.transform.position + res.normal * 100, Color.Black, 0.3f);
            }
        }
    }
}
