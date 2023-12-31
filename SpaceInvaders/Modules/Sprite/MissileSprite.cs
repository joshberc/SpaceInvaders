﻿using Microsoft.Xna.Framework;
using SpaceInvaders.Modules.Util;

namespace SpaceInvaders.Modules.Sprite
{
    public class MissileSprite : Sprite
    {
        private float acceleration = -2.0f;

        #region Core
        public MissileSprite(Sprite newSprite) : base(newSprite.SpriteTexture, newSprite.Position, newSprite.Collider, newSprite.Color, newSprite.Scale, newSprite.Effect, newSprite.Speed)
        { 
        }

        /// <summary>
        /// Handle Missile Logic.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (Position.Y < -30.0f)
            {
                Global.Instance.CoreGame.MissileController.MarkForRemoval(BaseID);
            }
            else
            {
                Vector2 pos = Position;

                pos.Y += acceleration;

                acceleration -= 0.03f;

                Position = pos;
            }

            //Collision detection
            if (Global.Instance.CoreGame.CheckInvaderCollision(GetSpriteCollider()))
            {
                Global.Instance.CoreGame.MissileController.MarkForRemoval(BaseID);
            }

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        #endregion
    }
}
