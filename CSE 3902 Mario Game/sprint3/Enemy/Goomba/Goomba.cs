
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{

    public class Goomba : IGameObject
    {
        private GoombaStateMachine stateMachine;

        public bool ShouldUpdate { get; set; }
        public bool ShouldCollide
        {
            get { return stateMachine.Health == GoombaStateMachine.GoombaHealth.Normal; }
        }
        public bool BeRemoved
        {
            get{return stateMachine.BeRemoved;}
            set { stateMachine.BeRemoved = value; }
        }
        public GoombaStateMachine.GoombaHealth Health
        {
            get {return stateMachine.Health;}
            set {stateMachine.Health = value;}
        }

        public Rectangle DestinationRectangle
        {
            get { return stateMachine.DestinationRectangle; }
            set { stateMachine.DestinationRectangle = value; }
        }
        public Vector2 Location
        {
            get {return stateMachine.Location;}
            set {stateMachine.Location = value;}
        }
        public IPhysics Physics
        {
            get { return stateMachine.Physics; }
            set { stateMachine.Physics = value; }
        }


        public Goomba(Vector2 location)
        {
            
            stateMachine = new GoombaStateMachine(location);
            Physics = new GoombaPhysics(this);
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }

        public void BeStomped()
        {
            stateMachine.BeStomped();
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
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
                stateMachine.Update();
            }
        }

    }
}