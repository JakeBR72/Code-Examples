using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioObjectCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioObjectCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.objects.Count; ++i)
            {
                if (!Game.Mario.ShouldCollide)
                {
                    break;
                }
                side = CollisionDetector.detectCollision(Game.Mario, Game.objects[i]);
                if (!(side is NullCollision) && !(Game.objects[i] is FlagPole) && !(Game.objects[i] is Fireball)
                    && !(Game.objects[i] is BowserFire) && !(Game.objects[i] is Axe))
                {
                    ICollisionHandler MarioObject = new MarioObjectCollisionHandler(side, Game);
                    MarioObject.handleCollision();
                }
            }
        }
    }
}
