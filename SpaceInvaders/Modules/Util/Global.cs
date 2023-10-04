using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.Modules.Util
{
    public sealed class Global
    {
        //Thread-safe singleton
        private static readonly Global instance = new Global();

        static Global()
        {
        }

        public static Global Instance
        {
            get { return (instance); }
        }

        public SpaceInvaders CoreGame {  get; set; }
    }
}
