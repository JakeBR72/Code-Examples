using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioBowserCollision : ICommand
    {
        Game1 Game;

        public MarioBowserCollision(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            Game.Mario.marioCanTransition = false;
            Game.Mario.marioCanTransitionLeftPipe = false;

            if (Game.Mario is StarMario)    //Technically will never be possible considering the scope of the project
            {
                //Bowser.KillBowser();  //Todo
                Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.LowRumble, Game.RumbleHelper.LowRumble, Game.RumbleHelper.QuickRumble);
            }
            else
            {
                Game.Mario.TakeDamage();
                Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.MidRumble, Game.RumbleHelper.MidRumble, Game.RumbleHelper.ShortRumble);
            }
        }
    }
}
