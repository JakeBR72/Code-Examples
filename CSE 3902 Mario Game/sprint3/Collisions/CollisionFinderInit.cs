using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class CollisionFinderInit
    {
        Game1 myGame;
        public CollisionFinderInit(Game1 game)
        {
            myGame = game;
        }
        public void CollisionInit()
        {
            myGame.CollisionFinder.Add(new MarioBlockCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new MarioItemCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new MarioGoombaCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new MarioKoopaCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new MarioObjectCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new EnemyEnemyCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new GoombaBlockCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new GoombaObjectCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new KoopaBlockCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new KoopaObjectCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new MarioFlagPoleCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new CameraUpdateCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new ObjectBlockCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new ObjectPipeCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new ItemBlockCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new ItemPipeCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new MarioPiranaCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new PiranaObjectCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new BowserBlockCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new MarioBowserFireCollisionFinder(myGame));
            myGame.CollisionFinder.Add(new MarioBowserCollisionFinder(myGame));
        }
    }
}
