using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class GoombaObjectCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public GoombaObjectCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.goombaList.Count; i++)
            {
                if (Game.goombaList[i].ShouldUpdate)
                {
                    for (int j = 0; j < Game.objects.Count; j++)
                    {
                        if (!Game.goombaList.ElementAt(i).ShouldCollide)
                        {
                            continue;
                        }
                        side = CollisionDetector.detectCollision(Game.goombaList[i], Game.objects[j]);
                        if (!(side is NullCollision) && !(Game.objects[j] is FlagPole))
                        {
                            ICollisionHandler GoombaObject = new GoombaObjectCollisionHandler(side, Game.goombaList[i], Game);
                            GoombaObject.handleCollision();
                        }
                    }
                }
            }
        }
    }
}
