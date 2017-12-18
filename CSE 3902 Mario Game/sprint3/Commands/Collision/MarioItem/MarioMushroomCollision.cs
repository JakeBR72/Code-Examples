using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioMushroomCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private IMario Mario;
        private IItem Mushroom;
        public MarioMushroomCollision(ICollision side, Game1 game)
        {
            Side = side;
            if (Side.BottomOrRight is IMario)
            {
                Mario = (IMario)Side.BottomOrRight;
                Mushroom = (IItem)Side.TopOrLeft;
            }
            else
            {
                Mario = (IMario)Side.TopOrLeft;
                Mushroom = (IItem)Side.BottomOrRight;
            }

            Game = game;
        }
        public void Execute()
        {
            Mushroom.BeRemoved = true;
            if (Mario.Size() != MarioStateMachine.MarioSize.Fire)
            {
                Mario.SetBig();
                Game.st.PowerUp();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.PowerUp, Mushroom.Location);
            }
        }
    }
}
