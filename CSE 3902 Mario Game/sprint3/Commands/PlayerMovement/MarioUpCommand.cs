using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioUpCommand : ICommand
    {
        private Game1 Game;
        private MarioStateMachine.MarioState CurrentState = new MarioStateMachine.MarioState();

        public MarioUpCommand(Game1 s2)
        {
            this.Game = s2;
        }

        public void Execute()
        {
            if (Game.Mario.Health() == MarioStateMachine.MarioHealth.Dead)
            {
                return;
            }
            CurrentState = Game.Mario.State();

            if (CurrentState == MarioStateMachine.MarioState.Ducking)
            {
                Game.Mario.Idle();
            }
            else if (Game.Mario.CanJump)
            {
                Game.Mario.Jump();
                Game.Mario.Physics.YVelocity = Game.Mario.Physics.YMaxVelocity;
                Game.Mario.CanJump = false;
            }
        }
    }
}
