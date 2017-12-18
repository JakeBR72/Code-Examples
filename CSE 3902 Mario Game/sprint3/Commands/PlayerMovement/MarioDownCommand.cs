using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioDownCommand : ICommand
    {
        private Game1 Game;
        private MarioStateMachine.MarioState CurrentState = new MarioStateMachine.MarioState();

        public MarioDownCommand(Game1 s2)
        {
            this.Game = s2;
        }

        public void Execute()
        {
            CurrentState = Game.Mario.State();
            if(Game.Mario.Health() == MarioStateMachine.MarioHealth.Dead)
            {
                return;
            }
            if (CurrentState == MarioStateMachine.MarioState.Jumping)
            {
                Game.Mario.Idle();
            }
            else
            {
                Game.Mario.Duck();
            }
        }
    }
}
