
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{

    public class PiranaPlant : IPiranaPlant
    {
        private PiranaPlantStateMachine stateMachine;
        public bool BeRemoved
        {
            get { return stateMachine.BeRemoved; }
            set { stateMachine.BeRemoved = value; }
        }
        public bool ShouldUpdate { get; set; }

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

        public PiranaPlant(Vector2 location)
        {
            stateMachine = new PiranaPlantStateMachine(location);
            Physics = new PiranaPhysics(this);
        }


        public void KillPirana()
        {
            stateMachine.KillPirana();
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