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
            _spriteBatch    = new SpriteBatch(GraphicsDevice);
            _atroxFont      = Content.Load<SpriteFont>("Atrox");
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

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_atroxFont, "Space Invaders", new Vector2(10,10), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}