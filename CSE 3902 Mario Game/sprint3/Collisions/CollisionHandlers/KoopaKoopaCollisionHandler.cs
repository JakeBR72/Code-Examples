using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaKoopaCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        public KoopaKoopaCollisionHandler(ICollision side, Game1 game)
        {
            Side = side;
            Game = game;
        }
        public void handleCollision()
        {
            ICommand Command;
            Command = new KoopaKoopaCollision(Side, Game);
            Command.Execute();
        }
    }
}
