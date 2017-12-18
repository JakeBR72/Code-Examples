using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class ObjectPipeCollision : ICommand
    {
        private ICollision Side;
        private IObject fire;
        private IObject objects;

        private Rectangle Collision;
        public ObjectPipeCollision(ICollision side)
        {
            Side = side;
            if (Side.BottomOrRight is Fireball)
            {
                fire = (IObject)Side.BottomOrRight;
                objects = (IObject)Side.TopOrLeft;
            }
            else
            {
                fire = (IObject)Side.TopOrLeft;
                objects = (IObject)Side.BottomOrRight;
            }
            Collision = Side.Collision;
        }
        public void Execute()
        {

            if (fire is Fireball && (objects is SmallPipe || objects is MedPipe || objects is TallPipe))
            {
                Fireball fireBall = (Fireball)fire;
                if (Side is Top)
                {
                    //fireBall.physics.YVelocity = 0;
                    fireBall.Location = (new Vector2(fireBall.Location.X, fireBall.Location.Y - Collision.Height));
                    fireBall.physics.YVelocity = fireBall.physics.YMinVelocity;
                    fireBall.fireBallJump++;
                }
                else if (Side is Left || Side is Right)
                {
                    fireBall.Location = (new Vector2(fireBall.Location.X - Collision.Width, fireBall.Location.Y));
                    fireBall.physics.XVelocity = fireBall.physics.XMinVelocity;
                    fireBall.collisionPipe = true;
                }
                else if (Side is Bottom)
                {
                    fireBall.collisionPipe = true;
                }
            }
        }
    }
}
