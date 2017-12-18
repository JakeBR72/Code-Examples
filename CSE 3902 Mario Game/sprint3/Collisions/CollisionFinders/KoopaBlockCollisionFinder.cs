using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaBlockCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public KoopaBlockCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.koopaList.Count; ++i)
            {
                if (Game.koopaList[i].ShouldUpdate)
                {
                    if (!Game.koopaList[i].shouldCollide)
                    {
                        continue;
                    }
                    for (int j = 0; j < Game.blocks.Count; ++j)
                    {
                        side = CollisionDetector.detectCollision(Game.koopaList[i], Game.blocks[j]);
                        if (!(side is NullCollision))
                        {
                            ICollisionHandler KoopaBlock = new KoopaBlockCollisionHandler(side, Game.koopaList[i], Game);
                            KoopaBlock.handleCollision();
                        }
                    }
                }
            }
        }
    }
}
