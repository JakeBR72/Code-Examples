
namespace MarioGame
{
    class MarioBowserCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioBowserCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            foreach (Bowser bowser in Game.bowserList)
            {
                if (!Game.Mario.ShouldCollide)
                {
                    break;
                }

                side = CollisionDetector.detectCollision(Game.Mario, bowser);
                if (!(side is NullCollision))
                {
                    ICollisionHandler MarioBowser = new MarioBowserCollisionHandler(Game);
                    MarioBowser.handleCollision();
                }
            }
        }
    }
}
