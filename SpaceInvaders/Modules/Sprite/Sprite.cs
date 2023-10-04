using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Modules.Game;

namespace SpaceInvaders.Modules.Sprite
{
    internal class Sprite : GameInterface
    {
        #region Variables
        private Vector2         position;
        private Vector2         origin;
        private float           scale;
        private float           rotation;
        private Color           color;
        private SpriteEffect    effect;
        private float           depth;
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

        public float Scale
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
        public SpriteEffect Effect
        {
            get { return effect; }
            set { effect = value; }
        }

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        #endregion

        #region Core
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void LoadContent()
        {
            throw new System.NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void Draw(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
