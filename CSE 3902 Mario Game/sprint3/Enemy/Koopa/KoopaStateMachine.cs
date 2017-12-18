
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class KoopaStateMachine
    {
        private int countToDeath = -1;
        private int removeForFlipped = 200;
        private IEnemySprite koopaSprite;
        
        public Vector2 Location { get; set; }
        public bool BeRemoved { get; set; } = false;
        public bool ShouldCollide { get; set; } = true;

        public IPhysics Physics { get; set; }
        public Rectangle DestinationRectangle
        {
            get
            {
                return koopaSprite.DestinationRectangle;
            }
            set
            {
                koopaSprite.DestinationRectangle = value;
            }
        }

        public bool MovingLeft { get; set; } = true;

        public enum KoopaHealth { Normal, Flipped, Shelled, Recovering };

        public KoopaHealth Health { get; set;} = KoopaHealth.Normal;

        public KoopaStateMachine(Vector2 location)
        {
            Location = location;
            koopaSprite = KoopaSpriteFactory.Instance.GetLeftMovingSprite();
        }

        public void BeginRecover()
        {
            if (Health != KoopaHealth.Recovering)
            {
                Health = KoopaHealth.Recovering;
            }
        }
        public void BeShelled()
        {
            Physics.XVelocity = 0.0;
            Physics.YVelocity = 0.0;
            if (Health != KoopaHealth.Shelled)
            {

                Health = KoopaHealth.Shelled;
            }
        }
        public void ChangeDirection()
        {
            Physics.XVelocity *= -1;
            MovingLeft = !MovingLeft;
        }
        public void FullyRecover()
        {
            if (Health != KoopaHealth.Normal)
            {
                Physics.XVelocity = PhysicsUtilites.EnemyInitVelocity;
                if (!MovingLeft)
                {
                    Physics.XVelocity = Physics.XVelocity * -1;
                }
                Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
                Health = KoopaHealth.Normal;
            }
        }

        public void KillKoopa()
        {
            ShouldCollide = false;//now that there is a flipped state this can be removed.
            MarioSoundBoard.Instance.PlayMarioKick();
            Health = KoopaHealth.Flipped;
            countToDeath = 0;
            Physics.YVelocity = Physics.YMaxVelocity;
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
            koopaSprite.Draw(spriteBatch, Location, shade);
        }
        public void Update()
        {
            Physics.UpdatePosition();
            if(countToDeath >= 0)
            {
                countToDeath++;
            }
            if (countToDeath == removeForFlipped)
            {
                BeRemoved = true;
            }
            switch (Health)
            {
                case KoopaHealth.Shelled:
                    
                    if (!(koopaSprite is ShelledKoopaSprite))
                    {
                        koopaSprite = KoopaSpriteFactory.Instance.GetShelledSprite();
                    }
                    break;
                case KoopaHealth.Recovering:
                    if ( !(koopaSprite is RecoveringKoopaSprite))
                    {
                        koopaSprite = KoopaSpriteFactory.Instance.GetRecoveringSprite();
                    }
                    break;
                case KoopaHealth.Normal:
                    if (MovingLeft && !(koopaSprite is LeftMovingKoopaSprite))
                    {
                        koopaSprite = KoopaSpriteFactory.Instance.GetLeftMovingSprite();
                    }
                    else if (!MovingLeft && !(koopaSprite is RightMovingKoopaSprite))
                    {
                        koopaSprite = KoopaSpriteFactory.Instance.GetRightMovingSprite();
                    }
                    break;
                case KoopaHealth.Flipped:
                    if(!(koopaSprite is FlippedKoopaSprite))
                    {
                        koopaSprite = KoopaSpriteFactory.Instance.GetFlippedSprite();
                    }
                    break;
            }
            koopaSprite.Update();
        }
    }
}