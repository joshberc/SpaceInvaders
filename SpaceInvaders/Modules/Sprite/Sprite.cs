using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Modules.Game;
using SpaceInvaders.Modules.Util;

namespace SpaceInvaders.Modules.Sprite
{
    public class Sprite : GameObject
    {
        #region Variables
        private Texture2D       spriteTexture;
        private Vector2         position;
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

        public Sprite(Texture2D newSpriteTexture, Vector2 newPosition, Color newColor, Vector2 newScale, SpriteEffects newEffects, float newSpeed)
        {
            Reset();
            spriteTexture = newSpriteTexture;
            position = newPosition;
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
            origin = new Vector2(20, 0);
            scale = new Vector2(1, 1);
            rotation = 0.0f;
            color = Color.White;
            effect = SpriteEffects.None;
            depth = 0.0f;
            speed = 0.0f;
        }
        #endregion
    }
}
