using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager   _graphics;
        private SpriteBatch             _spriteBatch;
        private SpriteFont              _atroxFont;
        private Texture2D               _playerSprite;
        private Texture2D               _redEnemySprite;
        private Texture2D               _blueEnemySprite;
        private Texture2D               _greenEnemySprite;
        private Texture2D               _yellowEnemySprite;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Game initialization logic.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Load game content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch        = new SpriteBatch(GraphicsDevice);
            _atroxFont          = Content.Load<SpriteFont>("Atrox");
            _playerSprite       = Content.Load<Texture2D>("player");
            _redEnemySprite     = Content.Load<Texture2D>("enemy-red");
            _blueEnemySprite    = Content.Load<Texture2D>("enemy-blue");
            _greenEnemySprite   = Content.Load<Texture2D>("enemy-green");
            _yellowEnemySprite  = Content.Load<Texture2D>("enemy-yellow");
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

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            
            _spriteBatch.DrawString(_atroxFont, "Space Invaders", new Vector2(250,10), Color.White);
            _spriteBatch.Draw(_playerSprite, new Vector2(60,60), Color.White);
            _spriteBatch.Draw(_redEnemySprite, new Vector2(150, 60), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}