using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class PiranaObjectCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public PiranaObjectCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.piranaPlantList.Count; i++)
            {
                if (Game.piranaPlantList[i].ShouldUpdate)
                {
                    for (int j = 0; j < Game.objects.Count; j++)
                    {
                        side = CollisionDetector.detectCollision(Game.piranaPlantList[i], Game.objects[j]);
                        if (!(side is NullCollision) && (Game.objects[j] is Fireball))
                        {
                            ICollisionHandler PiranaObject = new PiranaObjectCollisionHandler(side, Game.piranaPlantList[i], Game);
                            PiranaObject.handleCollision();
                        }
                    }
                }
            }
        }
    }
}
