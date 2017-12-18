using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BowserStateMachine
    {
        private IEnemySprite bowserSprite;
        public Vector2 Location { get; set; }
        public bool BeRemoved { get; set; } = false;
        public bool FacingLeft { get; set; } = true;
        public bool RefreshSprite { get; set; } = false;
        public bool MouthIsOpen { get; set; } = false;
        public IPhysics Physics { get; set; }
        private Game1 Game;

        public Rectangle DestinationRectangle
        {
            get
            {
                return bowserSprite.DestinationRectangle;
            }
            set
            {
                bowserSprite.DestinationRectangle = value;
            }
        }

        public BowserStateMachine(Vector2 location, Game1 game)
        {
            Location = location;
            bowserSprite = BowserSpriteFactory.Instance.GetLeftFacingSprite(MouthIsOpen);
            Game = game;
        }

        public void SetPosition(Vector2 loc)
        {
            DestinationRectangle = new Rectangle((int)loc.X, (int)loc.Y,
                DestinationRectangle.Width, DestinationRectangle.Height);
            Location = loc;
        }

        public void ChangeDirection()
        {
            FacingLeft = !FacingLeft;
            RefreshSprite = true;
        }

        public void OpenMouth()
        {
            MouthIsOpen = true;
            RefreshSprite = true;
        }

        public void BreathFire()
        {
            ICommand bf = new BowserFireCommand(Location, Game);
            bf.Execute();
        }

        public void CloseMouth()
        {
            MouthIsOpen = false;
            RefreshSprite = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade)
        {
            Location = location;
            bowserSprite.Draw(spriteBatch, Location, shade);
        }

        public void Update()
        {
            Physics.UpdatePosition();

            if (RefreshSprite)
            {
                if (FacingLeft)
                    bowserSprite = BowserSpriteFactory.Instance.GetLeftFacingSprite(MouthIsOpen);
                else
                    bowserSprite = BowserSpriteFactory.Instance.GetRightFacingSprite(MouthIsOpen);

                RefreshSprite = false;
            }

            bowserSprite.Update();
        }
    }
}
