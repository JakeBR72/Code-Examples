using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioGoombaCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        public MarioGoombaCollisionHandler(ICollision side, Game1 game)
        {
            Game = game;
            Side = side;
        }
        public void handleCollision()
        {
            ICommand Command;
            if (Side is Top)
            {
                Command = new MarioGoombaTopCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Left)
            {
                Command = new MarioGoombaLeftCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Right)
            {
                Command = new MarioGoombaRightCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Bottom)
            {
                Command = new MarioGoombaBottomCollision(Side, Game);
                Command.Execute();
            }
            else
            {
                //shouldnt happen, maybe do some error check 
            }
        }
    }
}
