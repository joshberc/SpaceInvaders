namespace SpaceInvaders.Modules.Util
{
    public sealed class Global
    {
        #region Global References
        //Thread-safe singleton
        private static readonly Global instance = new Global();
        public SpaceInvaders CoreGame { get; set; }

        public static int ScreenWidth = 800;
        public static int ScreenHeight = 600;
        #endregion

        static Global()
        {
        }

        public static Global Instance
        {
            get { return (instance); }
        }
    }
}
