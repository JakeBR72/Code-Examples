using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class ObjectPipeCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public ObjectPipeCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.objects.Count; i++)
            {
                for (int j = 0; j < Game.objects.Count; j++)
                {
                    if (Game.objects[i].Equals(Game.objects[j]))
                    {
                        continue;
                    }
                    side = CollisionDetector.detectCollision(Game.objects[i], Game.objects[j]);
                    if (!(side is NullCollision) && !(Game.objects[j] is Fireball))
                    {
                        ICollisionHandler ObjectPipe = new ObjectPipeCollisionHandler(side);
                        ObjectPipe.handleCollision();
                        //j = Game.objects.Count;
                    }
                }
            }
        }
    }
}
