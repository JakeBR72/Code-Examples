using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioStarCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private IMario Mario;
        private IItem Star;

        public MarioStarCollision(ICollision side, Game1 game)
        {
            Side = side;
            if (Side.BottomOrRight is IMario)
            {
                Mario = (IMario)Side.BottomOrRight;
                Star = (IItem)Side.TopOrLeft;
            } 
            else
            {
                Mario = (IMario)Side.TopOrLeft;
                Star = (IItem)Side.BottomOrRight;
            }
            Game = game;
        }
        public void Execute()
        {
            Star.BeRemoved = true;
            Mario.AddStar();
            Game.st.EnterStarCombo();
        }
    }
}
