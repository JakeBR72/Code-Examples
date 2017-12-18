using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class GlobalGravityIncrease : ICommand
    {
        private Game1 Game;
        public GlobalGravityIncrease(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            if (Game.DebugMode)
            {
                Game.Mario.Physics.GravityCoef *= PhysicsUtilites.GlobalGravityIncStep;
                Game.Mario.Physics.GravityCoef = MathHelper.Clamp((float)Game.Mario.Physics.GravityCoef, (float)PhysicsUtilites.PlayerMinGravity, (float)PhysicsUtilites.PlayerMaxGravity);
                foreach (Goomba goomba in Game.goombaList)
                {
                    goomba.Physics.GravityCoef *= PhysicsUtilites.GlobalGravityIncStep;
                    goomba.Physics.GravityCoef = MathHelper.Clamp((float)goomba.Physics.GravityCoef, (float)PhysicsUtilites.GlobalMinGravity, (float)PhysicsUtilites.GlobalMaxGravity);
                }
                foreach (IKoopa koopa in Game.koopaList)
                {
                    koopa.Physics.GravityCoef *= PhysicsUtilites.GlobalGravityIncStep;
                    koopa.Physics.GravityCoef = MathHelper.Clamp((float)koopa.Physics.GravityCoef, (float)PhysicsUtilites.GlobalMinGravity, (float)PhysicsUtilites.GlobalMaxGravity);
                }
            }
        }
    }
}
