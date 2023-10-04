using Microsoft.Xna.Framework;

namespace SpaceInvaders.Modules.Game
{
    public interface GameInterface
    {
        /// <summary>
        /// Initialize object.
        /// </summary>
        abstract void Initialize();

        /// <summary>
        /// Load the content.
        /// </summary>
        abstract void LoadContent();

        /// <summary>
        /// Handle input and game logic.
        /// </summary>
        /// <param name="gameTime"></param>
        abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draw objects to screen.
        /// </summary>
        /// <param name="gameTime"></param>
        abstract void Draw(GameTime gameTime);
    }
}
