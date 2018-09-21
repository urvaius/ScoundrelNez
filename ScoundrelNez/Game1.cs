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
        //GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;
        
        //public Game1() : base ( width: 1280, height: 768, isFullScreen: false, enableEntitySystems: false)
        //{
        //    // graphics = new GraphicsDeviceManager(this);
        //    // Content.RootDirectory = "Content";
        //    Core.defaultSamplerState = SamplerState.LinearClamp;
        //}
        public Game1() : base()
        {
            policy = Scene.SceneResolutionPolicy.ShowAll;
            Scene.setDefaultDesignResolution(640, 480, policy);
            Screen.setSize(640 * 2, 480 * 2);
            Window.AllowUserResizing = true;
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
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
