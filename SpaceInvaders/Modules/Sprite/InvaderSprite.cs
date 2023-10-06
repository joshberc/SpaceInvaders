using Microsoft.Xna.Framework;
using SpaceInvaders.Modules.Util;

namespace SpaceInvaders.Modules.Sprite
{
    public class InvaderSprite : Sprite
    {
        private int invaderWidth = 40;

        #region Core
        public InvaderSprite(Sprite newSprite) : base(newSprite.SpriteTexture, newSprite.Position, newSprite.Collider, newSprite.Color, newSprite.Scale, newSprite.Effect, newSprite.Speed)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 position = Position;
            position.X += Speed;
            int offset = Global.ScreenWidth - invaderWidth;

            if (position.X < 0)
            {
                Speed = 1.5f;
            }
            else if (position.X > offset)
            {
                Speed = -1.5f;
            }
            Position = position;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        #endregion
    }
}
