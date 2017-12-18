
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class PiranaPlantStateMachine
    {
        private IEnemySprite piranaSprite;
        
        public Vector2 Location { get; set; }
        public IPhysics Physics { get; set; }
        public bool BeRemoved { get; set; } = false;
        public Rectangle DestinationRectangle
        {
            get
            {
                return piranaSprite.DestinationRectangle;
            }
            set
            {
                piranaSprite.DestinationRectangle = value;
            }
        }


        public PiranaPlantStateMachine(Vector2 location)
        {
            Location = location;
            piranaSprite = PiranaSpriteFactory.Instance.GetPiranaPlantSprite();
        }

      
        public void KillPirana()
        {
            BeRemoved = true;
        }
        public void SetPosition(Vector2 loc)
        {
            DestinationRectangle = new Rectangle((int)loc.X, (int)loc.Y,
                DestinationRectangle.Width, DestinationRectangle.Height);
            Location = loc;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade)
        {
            Location = location;
            piranaSprite.Draw(spriteBatch, Location, shade);
        }
        public void Update()
        {
            Physics.UpdatePosition();
            piranaSprite.Update();
        }
    }
}