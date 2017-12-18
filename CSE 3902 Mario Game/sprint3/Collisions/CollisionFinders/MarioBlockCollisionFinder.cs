using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioBlockCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioBlockCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();

            for (int i=0; i<Game.blocks.Count; ++i)
            {
                if (!Game.Mario.ShouldCollide)
                {
                    break;
                }
                if (Game.blocks[i].ShouldUpdate)
                {
                    side = CollisionDetector.detectCollision(Game.Mario, Game.blocks[i]);
                    if (!(side is NullCollision))
                    {
                        ICollisionHandler MarioBlock = new MarioBlockCollisionHandler(side, Game);
                        MarioBlock.handleCollision();
                    }
                }
            }
        }
    }
}
