using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class ObjectBlockCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public ObjectBlockCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.objects.Count; ++i)
            {
                if (Game.objects[i].ShouldUpdate)
                {
                    for (int j = 0; j < Game.blocks.Count; ++j)
                    {
                        side = CollisionDetector.detectCollision(Game.objects[i], Game.blocks[j]);
                        if (!(side is NullCollision) && !(Game.blocks[j].State is HiddenBlockState))
                        {

                            ICollisionHandler ObjectBlock = new ObjectBlockCollisionHandler(side);
                            ObjectBlock.handleCollision();
                            //j = Game.blocks.Count;
                        }
                    }
                }
            }
        }
    }
}
