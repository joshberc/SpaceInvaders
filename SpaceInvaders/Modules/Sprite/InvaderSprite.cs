using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders.Modules.Sprite
{
    public class InvaderSprite : Sprite
    {
        public InvaderSprite(Texture2D _sprite, Vector2 _position, Vector2 _origin, Vector2 _scale, float _rotation, Color _color, SpriteEffects _effect, float _depth)
        {
            texture = _sprite;
            Position = _position;
            Origin = _origin;
            Scale = _scale;
            Rotation = _rotation;
            Color = _color;
            Effect = _effect;
            Depth = _depth;

            Speed = 1.0f;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 position = Position;
            position.X += Speed;

            if (position.X < 10.0f)
            {
                Speed = 1.0f;
            }
            else if (position.X > 500.0f)
            {
                Speed = -1.0f;
            }
            Position = position;
        }
    }
}
