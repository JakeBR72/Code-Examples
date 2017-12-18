using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class ObjectPhysics : IPhysics
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
        public ObjectPhysics(IObject obj)
        {
            Object = obj;
            GravityCoef = 0;
            MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, PhysicsUtilites.YMaxPosition);
            MinPosition = new Vector2(PhysicsUtilites.XMinPosition, PhysicsUtilites.YMinPosition);
            XMaxVelocity = 0;
            YMaxVelocity = 0;
            XMinVelocity = 0;
            YMinVelocity = 0;
            XVelocity = 0;
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
            PhysicsUtilites.ClampVelocity((IPhysics)this);
            double xPos = Object.DestinationRectangle.Location.X;
            double yPos = Object.DestinationRectangle.Location.Y;
            xPos += Math.Round(XVelocity);
            yPos += Math.Round(YVelocity);
            Vector2 pos = PhysicsUtilites.ClampPosition(xPos, yPos, (IPhysics)this);
            Object.Location = pos;
            Object.DestinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, Object.DestinationRectangle.Width, Object.DestinationRectangle.Height);
            YVelocity += GravityCoef;
        }
    }
}
