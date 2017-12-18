using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioGoombaRightCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private Goomba Goomba;
        private IMario Mario;
        public MarioGoombaRightCollision(ICollision side, Game1 game)
        {
            Game = game;
            Side = side;
            Mario = (IMario)Side.BottomOrRight;
            Goomba = (Goomba)Side.TopOrLeft;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (Mario is StarMario)
            {
                Goomba.BeFlipped();
                Game.st.DefeatGoomba();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.Goomba, Goomba.Location);
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
