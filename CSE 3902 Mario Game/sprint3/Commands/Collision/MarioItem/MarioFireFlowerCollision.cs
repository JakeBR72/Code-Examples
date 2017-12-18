using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioFireFlowerCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private IMario Mario;
        private IItem FireFlower;

        public MarioFireFlowerCollision(ICollision side, Game1 game)
        {
            Side = side;
            if (Side.BottomOrRight is IMario)
            {
                Mario = (IMario)Side.BottomOrRight;
                FireFlower = (IItem)Side.TopOrLeft;
            }
            else
            {
                Mario = (IMario)Side.TopOrLeft;
                FireFlower = (IItem)Side.BottomOrRight;
            }
            Game = game;
        }
        public void Execute()
        {
            FireFlower.BeRemoved = true;
            Mario.SetFire();
            Game.st.PowerUp();
            ScoreAssignments sa = new ScoreAssignments();
            Game.UI.DisplayScore(sa.PowerUp, FireFlower.Location);
        }
    }
}
