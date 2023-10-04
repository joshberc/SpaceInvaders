using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Modules.Util;

namespace SpaceInvaders
{
    public class SpaceInvaders : Microsoft.Xna.Framework.Game
    {
        #region Variables
        private GraphicsDeviceManager   graphics;
        private SpriteBatch             spriteBatch;
        private SpriteFont              atroxFont;
        private Texture2D               playerSprite;
        private Texture2D               redEnemySprite;
        private Texture2D               blueEnemySprite;
        private Texture2D               greenEnemySprite;
        private Texture2D               yellowEnemySprite;
        #endregion

        #region Access Methods
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }
        #endregion

        #region Core
        public SpaceInvaders()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Game initialization logic.
        /// </summary>
        protected override void Initialize()
        {
            //Set Singleton
            Global.Instance.CoreGame = this;

            base.Initialize();
        }

        /// <summary>
        /// Load game content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch        = new SpriteBatch(GraphicsDevice);
            atroxFont          = Content.Load<SpriteFont>("Atrox");
            playerSprite       = Content.Load<Texture2D>("player");
            redEnemySprite     = Content.Load<Texture2D>("enemy-red");
            blueEnemySprite    = Content.Load<Texture2D>("enemy-blue");
            greenEnemySprite   = Content.Load<Texture2D>("enemy-green");
            yellowEnemySprite  = Content.Load<Texture2D>("enemy-yellow");
        }

        /// <summary>
        /// Game Update Logic. Updates once per frame.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
                
            base.Update(gameTime);
        }

        /// <summary>
        /// Game drawing logic. Updates once per frame.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            
            spriteBatch.DrawString(atroxFont, "Space Invaders", new Vector2(250,10), Color.White);
            spriteBatch.Draw(playerSprite, new Vector2(60,60), Color.White);
            spriteBatch.Draw(redEnemySprite, new Vector2(150, 60), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion
    }
}