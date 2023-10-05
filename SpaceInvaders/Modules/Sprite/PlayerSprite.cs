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

            if (Keyboard.GetState().IsKeyDown(Keys.Z) == true)
            {
                Vector2 pos = Position;
                pos.X -= 2.0f;

                if (pos.X < 10.0f)
                {
                    pos.X = 10.0f;
                }
                Position = pos;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.X) == true)
            {
                Vector2 pos = Position;
                pos.X += 2.0f;
                if (pos.X > 800 - 58.0f)  
                {
                    pos.X = 800 - 58.0f;
                }

                Position = pos;
            }

            // Fire bullet....
            if ((Keyboard.GetState().IsKeyDown(Keys.Enter) == true) && (shooting == false))
            {
                shooting = true;
                FireBullet();
            }
            if ((Keyboard.GetState().IsKeyUp(Keys.Enter) == true) && (shooting == true))
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
        }
        #endregion
    }
}
