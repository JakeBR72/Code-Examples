
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{

    public class Koopa : IKoopa
    {
        private int delay;
        private KoopaStateMachine stateMachine;

        public bool ShouldUpdate { get; set; }

        public bool BeRemoved
        {
            get {return stateMachine.BeRemoved;}
            set { stateMachine.BeRemoved = value; }
        }
        public KoopaStateMachine.KoopaHealth Health
        {
            get {return stateMachine.Health;}
            set {stateMachine.Health = value;}
        }
        public bool shouldCollide
        {
            get { return stateMachine.ShouldCollide; }
            set { stateMachine.ShouldCollide = value; }
        }

        public Vector2 Location
        {
            get {return stateMachine.Location;}
            set {stateMachine.Location = value;}
        }
        public Rectangle DestinationRectangle
        {
            get {return stateMachine.DestinationRectangle;}
            set {stateMachine.DestinationRectangle = value;}
        }
        public IPhysics Physics
        {
            get { return stateMachine.Physics; }
            set { stateMachine.Physics = value; }
        }

        public Koopa(Vector2 location)
        {
            stateMachine = new KoopaStateMachine(location);
            Physics = new KoopaPhysics(this);
        }

        public void BeginRecover()
        {
            stateMachine.BeginRecover();
        }
        public void BeShelled()
        {
            delay = 0;
            stateMachine.BeShelled();
        }
        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }
        public void FullyRecover()
        {
            stateMachine.FullyRecover();
        }
        public void KillKoopa()
        {
            stateMachine.KillKoopa();
        }
        public void SetPosition(Vector2 location)
        {
            stateMachine.SetPosition(location);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade)
        { 
            stateMachine.Draw(spriteBatch, location, shade);
        }

        public void Update()
        {
            if (ShouldUpdate)
            {
                if (Physics.XVelocity == 0)
                {
                    delay++;
                }
                if (delay == 200)
                {
                    BeginRecover();
                } else if (delay == 400)
                {
                    delay = 0;
                    FullyRecover();
                } 
                stateMachine.Update();
            }
        }

    }
}