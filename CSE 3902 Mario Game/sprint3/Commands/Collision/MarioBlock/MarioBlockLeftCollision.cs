using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioBlockLeftCollision : ICommand
    {
        private ICollision Side;
        private IMario Mario;
        private IBlock Block;
        private Rectangle Collision;
        public MarioBlockLeftCollision(ICollision side)
        {
            Side = side;
            Mario = (IMario)Side.TopOrLeft;
            Block = (IBlock)Side.BottomOrRight;
            Collision = Side.Collision;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (!(Block.State is HiddenBlockState))
            {
                    Mario.SetPosition(new Vector2(Mario.DestinationRectangle.X - Collision.Width,
                            Mario.DestinationRectangle.Y));
            }
        }
    }
}
