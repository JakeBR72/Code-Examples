using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioItemCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioItemCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.items.Count; ++i)
            {
                if (!Game.Mario.ShouldCollide)
                {
                    break;
                }
                if (Game.items[i].IsCollidable)
                {
                    side = CollisionDetector.detectCollision(Game.Mario, Game.items[i]);
                    if (!(side is NullCollision))
                    {
                        ICollisionHandler MarioItem = new MarioItemCollisionHandler(side, Game);
                        MarioItem.handleCollision();
                    }
                }
            }
        }
    }
}
