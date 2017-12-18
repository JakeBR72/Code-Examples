using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class GoombaObjectCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        private Goomba goomba;
        public GoombaObjectCollisionHandler(ICollision side, Goomba goomba, Game1 game)
        {
            this.goomba = goomba;
            Side = side;
            Game = game;
        }

        public void handleCollision()
        {
            ICommand Command;
            Command = new GoombaObjectCollision(goomba, Side, Game);
            Command.Execute();
            
        }
    }
}
