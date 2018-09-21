using ScoundrelNez.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
namespace ScoundrelNez
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Nez.Core
    {
        Scene startScene;
        Scene.SceneResolutionPolicy policy;
        
        
        //public Game1() : base ( width: 1280, height: 768, isFullScreen: false, enableEntitySystems: false)
        //{
        
        //    Core.defaultSamplerState = SamplerState.LinearClamp;
        //}
        public Game1() : base()
        {
            policy = Scene.SceneResolutionPolicy.ShowAll;
            Scene.setDefaultDesignResolution(640, 480, policy);
            Screen.setSize(640 * 2, 480 * 2);
            Window.AllowUserResizing = true;
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            
            //startScene = new HomeScene();
            startScene = new MenuScene();
            scene = startScene;
           // var myScene = Scene.createWithDefaultRenderer(Color.ForestGreen);
            //scene = myScene;
        }

        protected override void LoadContent()
        {
            
        }

       
        protected override void UnloadContent()
        {
            
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
           

            base.Draw(gameTime);
        }
    }
}
