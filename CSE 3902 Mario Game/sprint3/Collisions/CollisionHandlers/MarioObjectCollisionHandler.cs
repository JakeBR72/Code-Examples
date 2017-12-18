using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioObjectCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;

        public MarioObjectCollisionHandler(ICollision side, Game1 game)
        {
            Side = side;
            Game = game;
        }
        public void handleCollision()
        {
            ICommand Command;

            if (Side is Top)
            {
                Command = new MarioObjectTopCollision(Side, Game);
                Command.Execute();
            }
            else if (Side is Left)
            {
                Command = new MarioObjectLeftCollision(Side);
                Command.Execute();
            }
            else if (Side is Right)
            {
                Command = new MarioObjectRightCollision(Side);
                Command.Execute();
            }
            else if (Side is Bottom)
            {
                Command = new MarioObjectBottomCollision(Side);
                Command.Execute();
            }
        }
    }
}
