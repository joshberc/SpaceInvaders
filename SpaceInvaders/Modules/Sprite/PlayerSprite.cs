using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Modules.Util;

namespace SpaceInvaders.Modules.Sprite
{
    public class PlayerSprite : Sprite
    {
        #region Variables
        private int playerWidth = 60;
        private bool shooting = false;
        private float moveSpeed = 2.0f;
        #endregion

        #region Core
        public PlayerSprite(Sprite newSprite) : base(newSprite.SpriteTexture, newSprite.Position, newSprite.Collider, newSprite.Color, newSprite.Scale, newSprite.Effect, newSprite.Speed)
        {
        }

        /// <summary>
        /// Handle player controls.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            //Move Left
            if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {
                Vector2 pos = Position;
                pos.X -= moveSpeed;

                if (pos.X < 0)
                {
                    pos.X = 0;
                }
                Position = pos;
            }
            //Move Right
            if (Keyboard.GetState().IsKeyDown(Keys.D) == true)
            {
                Vector2 pos = Position;
                pos.X += moveSpeed;
                int offset = Global.ScreenWidth - playerWidth;

                if (pos.X > offset)  
                {
                    pos.X = offset;
                }

                Position = pos;
            }

            // Fire Missile
            if ((Keyboard.GetState().IsKeyDown(Keys.Space) == true) && (shooting == false))
            {
                shooting = true;
                FireMissile();
            }
            if ((Keyboard.GetState().IsKeyUp(Keys.Space) == true) && (shooting == true))
            {
                shooting = false;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        /// <summary>
        /// Create new Missile object.
        /// </summary>
        private void FireMissile()
        {
            Texture2D missileTexture = Global.Instance.CoreGame.MissileTexture;
            MissileSprite newMissile = new MissileSprite(new Sprite(missileTexture, new Vector2(Position.X + 27, Position.Y), new Rectangle(0, 0, 2, 8), Color.White, new Vector2(1, 1), SpriteEffects.None, 0.0f));

            Global.Instance.CoreGame.MissileController.Add(newMissile);
        }
        #endregion
    }
}
