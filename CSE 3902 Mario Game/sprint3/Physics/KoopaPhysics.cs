using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaPhysics : IPhysics
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
        private IKoopa Koopa;
        public KoopaPhysics(IKoopa koopa)
        {
            Koopa = koopa;
            GravityCoef = PhysicsUtilites.GlobalGravityCoef;
            MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, PhysicsUtilites.YMaxPosition);
            MinPosition = new Vector2(PhysicsUtilites.XMinPosition, PhysicsUtilites.YMinPosition);
            XMaxVelocity = PhysicsUtilites.KoopaMaxVelocityX;
            YMaxVelocity = PhysicsUtilites.KoopaMaxVelocityY;
            XMinVelocity = PhysicsUtilites.KoopaMinVelocityX;
            YMinVelocity = PhysicsUtilites.KoopaMinVelocityY;
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
                Koopa.ChangeDirection();
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
            if (YVelocity > PhysicsUtilites.GlobalGravityCoef*3
                && Koopa is RedKoopa
                && Koopa.Health == KoopaStateMachine.KoopaHealth.Normal)
            {
                YVelocity = 0;
                float x = (float)(.6 * (XVelocity / XVelocity)) + Koopa.Location.X;
                Koopa.SetPosition(new Vector2(x, Koopa.Location.Y));
                Koopa.ChangeDirection();
            }
            PhysicsUtilites.ClampVelocity((IPhysics)this);
            double xPos = (int)Koopa.Location.X;
            double yPos = (int)Koopa.Location.Y;
            xPos += Math.Round(XVelocity);
            yPos += Math.Round(YVelocity);
            Vector2 pos = ClampPosition(xPos, yPos);
            Koopa.Location = pos;
            Koopa.DestinationRectangle = new Rectangle((int)pos.X, (int)pos.Y,
                Koopa.DestinationRectangle.Width, Koopa.DestinationRectangle.Height);
            XVelocity = XVelocity;
            YVelocity += GravityCoef;
        }
    }
}
