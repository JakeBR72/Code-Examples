using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioObjectLeftCollision : ICommand
    {
        private ICollision Side;
        private IMario Mario;
        private IObject pipe;
        private Rectangle Collision;
        public MarioObjectLeftCollision(ICollision side)
        {
            Side = side;
            if (Side.BottomOrRight is IMario)
            {
                Mario = (IMario)Side.BottomOrRight;
                pipe = (IObject)Side.TopOrLeft;
            }
            else
            {
                Mario = (IMario)Side.TopOrLeft;
                pipe = (IObject)Side.BottomOrRight;
            }
            Collision = Side.Collision;
        }
        public void Execute()
        {
            if (pipe is leftPipe)
            {
                Mario.marioCanTransitionLeftPipe = true;
                Mario.marioCanTransition = false;
            }
            else
            {
                Mario.marioCanTransitionLeftPipe = false;
                Mario.marioCanTransition = false;
            }
            Mario.SetPosition(new Vector2(Mario.DestinationRectangle.X - Collision.Width,
                    Mario.DestinationRectangle.Y));
        }
    }
}
