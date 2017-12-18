using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaBlockCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        private ICollision Side;
        private IKoopa koopa;
        public KoopaBlockCollisionHandler(ICollision side, IKoopa koopa, Game1 game)
        {
            Side = side;
            this.koopa = koopa;
            Game = game;
        }
        public void handleCollision()
        {
            ICommand Command;
            Command = new KoopaBlockCollision(koopa, Side, Game);
            Command.Execute();
        }
    }
}
