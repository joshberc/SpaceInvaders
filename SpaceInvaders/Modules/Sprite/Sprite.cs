using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Modules.Game;
using SpaceInvaders.Modules.Util;
using System;

namespace SpaceInvaders.Modules.Sprite
{
    public class Sprite : GameObject
    {
        #region Variables
        private Texture2D       spriteTexture;
        private Vector2         position;
        private Rectangle       collider;
        private Vector2         origin;
        private Vector2         scale;
        private float           rotation;
        private Color           color;
        private SpriteEffects   effect;
        private float           depth;
        private float           speed;
        #endregion

        #region Access Methods
        public Texture2D SpriteTexture
        {
            get { return spriteTexture; } 
            set {  spriteTexture = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle Collider
        {
            get { return collider; }
            set { collider = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public SpriteEffects Effect
        {
            get { return effect; }
            set { effect = value; }
        }

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        #endregion

        #region Core
        public Sprite()
        {
            Reset();
        }

        public Sprite(Vector2 newPosition)
        {
            Reset();
            position = newPosition;
        }

        public Sprite(Texture2D newSpriteTexture, Vector2 newPosition, Rectangle newCollider, Color newColor, Vector2 newScale, SpriteEffects newEffects, float newSpeed)
        {
            Reset();
            spriteTexture = newSpriteTexture;
            position = newPosition;
            collider = newCollider;
            scale = newScale;
            color = newColor;
            effect = newEffects;
            speed = newSpeed;
        }

        public override void Draw(GameTime gameTime)
        {
            Global.Instance.CoreGame.SpriteBatch.Draw(spriteTexture, position, null, color, rotation, origin, scale, effect, depth);
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Assign default values.
        /// </summary>
        private void Reset()
        {
            position = new Vector2(0.0f);
            collider = new Rectangle(0, 0, 0, 0);
            origin = new Vector2(0, 0);
            scale = new Vector2(1, 1);
            rotation = 0.0f;
            color = Color.White;
            effect = SpriteEffects.None;
            depth = 0.0f;
            speed = 0.0f;
        }

        public Rectangle GetSpriteCollider()
        {
            return (new Rectangle((int)Position.X, (int)Position.Y, (int)Collider.Width, (int)Collider.Height));
        }

        public bool CheckCollision(Rectangle obj)
        {
             return obj.Intersects(GetSpriteCollider());
        }
        #endregion
    }
}
