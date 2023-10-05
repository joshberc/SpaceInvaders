using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Modules.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Modules.Sprite
{
    public class PlayerSprite : Sprite
    {
        private bool shooting = false;

        #region Core
        public PlayerSprite(Sprite newSprite) : base(newSprite.SpriteTexture, newSprite.Position, newSprite.Color, newSprite.Scale, newSprite.Effect, newSprite.Speed)
        {
        }

        public override void Update(GameTime gameTime)
        {

            //Move Left
            if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {
                Vector2 pos = Position;
                pos.X -= 2.0f;

                if (pos.X < 40.0f)
                {
                    pos.X = 40.0f;
                }
                Position = pos;
            }
            //Move Right
            if (Keyboard.GetState().IsKeyDown(Keys.D) == true)
            {
                Vector2 pos = Position;
                pos.X += 2.0f;
                if (pos.X > 760)  
                {
                    pos.X = 760;
                }

                Position = pos;
            }

            // Fire bullet....
            if ((Keyboard.GetState().IsKeyDown(Keys.Space) == true) && (shooting == false))
            {
                shooting = true;
                FireBullet();
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

        private void FireBullet()
        {
            Texture2D missileTexture = Global.Instance.CoreGame.MissileTexture;
            MissileSprite newMissile = new MissileSprite(new Sprite(missileTexture, new Vector2(Position.X + 27, Position.Y), Color.White, new Vector2(1, 1), SpriteEffects.None, 0.0f));

            Global.Instance.CoreGame.MissileController.Add(newMissile);
        }
        #endregion
    }
}
