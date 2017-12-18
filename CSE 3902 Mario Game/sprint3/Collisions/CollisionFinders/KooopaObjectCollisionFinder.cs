using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaObjectCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public KoopaObjectCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.koopaList.Count ; i++)
            {
                if (Game.koopaList[i].ShouldUpdate)
                {
                    if (!Game.koopaList[i].shouldCollide)
                    {
                        continue;
                    }
                    for (int j = 0; j < Game.objects.Count; j++)
                    {
                        side = CollisionDetector.detectCollision(Game.koopaList[i], Game.objects[j]);
                        if (!(side is NullCollision) && !(Game.objects[j] is FlagPole))
                        {
                            ICollisionHandler KoopaObject = new KoopaObjectCollisionHandler(side, Game.koopaList[i], Game);
                            KoopaObject.handleCollision();
                        }
                    }
                }
            }
        }
    }
}
