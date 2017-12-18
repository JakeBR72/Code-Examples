using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class KoopaGoombaBottomCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private Goomba Goomba;
        private IKoopa Koopa;

        public KoopaGoombaBottomCollision(ICollision side, Game1 game)
        {
            Side = side;
            Koopa = (IKoopa)Side.TopOrLeft;
            Goomba = (Goomba)Side.BottomOrRight;
            Game = game;
        }
        public void Execute()
        {
           if(Koopa.Health == KoopaStateMachine.KoopaHealth.Shelled && Koopa.Physics.IsMovingX())
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
            Koopa.Physics.YVelocity = 0;
            Koopa.SetPosition(new Vector2(Koopa.Location.X, Koopa.Location.Y
                - Side.Collision.Height));
        }
    }
}
