using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioKoopaBottomCollision : ICommand
    {
        Game1 Game;
        private ICollision Side;
        private IMario Mario;
        private IKoopa koopa;
        public MarioKoopaBottomCollision(ICollision side, Game1 game)
        {
            Game = game;
            Side = side;
            koopa = (IKoopa)Side.TopOrLeft;
            Mario = (IMario)Side.BottomOrRight;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (Mario is StarMario)
            {
                koopa.KillKoopa();
                Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.LowRumble, Game.RumbleHelper.LowRumble, Game.RumbleHelper.QuickRumble);
            }
            else
            {
                Mario.TakeDamage();
                Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.MidRumble, Game.RumbleHelper.MidRumble, Game.RumbleHelper.ShortRumble);
            }
        }
    }
}
