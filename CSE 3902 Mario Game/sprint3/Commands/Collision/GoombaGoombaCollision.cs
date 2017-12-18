using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class GoombaGoombaCollision: ICommand
    {
        private ICollision side;
        private Goomba goombaOne;
        private Goomba goombaTwo;
        public GoombaGoombaCollision(ICollision Side)
        {
            this.goombaOne = (Goomba) Side.TopOrLeft;
            this.goombaTwo = (Goomba)Side.BottomOrRight;
            this.side = Side;
        }
        public void Execute()
        {
            if (goombaOne.Health == GoombaStateMachine.GoombaHealth.Normal &&
                goombaTwo.Health == GoombaStateMachine.GoombaHealth.Normal)
            {
                if (side is Left || side is Right)
                {
                    MoveGoombas();
                    goombaOne.ChangeDirection();
                    goombaTwo.ChangeDirection();
                }
                else
                {
                    StackGoombas();
                }
            }
            
        }

        private void MoveGoombas()
        {
            goombaOne.SetPosition(new Vector2(goombaOne.Location.X - side.Collision.Width / 2,
                goombaTwo.Location.Y));
            goombaTwo.SetPosition(new Vector2(goombaTwo.Location.X + side.Collision.Width / 2,
                goombaTwo.Location.Y));      
        }
        private void StackGoombas()
        {
            goombaOne.Physics.YVelocity = 0;
            goombaOne.SetPosition(new Vector2(goombaOne.Location.X, goombaOne.Location.Y
                - side.Collision.Height));
        }
    }
}