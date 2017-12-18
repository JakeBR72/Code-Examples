using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class PiranaPhysics : IPhysics
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
        private IPiranaPlant PiranaPlant;
        private int timer;
        public PiranaPhysics(IPiranaPlant piranaPlant)
        {
            PiranaPlant = piranaPlant;
            GravityCoef = 0;
            MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, PhysicsUtilites.YMaxPosition);
            MinPosition = new Vector2(PhysicsUtilites.XMinPosition, PhysicsUtilites.YMinPosition);
            XMaxVelocity = 0;
            YMaxVelocity = PhysicsUtilites.PiranaMaxVelocityY;
            XMinVelocity = 0;
            YMinVelocity = PhysicsUtilites.PiranaMinVelocityY;
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
        public Vector2 ClampPosition(double xPos, double yPos)
        {
            if (xPos < MinPosition.X)
            {
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
            double xPos = (int)PiranaPlant.Location.X;
            double yPos = (int)PiranaPlant.Location.Y;
            if (timer == 100)
            {
                YVelocity = YMinVelocity;
            } else if (timer == 125)
            {
                YVelocity = 0;
            } else if (timer == 225)
            {
                YVelocity = YMaxVelocity;
            } else if(timer == 250)
            {
                YVelocity = 0;
                timer = -1;
            }
            timer++;
            yPos += Math.Round(YVelocity);
            Vector2 pos = ClampPosition(xPos, yPos);
            PiranaPlant.Location = pos;
            PiranaPlant.DestinationRectangle = new Rectangle((int)pos.X, (int)pos.Y,
                PiranaPlant.DestinationRectangle.Width, PiranaPlant.DestinationRectangle.Height);
            
        }
    }
}
