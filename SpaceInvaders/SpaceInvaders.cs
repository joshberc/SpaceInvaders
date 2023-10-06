using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Modules.Game;
using SpaceInvaders.Modules.Manager;
using SpaceInvaders.Modules.Sprite;
using SpaceInvaders.Modules.Util;
using System.Collections.Generic;

namespace SpaceInvaders
{
    public class SpaceInvaders : Game
    {
        #region Variables
        private GraphicsDeviceManager   graphics;
        private SpriteBatch             spriteBatch;
        private SpriteFont              atroxFont;
        private Texture2D               playerTexture;
        private Texture2D               missileTexture;
        private Texture2D               redEnemyTexture;
        private Texture2D               blueEnemyTexture;
        private Texture2D               greenEnemyTexture;
        private Texture2D               yellowEnemyTexture;

        private List<SoundEffect>       soundEffects;

        private TManager<GameObject> InvaderManager = new TManager<GameObject>();
        private TManager<GameObject> PlayerManager = new TManager<GameObject>();
        private TManager<GameObject> MissileManager = new TManager<GameObject>();
        #endregion

        #region Access Methods
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        public TManager<GameObject> MissileController
        {
            get { return MissileManager; }
        }

        public Texture2D MissileTexture
        {
            get { return missileTexture; }
        }

        public List<SoundEffect> SoundEffects 
        { 
            get { return soundEffects; } 
        }
        #endregion

        #region Core
        /// <summary>
        /// Initialize game settings.
        /// </summary>
        public SpaceInvaders()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Global.ScreenWidth;
            graphics.PreferredBackBufferHeight = Global.ScreenHeight;

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
        /// Load all game content.
        /// Note that content must be first be imported by the mgcb importer located in the Content folder.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch         = new SpriteBatch(GraphicsDevice);

            //Load Fonts
            atroxFont           = Content.Load<SpriteFont>("Atrox");

            //Load Sprites
            playerTexture       = Content.Load<Texture2D>("player");
            missileTexture      = Content.Load<Texture2D>("missile");
            redEnemyTexture     = Content.Load<Texture2D>("enemy-red");
            blueEnemyTexture    = Content.Load<Texture2D>("enemy-blue");
            greenEnemyTexture   = Content.Load<Texture2D>("enemy-green");
            yellowEnemyTexture  = Content.Load<Texture2D>("enemy-yellow");

            //Load Sound Effects
            soundEffects = new List<SoundEffect>();
            soundEffects.Add(Content.Load<SoundEffect>("retro-shoot-sound"));
            soundEffects.Add(Content.Load<SoundEffect>("retro-explosion-sound"));

            //Run game Setup
            SetupPlayer();
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
            PlayerManager.Update(gameTime); 
            InvaderManager.Update(gameTime);
            MissileManager.Update(gameTime);

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

            //Update Sprites
            PlayerManager.Draw(gameTime);
            InvaderManager.Draw(gameTime);
            MissileManager.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Add player object to the game.
        /// </summary>
        private void SetupPlayer()
        {
            PlayerSprite sprite = new PlayerSprite(new Sprite(playerTexture, new Vector2(400, 550), new Rectangle(0, 0, 60, 32), Color.White, new Vector2(1, 1), SpriteEffects.None, 0.0f));
            PlayerManager.Add(sprite);
        }

        /// <summary>
        /// Add all invader objects to the game.
        /// </summary>
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
            Rectangle rowCollider = new Rectangle(0, 0, 40, 32);

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
                        rowCollider = new Rectangle(0, 0, 40, 32);
                        break;
                    case 3:
                        rowSprite = blueEnemyTexture;
                        rowCollider = new Rectangle(0, 0, 40, 22);
                        break;
                    case 4:
                        rowSprite = greenEnemyTexture;
                        rowCollider = new Rectangle(0, 0, 40, 32);
                        break;
                }
                    
                for (int x = 0; x < width; x++, invaderPosition.X = start.X + (x * xOffset))
                {                               
                    InvaderSprite sprite = new InvaderSprite(new Sprite(rowSprite, invaderPosition, rowCollider, Color.White, new Vector2(1, 1), SpriteEffects.None, speed));
                    InvaderManager.Add(sprite);
                }
            }
        }

        public bool CheckInvaderCollision(Rectangle obj)
        {
            bool collided = false;

            if(InvaderManager.ObjectCount > 0)
            {
                for(int i = 0; i < InvaderManager.ObjectCount; i++)
                {
                    var sprite = (Sprite)InvaderManager[i];

                    if(sprite.CheckCollision(obj) == true)
                    {
                        InvaderManager.MarkForRemoval(sprite.BaseID);
                        collided = true;
                        soundEffects[1].Play(0.3f, 1.0f, 1.0f);
                        break;
                    }
                }
            }

            return collided;
        }
        #endregion
    }
}