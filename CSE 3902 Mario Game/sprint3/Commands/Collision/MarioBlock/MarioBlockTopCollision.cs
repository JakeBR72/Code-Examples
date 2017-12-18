using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioBlockTopCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private IMario Mario;
        private IBlock Block;
        private Rectangle Collision;

        public MarioBlockTopCollision(ICollision side, Game1 game)
        {
            Side = side;
            Mario = (IMario)Side.TopOrLeft;
            Block = (IBlock)Side.BottomOrRight;
            Collision = Side.Collision;
            Game = game;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (Mario.Physics.YVelocity < 0)
            {
                return;
            }
            if (!(Block.State is HiddenBlockState))
            {
                Mario.SetPosition(new Vector2(Mario.DestinationRectangle.X, Mario.DestinationRectangle.Y - Collision.Height));
                // create physics method for zeroing velocity?
                Mario.Physics.YVelocity = 0;
                // move to IMario method
                if (!Mario.Physics.IsMovingX() || Mario.State() != MarioStateMachine.MarioState.Running)
                {
                    Mario.Idle();
                }
                Mario.CanJump = true;
            }

            Game.st.EndJumpingCombo();
        }
    }
}

