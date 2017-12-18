using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class PiranaObjectCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        private IPiranaPlant pirana;
        public PiranaObjectCollisionHandler(ICollision side, IPiranaPlant pirana, Game1 game)
        {
            this.pirana = pirana;
            Side = side;
            Game = game;
        }

        public void handleCollision()
        {
            ICommand Command;
            Command = new PiranaObjectCollision(pirana, Side, Game);
            Command.Execute();
            
        }
    }
}
