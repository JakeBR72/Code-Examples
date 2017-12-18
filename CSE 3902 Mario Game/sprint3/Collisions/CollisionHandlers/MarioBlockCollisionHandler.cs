using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioBlockCollisionHandler : ICollisionHandler
    {
        private ICollision Side;
        Game1 Game;
        public MarioBlockCollisionHandler(ICollision side, Game1 Game1)
        {
            Side = side;
            Game = Game1;
        }
        public void handleCollision()
        {
            ICommand Command;
            if (Side is Top)
            {
                Command = new MarioBlockTopCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Left)
            {
                Command = new MarioBlockLeftCollision(Side);
                Command.Execute();
            }
            else if (Side is Right)
            {
                Command = new MarioBlockRightCollision(Side);
                Command.Execute();
            }
            else if (Side is Bottom)
            {
                Command = new MarioBlockBottomCollision(Side, Game);
                Command.Execute();
            }
            else
            {
                //shouldnt happen, maybe do some error check 
            }
        }
    }
}
