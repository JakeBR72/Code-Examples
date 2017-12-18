using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioGoombaCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioGoombaCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            foreach (Goomba minion in Game.goombaList)
            {
                if (!minion.ShouldCollide)
                {
                    continue;
                }
                if (!Game.Mario.ShouldCollide)
                {
                    break;
                }
                side = CollisionDetector.detectCollision(Game.Mario, minion);
                if (!(side is NullCollision))
                {
                    ICollisionHandler MarioGoomba = new MarioGoombaCollisionHandler(side, Game);
                    MarioGoomba.handleCollision();
                }
            }
        }
    }
}
