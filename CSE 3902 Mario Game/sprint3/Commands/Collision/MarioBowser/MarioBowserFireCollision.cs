using Microsoft.Xna.Framework;

namespace MarioGame
{
    class MarioBowserFireCollision : ICommand
    {
        private Game1 Game;

        public MarioBowserFireCollision(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.Mario.TakeDamage();
            Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.MidRumble, Game.RumbleHelper.MidRumble, Game.RumbleHelper.ShortRumble);
        }
    }
}
