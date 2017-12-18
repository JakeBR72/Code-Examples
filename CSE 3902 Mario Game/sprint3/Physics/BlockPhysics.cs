using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class BlockPhysics : IPhysics
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
        private IBlock Block;
        public BlockPhysics(IBlock block)
        {
            Block = block;
            GravityCoef = 0;
            MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, block.DestinationRectangle.Y - block.DestinationRectangle.Height / 2);
            MinPosition = new Vector2(PhysicsUtilites.XMinPosition, block.Location.Y);
            XMaxVelocity = PhysicsUtilites.BlockMaxVelocityX;
            YMaxVelocity = PhysicsUtilites.BlockMaxVelocityY;
            XMinVelocity = PhysicsUtilites.BlockMinVelocityX;
            YMinVelocity = PhysicsUtilites.BlockMinVelocityY;
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
            double xPos = Block.DestinationRectangle.Location.X;
            double yPos = Block.DestinationRectangle.Location.Y;
            yPos += Math.Round(YVelocity);
            Vector2 pos = PhysicsUtilites.ClampPosition(xPos, yPos,(IPhysics)this);
            Block.Location = pos;
            Block.DestinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, Block.DestinationRectangle.Width, Block.DestinationRectangle.Height);
            YVelocity += GravityCoef;
        }
    }
}
