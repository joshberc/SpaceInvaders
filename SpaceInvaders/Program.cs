﻿namespace SpaceInvaders
{
    public static class Program
    {
        static void Main()
        {
            using (var game = new SpaceInvaders.Game())
            {
                game.Run();
            }
        }
    }
}   
