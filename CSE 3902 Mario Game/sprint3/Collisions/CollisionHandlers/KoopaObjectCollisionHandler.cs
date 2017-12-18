using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaObjectCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        private IKoopa koopa;
        public KoopaObjectCollisionHandler(ICollision side, IKoopa koopa, Game1 game)
        {
            this.koopa = koopa;
            Side = side;
            Game = game;
        }

        public void handleCollision()
        {
            ICommand Command;
            Command = new KoopaObjectCollision(koopa, Side, Game);
            Command.Execute();
            
        }
    }
}
