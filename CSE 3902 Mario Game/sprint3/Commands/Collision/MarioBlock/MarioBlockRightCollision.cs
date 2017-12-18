using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioBlockRightCollision : ICommand
    {
        private ICollision Side;
        private IMario Mario;
        private IBlock Block;
        private Rectangle Collision;
        public MarioBlockRightCollision(ICollision side)
        {
            Side = side;
            Mario = (IMario)Side.BottomOrRight;
            Block = (IBlock)Side.TopOrLeft;
            Collision = Side.Collision;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (!(Block.State is HiddenBlockState))
            {
                    Mario.SetPosition(new Vector2(Mario.DestinationRectangle.X + Collision.Width,
                            Mario.DestinationRectangle.Y));
            }
        }
    }
}

