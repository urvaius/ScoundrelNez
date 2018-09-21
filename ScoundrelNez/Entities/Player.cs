using Microsoft.Xna.Framework;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Nez.Textures;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Nez.Tiled;
using Nez;

namespace ButterFlyGameNez.Entities
{
    public class Player : Component, ITriggerListener, IUpdatable
    {
        public float moveSpeed = 150;
        //public float gravity = 50;

        //public float gravity = 50;
        public float flyHeight = 16 * 5;


        enum Animations
        {
            Walk, Run, Idle, Attack, Death, Falling, Hurt, Jumping

        }

        Sprite<Animations> _animation;

        //TiledMapMover _mover;
        Mover _mover;
        float _moveSpeed = 100f;
        BoxCollider _boxCollider;
        TiledMapMover.CollisionState _collisionState = new TiledMapMover.CollisionState();
        Vector2 _velocity;
        VirtualButton _flyInput;
        VirtualIntegerAxis _xAxisInput;
        VirtualIntegerAxis _yAxisInput;

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();

            //switch to a buterfly animation when get one.
            //var texture = entity.scene.content.Load<Texture2D>(Content.Textures.butterfly1);

            var textureCaveman = entity.scene.content.Load<Texture2D>(Content.Textures.caveman);
            _boxCollider = entity.getComponent<BoxCollider>();
            //_mover = entity.getComponent<TiledMapMover>();
            _mover = entity.addComponent(new Mover());

            var subtextures = Subtexture.subtexturesFromAtlas(textureCaveman, 32, 32);

            _animation = entity.addComponent(new Sprite<Animations>(subtextures[0]));
            //extract the animations from the atlas they are setup in rows with 8 columns
            _animation.addAnimation(Animations.Walk, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[0],
                subtextures[1],
                subtextures[2],
                subtextures[3],
                subtextures[4],
                subtextures[5]}
                ));

            _animation.addAnimation(Animations.Run, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[8+0],
                subtextures[8+1],
                subtextures[8+2],
                subtextures[8+3],
                subtextures[8+4],
                subtextures[8+5],
                subtextures[8+6]
            }));

            _animation.addAnimation(Animations.Idle, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[16]
            }));

            _animation.addAnimation(Animations.Attack, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[24+0],
                subtextures[24+1],
                subtextures[24+2],
                subtextures[24+3]
            }));

            _animation.addAnimation(Animations.Death, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[40+0],
                subtextures[40+1],
                subtextures[40+2],
                subtextures[40+3]
            }));

            _animation.addAnimation(Animations.Falling, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[48]
            }));

            _animation.addAnimation(Animations.Hurt, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[64],
                subtextures[64+1]
            }));

            _animation.addAnimation(Animations.Jumping, new SpriteAnimation(new List<Subtexture>()
            {
                subtextures[72+0],
                subtextures[72+1],
                subtextures[72+2],
                subtextures[72+3]
            }));
            setupInput();
        }

        public override void onRemovedFromEntity()
        {
            base.onRemovedFromEntity();
            _flyInput.deregister();
            _xAxisInput.deregister();
            _yAxisInput.deregister();
        }

        void setupInput()
        {
            //setup input for flying space or a on gamepad
            _flyInput = new VirtualButton();
            _flyInput.nodes.Add(new VirtualButton.KeyboardKey(Microsoft.Xna.Framework.Input.Keys.Space));
            _flyInput.nodes.Add(new VirtualButton.GamePadButton(0, Buttons.A));

            // horizontal input from dpad left stidk or keyboard left rights or a d
            _xAxisInput = new VirtualIntegerAxis();
            _xAxisInput.nodes.Add(new VirtualAxis.GamePadDpadLeftRight());
            _xAxisInput.nodes.Add(new VirtualAxis.GamePadLeftStickX());
            _xAxisInput.nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));
            _xAxisInput.nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.A, Keys.D));
            // setup vertical input
            _yAxisInput = new VirtualIntegerAxis();
            _yAxisInput.nodes.Add(new VirtualAxis.GamePadDpadUpDown());
            _yAxisInput.nodes.Add(new VirtualAxis.GamePadLeftStickY());
            _yAxisInput.nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Up, Keys.Down));
            _yAxisInput.nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.W, Keys.S));


        }

        void IUpdatable.update()
        {
            // handle movement and animations when we add them
            //var moveDir = new Vector2(_xAxisInput.value, 0);
            var moveDir = new Vector2(_xAxisInput.value, _yAxisInput.value);
            var animation = Animations.Idle;

            if (moveDir.X < 0)
            {
                // if (_collisionState.below)
                animation = Animations.Run;
                _animation.flipX = true;
                _velocity.X = -moveSpeed;
            }
            else if (moveDir.X > 0)
            {
                //if (_collisionState.below)
                animation = Animations.Run;
                _animation.flipX = false;
                _velocity.X = moveSpeed;
            }
            else
            {
                
                
                animation = Animations.Idle;
            }

            if (moveDir.Y < 0)
            {

            }
            else if (moveDir.Y >0)
            {

            }
            if (moveDir != Vector2.Zero)
            {
                var movement = moveDir * _moveSpeed * Time.deltaTime;
                CollisionResult res;
                _mover.move(movement, out res);
            }
            else
            {

            }
            //if (_collisionState.below && _flyInput.isPressed)
            //if (_flyInput.isPressed)
            //{
            //    animation = Animations.Jumping;
            //    _velocity.Y = -Mathf.sqrt(2f * flyHeight * gravity);
            //}


            //if (!_collisionState.below && _velocity.Y > 0)
            //  animation = Animations.Falling;

            // apply gravity
            //_velocity.Y += gravity * Time.deltaTime;

            // move
            // _mover.move(_velocity * Time.deltaTime, _boxCollider, _collisionState);
            //_mover.move(_velocity * Time.deltaTime, out _collisionState);
            
            

            //if (_collisionState.below)
            //    _velocity.Y = 0;

            if (!_animation.isAnimationPlaying(animation))
                _animation.play(animation);

        }
        public void onTriggerEnter(Collider other, Collider local)
        {
            Debug.log("triggerEnter:{0}", other.entity.name);

        }

        public void onTriggerExit(Collider other, Collider local)
        {
            Debug.log("triggerExit:{0}", other.entity.name);
        }

        public void update()
        {
        }
    }
}
