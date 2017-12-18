using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioPiranaCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private IPiranaPlant Pirana;
        private IMario Mario;
        public MarioPiranaCollision(ICollision side, Game1 game)
        {
            Game = game;
            Side = side;
            if (Side.BottomOrRight is IMario)
            {
                Mario = (IMario)Side.BottomOrRight;
                Pirana = (IPiranaPlant)Side.TopOrLeft;
            }   else
            {
                Pirana = (IPiranaPlant)Side.BottomOrRight;
                Mario = (IMario)Side.TopOrLeft;
            }
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (Mario is StarMario)
            {
                Pirana.KillPirana();
                Game.st.PiranaFire();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.Pirana, Pirana.Location);
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
