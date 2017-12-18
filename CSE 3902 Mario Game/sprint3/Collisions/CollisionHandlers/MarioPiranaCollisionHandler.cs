using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioPiranaCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        public MarioPiranaCollisionHandler(ICollision side, Game1 game)
        {
            Game = game;
            Side = side;
        }
        public void handleCollision()
        {
            ICommand Command;
            Command = new MarioPiranaCollision(Side, Game);
            Command.Execute();
           
        }
    }
}
