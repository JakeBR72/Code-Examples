using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class EnemyEnemyCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public EnemyEnemyCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i=0; i<Game.goombaList.Count; ++i)
            {
                if (Game.goombaList[i].ShouldUpdate)
                {
                    // GoombaGoombaCollision
                    for (int j = i + 1; j < Game.goombaList.Count; ++j)
                    {
                        if (!Game.goombaList.ElementAt(i).ShouldCollide
                            || !Game.goombaList.ElementAt(j).ShouldCollide)
                        {
                            continue;
                        }
                        side = CollisionDetector.detectCollision(Game.goombaList[i], Game.goombaList[j]);
                        if (!(side is NullCollision))
                        {
                            ICollisionHandler GoombaGoomba = new GoombaGoombaCollisionHandler(side);
                            GoombaGoomba.handleCollision();
                        }
                    }
                    // GoombaKoopaCollision
                    for (int k = 0; k < Game.koopaList.Count; ++k)
                    {
                        if (!Game.koopaList[k].shouldCollide)
                        {
                            continue;
                        }
                        side = CollisionDetector.detectCollision(Game.goombaList[i], Game.koopaList[k]);
                        if (!(side is NullCollision))
                        {
                            ICollisionHandler GoombaKoopa = new KoopaGoombaCollisionHandler(side, Game);
                            GoombaKoopa.handleCollision();
                        }
                    }
                }
            }
            for (int k=0; k<Game.koopaList.Count; ++k)
            {
                if (Game.koopaList[k].ShouldUpdate)
                {
                    // KoopaKoopaCollision
                    for (int l = k + 1; l < Game.koopaList.Count; ++l)
                    {
                        if (!Game.koopaList[k].shouldCollide || !Game.koopaList[l].shouldCollide)
                        {
                            continue;
                        }
                        side = CollisionDetector.detectCollision(Game.koopaList[k], Game.koopaList[l]);
                        if (!(side is NullCollision))
                        {
                            ICollisionHandler KoopaKoopa = new KoopaKoopaCollisionHandler(side, Game);
                            KoopaKoopa.handleCollision();
                        }
                    }
                }
            }
        }
    }
}
