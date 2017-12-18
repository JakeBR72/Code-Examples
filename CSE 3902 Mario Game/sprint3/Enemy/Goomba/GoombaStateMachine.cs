
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class GoombaStateMachine
    {

        private IGoombaSprite GoombaSprite;
        private int countToDeath;
        private int removeForFlipped = 200;
        private int removeForStomped = 40;
        private bool movingLeft = true;



        public bool BeRemoved { get; set; } = false;
        public enum GoombaHealth { Normal, Stomped, Flipped };
        public GoombaHealth Health { get; set; } = GoombaHealth.Normal;

        public Vector2 Location { get; set; }
        public IPhysics Physics { get; set; }
        public Rectangle DestinationRectangle
        {
            get {return GoombaSprite.DestinationRectangle;}
            set{GoombaSprite.DestinationRectangle = value;}
        }

        public GoombaStateMachine(Vector2 location)
        {
            Location = location;
            GoombaSprite = GoombaSpriteFactory.Instance.GetLeftMovingSprite();
        }


        public void BeStomped()
        {
            if (Health != GoombaHealth.Stomped)
            {
                Physics.GravityCoef = 0.0;
                Physics.YVelocity = 0;
                Physics.XVelocity = 0;
                Health = GoombaHealth.Stomped;
            }
        }

        public void BeFlipped()
        {
            if (Health != GoombaHealth.Flipped)
            {
                Physics.YVelocity = Physics.YMaxVelocity;
                MarioSoundBoard.Instance.PlayMarioKick();
                Health = GoombaHealth.Flipped;
            }
        }
        public void ChangeDirection()
        {
            Physics.XVelocity *= -1;
            movingLeft = !movingLeft;
        }

        private void NeedsRemoved()
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
            GoombaSprite.Draw(spriteBatch, Location, shade);
        }

        public void Update()
        {
            Physics.UpdatePosition();
            switch (Health)
            {
                case GoombaHealth.Flipped:
                    countToDeath++;
                    if (countToDeath == removeForFlipped)
                    {
                        this.NeedsRemoved();
                    }
                    if (!(GoombaSprite is FlippedGoombaSprite))
                    {
                        GoombaSprite = GoombaSpriteFactory.Instance.GetFlippedSprite();

                    }
                    break;
                case GoombaHealth.Stomped:
                    countToDeath++;
                    if (countToDeath == removeForStomped)
                    {
                        this.NeedsRemoved();
                    }
                    if (!(GoombaSprite is StompedGoombaSprite))
                    {
                        GoombaSprite = GoombaSpriteFactory.Instance.GetStompedSprite();
                    }
                    break;
                case GoombaHealth.Normal:
                    if (movingLeft && !(GoombaSprite is LeftMovingGoombaSprite))
                    {
                        GoombaSprite = GoombaSpriteFactory.Instance.GetLeftMovingSprite();
                    } else if (!movingLeft && !(GoombaSprite is RightMovingGoombaSprite))
                    {
                        GoombaSprite = GoombaSpriteFactory.Instance.GetRightMovingSprite();
                    }
                    break;

            }
            GoombaSprite.Update();
        }
    }
}