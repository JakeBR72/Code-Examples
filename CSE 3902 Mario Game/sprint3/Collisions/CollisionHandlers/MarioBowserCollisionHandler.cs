using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioBowserCollisionHandler : ICollisionHandler
    {
        private Game1 Game;

        public MarioBowserCollisionHandler(Game1 game)
        {
            Game = game;
        }
        public void handleCollision()
        {
            ICommand Command = new MarioBowserCollision(Game);
            Command.Execute();
        }
    }
}
