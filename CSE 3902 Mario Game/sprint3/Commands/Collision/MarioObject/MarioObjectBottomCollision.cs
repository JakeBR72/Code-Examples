using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioObjectBottomCollision : ICommand
    {
        private ICollision Side;
        private IMario Mario;
        private Rectangle Collision;
        public MarioObjectBottomCollision(ICollision side)
        {
            Side = side;
            if (Side.BottomOrRight is IMario)
            {
                Mario = (IMario)Side.BottomOrRight;
            }
            else
            {
                Mario = (IMario)Side.TopOrLeft;
            }
            Collision = Side.Collision;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            Mario.SetPosition(new Vector2(Mario.DestinationRectangle.X,
                    Mario.DestinationRectangle.Y + Collision.Height));
        }
    }
}
