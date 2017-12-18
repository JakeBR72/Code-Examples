using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class ItemPipeCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public ItemPipeCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.items.Count; ++i)
            {
                for (int k = 0; k < Game.objects.Count; ++k)
                {
                    side = CollisionDetector.detectCollision(Game.items[i], Game.objects[k]);
                    if (!(side is NullCollision) && (Game.objects[k] is SmallPipe || Game.objects[k] is MedPipe || Game.objects[k] is TallPipe))
                    {
                        ICollisionHandler itemPipe = new ItemPipeCollisionHandler(side);
                        itemPipe.handleCollision();
                    }
                }
            }
        }
    }
}
