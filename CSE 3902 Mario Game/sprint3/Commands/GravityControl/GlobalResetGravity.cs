using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class GlobalResetGravity : ICommand
    {
        Game1 Game;
        public GlobalResetGravity(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            if (Game.DebugMode)
            {
                Game.Mario.Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
                foreach (Goomba goomba in Game.goombaList)
                {
                    goomba.Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
                }
                foreach (IKoopa koopa in Game.koopaList)
                {
                    koopa.Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
                }
            }
        }
    }
}
