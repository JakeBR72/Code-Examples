using System.Linq;

namespace MarioGame
{
    class BowserBlockCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public BowserBlockCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.bowserList.Count; ++i)
            {
                for (int j = 0; j < Game.blocks.Count; ++j)
                {
                    side = CollisionDetector.detectCollision(Game.bowserList[i], Game.blocks[j]);
                    if (!(side is NullCollision))
                    {
                        ICollisionHandler BowserBlock = new BowserBlockCollisionHandler(Game.bowserList[i]);
                        BowserBlock.handleCollision();
                    }
                }
            }
        }
    }
}
