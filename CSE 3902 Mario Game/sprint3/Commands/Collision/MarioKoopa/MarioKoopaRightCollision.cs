using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioKoopaRightCollision : ICommand
    {
        Game1 Game;
        private ICollision Side;
        private IMario Mario;
        private IKoopa Koopa;
        public MarioKoopaRightCollision(ICollision side, Game1 game)
        {
            Game = game;
            Side = side;
            Mario = (IMario)Side.BottomOrRight;
            Koopa = (IKoopa)Side.TopOrLeft;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (Mario is StarMario)
            {
                Koopa.KillKoopa();
                Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.LowRumble, Game.RumbleHelper.LowRumble, Game.RumbleHelper.QuickRumble);
            }
            else
            {
                if (Koopa.Health == KoopaStateMachine.KoopaHealth.Shelled)
                {
                    if (!Koopa.Physics.IsMovingX())
                    {
                        MarioSoundBoard.Instance.PlayMarioKick();
                        Koopa.Physics.XVelocity = Koopa.Physics.XMinVelocity;
                        Vector2 loc = Koopa.Location;
                        loc.X -= Side.Collision.Width;
                        Koopa.SetPosition(loc);
                        Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.LowRumble, Game.RumbleHelper.LowRumble, Game.RumbleHelper.QuickRumble);
                    }
                    else
                    {
                        Mario.TakeDamage();
                        Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.MidRumble, Game.RumbleHelper.MidRumble, Game.RumbleHelper.ShortRumble);
                    }
                }
                else
                {
                    Mario.TakeDamage();
                    Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.MidRumble, Game.RumbleHelper.MidRumble, Game.RumbleHelper.ShortRumble);
                }
            }
        }
    }
}
