using Microsoft.Xna.Framework;
using System;

namespace MarioGame
{
    class BowserFirePhysics : IPhysics
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
        private IObject Object;

        public BowserFirePhysics(IObject obj)
        {
            Object = obj;
            GravityCoef = 0;
            MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, PhysicsUtilites.YMaxPosition);
            MinPosition = new Vector2(PhysicsUtilites.XMinPosition, PhysicsUtilites.YMinPosition);
            XMaxVelocity = PhysicsUtilites.BowserFireMaxVelocityX;
            YMaxVelocity = PhysicsUtilites.BowserFireMaxVelocityY;
            XMinVelocity = PhysicsUtilites.BowserFireMinVelocityX;
            YMinVelocity = PhysicsUtilites.BowserFireMinVelocityY;
            XVelocity = PhysicsUtilites.BowserFireMaxVelocityX;
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

        public void UpdatePosition()
        {
            Vector2 Pos = Object.Location;
            Pos += new Vector2((int)Math.Round(XVelocity), (int)Math.Round(YVelocity));
            Object.Location = Pos;
        }
    }
}
