using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class GoombaBlockCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        private Goomba goomba;

        public GoombaBlockCollisionHandler(ICollision side, Goomba goomba, Game1 game)
        {
            this.goomba = goomba;
            Side = side;
            Game = game;
        }

        public void handleCollision()
        {
            ICommand Command;
            Command = new GoombaBlockCollision(goomba, Side, Game);
            Command.Execute();
            
        }
    }
}
