using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioKoopaCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioKoopaCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.koopaList.Count; ++i)
            {
                if (!Game.Mario.ShouldCollide)
                {
                    break;
                }
                if (!Game.koopaList[i].shouldCollide)
                {
                    continue;
                }
                side = CollisionDetector.detectCollision(Game.Mario, Game.koopaList[i]);
                if (!(side is NullCollision))
                {
                    ICollisionHandler MarioKoopa = new MarioKoopaCollisionHandler(side, Game);
                    MarioKoopa.handleCollision();
                }
            }
        }
    }
}
