using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class GlobalGravityDecrease : ICommand
    {
        Game1 Game;
        public GlobalGravityDecrease(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            if (Game.DebugMode)
            {
                Game.Mario.Physics.GravityCoef *= PhysicsUtilites.GlobalGravityDecStep;
                Game.Mario.Physics.GravityCoef = MathHelper.Clamp((float)Game.Mario.Physics.GravityCoef, (float)PhysicsUtilites.PlayerMinGravity, (float)PhysicsUtilites.PlayerMaxGravity);
                foreach (Goomba goomba in Game.goombaList)
                {
                    goomba.Physics.GravityCoef *= PhysicsUtilites.GlobalGravityDecStep;
                    goomba.Physics.GravityCoef = MathHelper.Clamp((float)goomba.Physics.GravityCoef, (float)PhysicsUtilites.GlobalMinGravity, (float)PhysicsUtilites.GlobalMaxGravity);
                }
                foreach (IKoopa koopa in Game.koopaList)
                {
                    koopa.Physics.GravityCoef *= PhysicsUtilites.GlobalGravityDecStep;
                    koopa.Physics.GravityCoef = MathHelper.Clamp((float)koopa.Physics.GravityCoef, (float)PhysicsUtilites.GlobalMinGravity, (float)PhysicsUtilites.GlobalMaxGravity);
                }
            }
        }
    }
}
