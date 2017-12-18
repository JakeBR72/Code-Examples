using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioIdleCommand : ICommand
    {
        private Game1 Game;

        public MarioIdleCommand(Game1 s2)
        {
            this.Game = s2;
        }

        public void Execute()
        {
            Game.Mario.Idle();
        }
    }
}
