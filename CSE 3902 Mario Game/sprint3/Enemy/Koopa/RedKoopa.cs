
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{

    public class RedKoopa : IKoopa
    {
        private Koopa decoratedKoopa;

        public bool ShouldUpdate
        {
            get { return decoratedKoopa.ShouldUpdate; }
            set { decoratedKoopa.ShouldUpdate = value; }
        }

        public bool BeRemoved
        {
            get {return decoratedKoopa.BeRemoved;}
            set { decoratedKoopa.BeRemoved = value; }
        }
        public KoopaStateMachine.KoopaHealth Health
        {
            get {return decoratedKoopa.Health;}
            set { decoratedKoopa.Health = value;}
        }
        public bool shouldCollide
        {
            get { return decoratedKoopa.shouldCollide; }
            set { decoratedKoopa.shouldCollide = value; }
        }

        public Vector2 Location
        {
            get {return decoratedKoopa.Location;}
            set { decoratedKoopa.Location = value;}
        }
        public Rectangle DestinationRectangle
        {
            get {return decoratedKoopa.DestinationRectangle;}
            set { decoratedKoopa.DestinationRectangle = value;}
        }
        public IPhysics Physics
        {
            get { return decoratedKoopa.Physics; }
            set { decoratedKoopa.Physics = value; }
        }

        public RedKoopa(Koopa decoratedKoopa)
        {
            this.decoratedKoopa = decoratedKoopa;
            Physics = new KoopaPhysics(this);
        }

        public void BeginRecover()
        {
            decoratedKoopa.BeginRecover();
        }
        public void BeShelled()
        {
            decoratedKoopa.BeShelled();
        }
        public void ChangeDirection()
        {
            decoratedKoopa.ChangeDirection();
        }
        public void FullyRecover()
        {
            decoratedKoopa.FullyRecover();
        }
        public void KillKoopa()
        {
            decoratedKoopa.KillKoopa();
        }
        public void SetPosition(Vector2 location)
        {
            decoratedKoopa.SetPosition(location);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade)
        {
            shade = Color.Red;
            decoratedKoopa.Draw(spriteBatch, location, shade);
        }

        public void Update()
        {
            decoratedKoopa.Update();
        }

    }
}