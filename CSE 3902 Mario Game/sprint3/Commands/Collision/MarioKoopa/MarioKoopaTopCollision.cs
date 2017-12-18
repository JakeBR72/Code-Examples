using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioKoopaTopCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private IKoopa Koopa;
        private IMario Mario;

        public MarioKoopaTopCollision(ICollision side, Game1 game)
        {
            Side = side;
            Mario = (IMario)Side.TopOrLeft;
            Koopa = (IKoopa)Side.BottomOrRight;
            Game = game;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (Mario is StarMario)
            {
                Koopa.KillKoopa();
            }
            else
            {
                if (!Koopa.Physics.IsMovingX() && Koopa.Health == KoopaStateMachine.KoopaHealth.Shelled)
                {
                    MarioSoundBoard.Instance.PlayMarioKick();
                    Koopa.Physics.XVelocity = Koopa.Physics.XMinVelocity;
                } else
                {
                    Koopa.BeShelled();
                    MarioSoundBoard.Instance.PlayMarioStomp();
                }
                Mario.SetPosition(new Vector2(Mario.Location.X, Mario.Location.Y
                    - Side.Collision.Height));
                Mario.Physics.YVelocity = PhysicsUtilites.PlayerBumpVelocityY;
            }

            Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.LowRumble, Game.RumbleHelper.LowRumble, Game.RumbleHelper.QuickRumble);
            Game.st.KoopaStomp();
            ScoreAssignments sa = new ScoreAssignments();
            Game.UI.DisplayScore(sa.KoopaStomp, Koopa.Location);
        }
    }
}
