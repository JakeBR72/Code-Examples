using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaGoombaRightCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private Goomba Goomba;
        private IKoopa Koopa;
        public KoopaGoombaRightCollision(ICollision side, Game1 game)
        {
            Side = side;
            Koopa = (IKoopa)Side.TopOrLeft;
            Goomba = (Goomba)Side.BottomOrRight;
            Game = game;
        }
        public void Execute()
        {
            if (Koopa.Health == KoopaStateMachine.KoopaHealth.Shelled && Koopa.Physics.IsMovingX())
            {
                Goomba.BeFlipped();
                Game.st.KoopaFire();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.KoopaFire, Goomba.Location);
            }
            else
            {
                MoveEnemies();
                Koopa.ChangeDirection();
                Goomba.ChangeDirection();
            }
        }
        private void MoveEnemies()
        {
            Goomba.SetPosition(new Vector2(Goomba.Location.X + Side.Collision.Width / 2,
               Goomba.Location.Y));
            Koopa.SetPosition(new Vector2(Koopa.Location.X - Side.Collision.Width / 2,
               Koopa.Location.Y));
        }
    }
}
