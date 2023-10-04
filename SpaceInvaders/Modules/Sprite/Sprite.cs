using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Modules.Game;
using SpaceInvaders.Modules.Util;

namespace SpaceInvaders.Modules.Sprite
{
    public class Sprite : GameInterface
    {
        #region Variables
        public Texture2D        texture;
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
        public virtual void Initialize()
        {
        }

        public virtual void LoadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
            Global.Instance.CoreGame.SpriteBatch.Draw(texture, position, null, color, rotation, origin, scale, effect, depth);
        }
        #endregion
    }
}
