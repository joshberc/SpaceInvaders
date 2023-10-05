using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders.Modules.Sprite
{
    public class InvaderSprite : Sprite
    {
        public InvaderSprite(Sprite newSprite) : base(newSprite.SpriteTexture, newSprite.Position, newSprite.Color, newSprite.Scale, newSprite.Effect, newSprite.Speed)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 position = Position;
            position.X += Speed;

            if (position.X < 20.0f)
            {
                Speed = 1.5f;
            }
            else if (position.X > 780.0f)
            {
                Speed = -1.5f;
            }
            Position = position;

            base.Update(gameTime);
        }
    }
}
