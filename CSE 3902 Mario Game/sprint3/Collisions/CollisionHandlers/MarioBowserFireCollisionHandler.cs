
namespace MarioGame
{
    class MarioBowserFireCollisionHandler : ICollisionHandler
    {
        private Game1 Game;
        public MarioBowserFireCollisionHandler(Game1 game)
        {
            Game = game;
        }

        public void handleCollision()
        {
            ICommand Command;
            Command = new MarioBowserFireCollision(Game);
            Command.Execute();
        }
    }
}
