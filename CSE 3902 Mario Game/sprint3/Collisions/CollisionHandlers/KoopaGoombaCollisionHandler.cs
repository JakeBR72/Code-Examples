using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaGoombaCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        public KoopaGoombaCollisionHandler(ICollision side, Game1 game)
        {
            Side = side;
            Game = game;
        }
        public void handleCollision()
        {
            ICommand Command;
            if (Side is Top)
            {
                Command = new KoopaGoombaTopCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Left)
            {
                Command = new KoopaGoombaLeftCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Right)
            {
                Command = new KoopaGoombaRightCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Bottom)
            {
                Command = new KoopaGoombaBottomCollision(Side, Game);
                Command.Execute();
            }
            else
            { 
                //shouldnt happen, maybe do some error check 
            }
        }
    }
}
