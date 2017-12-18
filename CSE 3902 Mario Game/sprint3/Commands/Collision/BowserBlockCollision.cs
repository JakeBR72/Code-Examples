using Microsoft.Xna.Framework;

namespace MarioGame
{
    class BowserBlockCollision : ICommand
    {
        private IBowser bowser;


        public BowserBlockCollision(IBowser bowser)
        {
            this.bowser = bowser;
        }
        public void Execute()
        {
            bowser.Physics.YVelocity = 0;
        }
    }
}
