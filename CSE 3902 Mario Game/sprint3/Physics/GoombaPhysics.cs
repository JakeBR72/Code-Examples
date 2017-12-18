using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class GoombaPhysics : IPhysics
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
        private Goomba Goomba;
        public GoombaPhysics(Goomba goomba)
        {
            Goomba = goomba;
            GravityCoef = PhysicsUtilites.GlobalGravityCoef;
            MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, PhysicsUtilites.YMaxPosition);
            MinPosition = new Vector2(PhysicsUtilites.XMinPosition, PhysicsUtilites.YMinPosition);
            XMaxVelocity = PhysicsUtilites.GoombaMaxVelocityX;
            YMaxVelocity = PhysicsUtilites.GoombaMaxVelocityY;
            XMinVelocity = PhysicsUtilites.GoombaMinVelocityX;
            YMinVelocity = PhysicsUtilites.GoombaMinVelocityY;
            XVelocity = PhysicsUtilites.EnemyInitVelocity;
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
                Goomba.ChangeDirection();
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
            double xPos = (int)Goomba.Location.X;
            double yPos = (int)Goomba.Location.Y;
            xPos += Math.Round(XVelocity);
            yPos += Math.Round(YVelocity);
            Vector2 pos = ClampPosition(xPos, yPos);
            Goomba.Location = pos;
            Goomba.DestinationRectangle = new Rectangle((int)pos.X, (int)pos.Y,
                Goomba.DestinationRectangle.Width, Goomba.DestinationRectangle.Height);
            XVelocity = XVelocity;
            YVelocity += GravityCoef;
        }
    }
}
