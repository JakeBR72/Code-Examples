using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioRunCommand : ICommand
    {
        private Game1 Game;
        private MarioStateMachine.MarioState currentState = new MarioStateMachine.MarioState();

        public MarioRunCommand(Game1 s2)
        {
            this.Game = s2;
        }

        public void Execute()
        {
            if (Game.Mario.Health() == MarioStateMachine.MarioHealth.Dead)
            {
                return;
            }
            bool FacingLeft = Game.Mario.FacingLeft();
            currentState = Game.Mario.State();

            if (currentState == MarioStateMachine.MarioState.Running || currentState == MarioStateMachine.MarioState.Jumping)
            {

                if (FacingLeft)
                {
                    Game.Mario.Physics.XVelocity = -PhysicsUtilites.PlayerRunVelocity;
                }
                else
                {
                    Game.Mario.Physics.XVelocity = PhysicsUtilites.PlayerRunVelocity;
                }
            }
        }
    }
}
