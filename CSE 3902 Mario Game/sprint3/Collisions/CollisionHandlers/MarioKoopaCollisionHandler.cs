using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioKoopaCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;

        public MarioKoopaCollisionHandler(ICollision side, Game1 game)
        {
            Side = side;
            Game = game;
        }
        public void handleCollision()
        {
            ICommand Command;
            if (Side is Top)
            {
                Command = new MarioKoopaTopCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Left)
            {
                Command = new MarioKoopaLeftCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Right)
            {
                Command = new MarioKoopaRightCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Bottom)
            {
                Command = new MarioKoopaBottomCollision(Side, Game);
                Command.Execute();
            }
            else
            {
                //shouldnt happen, maybe do some error check 
            }
        }
    }
}
