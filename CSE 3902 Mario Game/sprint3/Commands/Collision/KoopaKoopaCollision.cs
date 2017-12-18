using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class KoopaKoopaCollision: ICommand
    {
        private Game1 Game;
        private ICollision side;
        private IKoopa koopaOne;
        private IKoopa koopaTwo;
        private Rectangle collision;

        public KoopaKoopaCollision(ICollision  side, Game1 game)
        {
            this.koopaOne = (IKoopa)side.TopOrLeft;
            this.koopaTwo = (IKoopa)side.BottomOrRight;
            this. side = side;
            this.collision = side.Collision;
            Game = game;
        }
        public void Execute()
        {
            if (!checkForDeadKoopa())
            {
                if ( side is Left ||  side is Right)
                {
                    MoveKoopas();
                    koopaOne.ChangeDirection();
                    koopaTwo.ChangeDirection();
                }
                else
                {
                    StackKoopas();
                }
            }   
        }

        private bool checkForDeadKoopa()
        {
            if (deadlyShell(koopaOne) && !deadlyShell(koopaTwo))
            {
                koopaTwo.KillKoopa();
                Game.st.KoopaStomp();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.KoopaStomp, koopaTwo.Location);
                return true;
            }else if(deadlyShell(koopaTwo) && !deadlyShell(koopaOne))
            {
                koopaOne.KillKoopa();
                Game.st.KoopaStomp();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.KoopaStomp, koopaOne.Location);
                return true;
            }
            return false;
        }

        static private bool deadlyShell(IKoopa koopa)
        {
            return koopa.Health == KoopaStateMachine.KoopaHealth.Shelled && koopa.Physics.IsMovingX();
        }
        private void MoveKoopas()
        {
            koopaOne.SetPosition(new Vector2(koopaOne.Location.X - side.Collision.Width / 2,
                koopaOne.Location.Y));
            koopaTwo.SetPosition(new Vector2(koopaTwo.Location.X + side.Collision.Width / 2,
                koopaTwo.Location.Y));
        }
        private void StackKoopas()
        {
            koopaOne.Physics.YVelocity = 0;
            koopaOne.SetPosition(new Vector2(koopaOne.Location.X, koopaOne.Location.Y
                -  collision.Height));
        }
    }
}