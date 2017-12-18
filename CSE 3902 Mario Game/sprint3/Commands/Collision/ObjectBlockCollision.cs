using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace MarioGame
{
    public class ObjectBlockCollision : ICommand
    {
        private ICollision Side;
        private IObject Object;
        private IBlock block;
        private Rectangle Collision;
        public ObjectBlockCollision(ICollision side)
        {
            Side = side;
            if (Side.BottomOrRight is IObject)
            {
                Object = (IObject)Side.BottomOrRight;
                block = (IBlock)Side.TopOrLeft;
            }
            else
            {
                Object = (IObject)Side.TopOrLeft;
                block =  (IBlock)Side.BottomOrRight;
            }
            Collision = Side.Collision;
        }
        public void Execute()
        {
            
            if (Object is Fireball)
            {
                Fireball fireBall = (Fireball)Object;
                if (Side is Top)
                {
                    //fireBall.physics.YVelocity = 0;
                    fireBall.Location = (new Vector2(fireBall.Location.X, fireBall.Location.Y - Collision.Height));
                    fireBall.physics.YVelocity = fireBall.physics.YMinVelocity;
                    fireBall.fireBallJump++;
                }
                else if ((Side is Left || Side is Right) && !(block.State is FloorBlockState))
                {
                    fireBall.collisionBlock = true;          
                }
                else if ((Side is Left || Side is Right) && block.State is FloorBlockState && fireBall.Location.Y > 192)
                {
                    fireBall.collisionBlock = true;
                }
            }
        }
    }
}
