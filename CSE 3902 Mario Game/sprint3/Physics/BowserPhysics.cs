using Microsoft.Xna.Framework;
using System;

namespace MarioGame
{
    class BowserPhysics : IPhysics
    {
        public double GravityCoef { get; set; }
        public double XMaxVelocity { get; set; }
        public double YMaxVelocity { get; set; }
        public double XMinVelocity { get; set; }
        public double YMinVelocity { get; set; }
        public double XVelocity { get; set; }
        public double YVelocity { get; set; }
        public Vector2 MaxPosition { get; set; }
        public Vector2 MinPosition { get; set; }
        private IBowser Bowser;
        private int timer = 0;
        private int jumpTimer = 0;
        private int delay = 50;
        private int jumpDelay = 170;
        private bool IncrementTimer = true;

        public BowserPhysics(IBowser bowser)
        {
            Bowser = bowser;
            GravityCoef = PhysicsUtilites.BowserGravityCoef;
            MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, PhysicsUtilites.YMaxPosition);
            MinPosition = new Vector2(PhysicsUtilites.XMinPosition, PhysicsUtilites.YMinPosition);
            XMaxVelocity = PhysicsUtilites.BowserMaxVelocityX;
            YMaxVelocity = PhysicsUtilites.BowserMaxVelocityY;
            XMinVelocity = PhysicsUtilites.BowserMinVelocityX;
            YMinVelocity = PhysicsUtilites.BowserMinVelocityY;
            XVelocity = PhysicsUtilites.BowserInitVelocity;
            YVelocity = 0;
        }
        public bool IsMovingX()
        {
            return XVelocity >= PhysicsUtilites.CheckIfMovingBound || XVelocity <= -PhysicsUtilites.CheckIfMovingBound;
        }
        public bool IsMovingY()
        {
            return YVelocity >= PhysicsUtilites.CheckIfMovingBound || YVelocity <= -PhysicsUtilites.CheckIfMovingBound;
        }
        public Vector2 ClampPosition(double xPos, double yPos)
        {
            if (xPos < MinPosition.X)
            {
                Bowser.ChangeDirection();
                xPos = MinPosition.X;
            }
            if (yPos > MinPosition.Y)
            {
                yPos = MinPosition.Y;
            }
            else if (yPos < MaxPosition.Y)
            {
                yPos = MaxPosition.Y;
                YVelocity = 0;
            }
            return new Vector2((float)xPos, (float)yPos);
        }

        public void UpdatePosition()
        {
            PhysicsUtilites.ClampVelocity((IPhysics)this);

            if (IncrementTimer)
                timer++;
            else
                timer--;

            if (timer == delay)
            {
                XVelocity = XMaxVelocity;
                IncrementTimer = false;
            } else if (timer == 0)
            {
                XVelocity = XMinVelocity;
                IncrementTimer = true;
            }

            jumpTimer++;

            if (jumpTimer == jumpDelay)
            {
                YVelocity = YMaxVelocity;
                jumpTimer = 0;
            }

            double xPos = Bowser.Location.X;
            double yPos = Bowser.Location.Y;
            xPos += XVelocity;
            yPos += YVelocity;
            Vector2 pos = ClampPosition(xPos, yPos);
            Bowser.Location = pos;
            Bowser.DestinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, Bowser.DestinationRectangle.Width,
                Bowser.DestinationRectangle.Height);
            YVelocity += GravityCoef;
        }
    }
}
