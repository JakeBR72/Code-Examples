using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioGoombaTopCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private Goomba Goomba;
        private IMario Mario;
        public MarioGoombaTopCollision(ICollision side, Game1 game)
        {
            Game = game;
            Side = side;
            Mario = (IMario)Side.TopOrLeft;
            Goomba = (Goomba)Side.BottomOrRight;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (Mario is StarMario)
            {
                Goomba.BeFlipped();
            }
            else
            {
                Mario.SetPosition(new Vector2(Mario.Location.X, Mario.Location.Y
                  - Side.Collision.Height));
                MarioSoundBoard.Instance.PlayMarioStomp();
                Mario.Physics.YVelocity = PhysicsUtilites.PlayerBumpVelocityY;
                Goomba.BeStomped();
            }

            Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.LowRumble, Game.RumbleHelper.LowRumble, Game.RumbleHelper.QuickRumble);
            Game.st.DefeatGoomba();
            ScoreAssignments sa = new ScoreAssignments();
            Game.UI.DisplayScore(sa.Goomba, Goomba.Location);
        }
    }
}