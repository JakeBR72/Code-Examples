using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaGoombaTopCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private Goomba Goomba;
        private IKoopa Koopa;

        public KoopaGoombaTopCollision(ICollision side, Game1 game)
        {
            Side = side;
            Koopa = (IKoopa)Side.BottomOrRight;
            Goomba = (Goomba)Side.TopOrLeft;
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
            StackEnemies();
        }
        private void StackEnemies()
        {
            Goomba.Physics.YVelocity = 0;
            Goomba.SetPosition(new Vector2(Goomba.Location.X, Goomba.Location.Y
                - Side.Collision.Height));
        }
    }
}
