using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Modules.Game;
using SpaceInvaders.Modules.Manager;
using SpaceInvaders.Modules.Sprite;
using SpaceInvaders.Modules.Util;
using System;

namespace SpaceInvaders
{
    public class SpaceInvaders : Microsoft.Xna.Framework.Game
    {
        #region Variables
        private GraphicsDeviceManager   graphics;
        private SpriteBatch             spriteBatch;
        private SpriteFont              atroxFont;
        private Texture2D               playerTexture;
        private Texture2D               redEnemyTexture;
        private Texture2D               blueEnemyTexture;
        private Texture2D               greenEnemyTexture;
        private Texture2D               yellowEnemyTexture;

        private TManager<GameObject> InvaderManager = new TManager<GameObject>();
        private TManager<GameObject> PlayerManager = new TManager<GameObject>();
        private TManager<GameObject> BulletManager = new TManager<GameObject>();
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

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

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
            spriteBatch         = new SpriteBatch(GraphicsDevice);

            atroxFont           = Content.Load<SpriteFont>("Atrox");
            playerTexture       = Content.Load<Texture2D>("player");
            redEnemyTexture     = Content.Load<Texture2D>("enemy-red");
            blueEnemyTexture    = Content.Load<Texture2D>("enemy-blue");
            greenEnemyTexture   = Content.Load<Texture2D>("enemy-green");
            yellowEnemyTexture  = Content.Load<Texture2D>("enemy-yellow");

            SetupInvaders();
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

            //Update Sprites
            InvaderManager.Update(gameTime);

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
            spriteBatch.Draw(playerTexture, new Vector2(60,60), Color.White);

            //Update Sprites
            InvaderManager.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion

        #region Helper Functions

        private void SetupInvaders()
        {
            Vector2 start   = new Vector2(10.0f, 80.0f);
            int width     = 8;
            int height    = 4;
            int xOffset   = 65;
            int yOffset   = 40;
            float speed     = 1.5f;

            Vector2 invaderPosition = start;
            Texture2D rowSprite = redEnemyTexture;

            //Populate Invader Manager
            for(int y  = 0; y < height; y++, invaderPosition.Y = start.Y + (y * yOffset))
            {
                //Reset X position
                invaderPosition.X = start.X;

                //Update sprite
                switch (y)
                {
                    case 2:
                        rowSprite = yellowEnemyTexture;
                        break;
                    case 3:
                        rowSprite = blueEnemyTexture;
                        break;
                    case 4:
                        rowSprite = greenEnemyTexture;
                        break;
                }
                    
                for (int x = 0; x < width; x++, invaderPosition.X = start.X + (x * xOffset))
                {                               
                    InvaderSprite sprite = new InvaderSprite(new Sprite(rowSprite, invaderPosition, Color.White, new Vector2(1, 1), SpriteEffects.None, speed));
                    InvaderManager.Add(sprite);
                }
            }
            
        }
        #endregion
    }
}