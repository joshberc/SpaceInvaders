using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Modules.Game
{
    public class GameObject : GameInterface
    {
        public Int32 BaseID { get; set; }

        public GameObject()
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
        }

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
