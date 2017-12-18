
namespace MarioGame
{
    class MarioBowserFireCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public MarioBowserFireCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            foreach (IObject ob in Game.objects)
            {
                side = CollisionDetector.detectCollision(Game.Mario, ob);
                if (!(side is NullCollision) && (ob is BowserFire))
                {
                    ICollisionHandler MarioBowserFireCollision = new MarioBowserFireCollisionHandler(Game);
                    MarioBowserFireCollision.handleCollision();
                }
            }
        }
    }
}
