using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarioGame
{
    public class MarioObjectTopCollision : ICommand
    {
        Game1 Game;
        private ICollision Side;
        private IMario Mario;
        private IObject pipe;
        private Rectangle Collision;

        public MarioObjectTopCollision(ICollision side, Game1 game)
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
            Game = game;
        }
        public void Execute()
        {
            if (Mario.Physics.YVelocity < 0)
            {
                return;
            }
            Mario.SetPosition(new Vector2(Mario.DestinationRectangle.X, Mario.DestinationRectangle.Y - Collision.Height));
            Mario.Physics.YVelocity = 0;
            if (!Mario.Physics.IsMovingX() || Mario.State() != MarioStateMachine.MarioState.Running)
            {
                Mario.Idle();
            }
            Mario.CanJump = true;

            if (pipe.isWarpPipe && !(pipe is leftPipe))
            {
                Mario.marioCanTransition = true;
                Mario.marioCanTransitionLeftPipe = false;
            }
            else
            {
                Mario.marioCanTransition = false;
                Mario.marioCanTransitionLeftPipe = false;
            }

            Game.st.EndJumpingCombo();
        }
    }
}
