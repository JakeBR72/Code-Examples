using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioPiranaCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioPiranaCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            foreach (PiranaPlant minion in Game.piranaPlantList)
            {
                if (!Game.Mario.ShouldCollide)
                {
                    break;
                }
                side = CollisionDetector.detectCollision(Game.Mario, minion);
                if (!(side is NullCollision))
                {
                    ICollisionHandler MarioPirana = new MarioPiranaCollisionHandler(side, Game);
                    MarioPirana.handleCollision();
                }
            }
        }
    }
}
