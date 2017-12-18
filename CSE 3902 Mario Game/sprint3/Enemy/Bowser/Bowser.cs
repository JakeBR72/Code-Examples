using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class Bowser : IBowser
    {
        private BowserStateMachine stateMachine;
        public bool ShouldUpdate { get; set; }

        private int timer = 0;
        private int fireDelay = 80;
        private bool mouthIsOpen = false;

        public bool BeRemoved
        {
            get { return stateMachine.BeRemoved; }
            set { stateMachine.BeRemoved = value; }
        }

        public Vector2 Location
        {
            get { return stateMachine.Location; }
            set { stateMachine.Location = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return stateMachine.DestinationRectangle; }
            set { stateMachine.DestinationRectangle = value; }
        }

        public IPhysics Physics
        {
            get { return stateMachine.Physics; }
            set { stateMachine.Physics = value; }
        }

        public Bowser(Vector2 location, Game1 game)
        {
            stateMachine = new BowserStateMachine(location, game);
            Physics = new BowserPhysics(this);
        }

        public void SetPosition(Vector2 location)
        {
            stateMachine.SetPosition(location);
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void BreathFire()
        {
            stateMachine.OpenMouth();
            stateMachine.BreathFire();
        }

        public void CloseMouth()
        {
            stateMachine.CloseMouth();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade)
        {
            stateMachine.Draw(spriteBatch, location, shade);
        }

        public void Update()
        {
            timer++;
            if (timer == fireDelay)
            {
                if (!mouthIsOpen)
                {
                    BreathFire();
                    mouthIsOpen = true;
                }
                else if (mouthIsOpen)
                {
                    CloseMouth();
                    mouthIsOpen = false;
                }
                timer = 0;
            }
            
            stateMachine.Update();
        }
    }
}
