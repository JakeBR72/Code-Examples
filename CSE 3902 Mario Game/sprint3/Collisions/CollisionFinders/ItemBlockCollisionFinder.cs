using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class ItemBlockCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public ItemBlockCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.items.Count; i++)
            {
                if (Game.items[i].ShouldUpdate)
                {
                    if (Game.items[i].IsCollidable)
                    {
                        for (int k = 0; k < Game.blocks.Count; k++)
                        {
                            side = CollisionDetector.detectCollision(Game.items[i], Game.blocks[k]);
                            if (!(side is NullCollision))
                            {
                                ICollisionHandler itemBlock = new ItemBlockCollisionHandler(side);
                                itemBlock.handleCollision();
                            }
                        }
                    }
                }
            }
        }
    }
}
