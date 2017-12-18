namespace MarioGame
{
    class BowserBlockCollisionHandler : ICollisionHandler
    {
        private IBowser bowser;

        public BowserBlockCollisionHandler(IBowser bowser)
        {
            this.bowser = bowser;
        }

        public void handleCollision()
        {
            ICommand Command;
            Command = new BowserBlockCollision(bowser);
            Command.Execute();
        }
    }
}
