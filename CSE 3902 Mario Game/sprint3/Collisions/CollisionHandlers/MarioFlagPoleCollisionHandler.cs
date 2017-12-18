using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{ 
    public class MarioFlagPoleCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        public MarioFlagPoleCollisionHandler(ICollision side, Game1 game)
        {
            Side = side;
            Game = game;
        }
        public void handleCollision()
        {
            ICommand Command;
                Command = new MarioFlagPoleCollision(Side, Game);
                Command.Execute();
        }
    }
}