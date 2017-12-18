
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioFlagPoleCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioFlagPoleCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i = 0; i < Game.objects.Count; ++i)
            {
                if (!Game.Mario.ShouldCollide)
                {
                    break;
                }
                side = CollisionDetector.detectCollision(Game.Mario, Game.objects[i]);
                if (!(side is NullCollision))
                {
                    if (Game.objects[i] is FlagPole)
                    {
                        ICollisionHandler MarioObject = new MarioFlagPoleCollisionHandler(side, Game);
                        MarioObject.handleCollision();
                    }
                }
            }
        }
    }
}