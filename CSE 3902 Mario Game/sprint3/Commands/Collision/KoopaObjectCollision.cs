using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class KoopaObjectCollision : ICommand
    {
        private Game1 Game;
        private ICollision side;
        private IKoopa koopa;
        private Rectangle collision;
        public KoopaObjectCollision(IKoopa koopa, ICollision side, Game1 game)
        {
            this.koopa = koopa;
            this.side = side;
            this.collision = side.Collision;
            Game = game;
        }
        public void Execute()
        {
            if (side.TopOrLeft is Fireball)
            {
                Fireball fb = (Fireball)side.TopOrLeft;
                fb.collisionEnemy = true;
                koopa.KillKoopa();
                Game.st.KoopaFire();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.KoopaFire, koopa.Location);
            }
            else if (side.BottomOrRight is Fireball)
            {
                Fireball fb = (Fireball)side.BottomOrRight;
                fb.collisionEnemy = true;
                koopa.KillKoopa();
                Game.st.KoopaFire();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.KoopaFire, koopa.Location);
            }
            koopa.Physics.YVelocity = 0;
            Movekoopa();
        }
        private void Movekoopa()
        {
            if (collision.Width > collision.Height)
            {
                koopa.SetPosition(new Vector2(koopa.DestinationRectangle.X,
                    koopa.DestinationRectangle.Y - collision.Height));
            }else if (collision.Height > collision.Width)
            {
                if (side.BottomOrRight is IKoopa)
                {
                    koopa.SetPosition(koopa.Location = new Vector2(koopa.DestinationRectangle.X +
                      collision.Width, koopa.DestinationRectangle.Y));
                }
                else
                {
                    koopa.SetPosition(new Vector2(koopa.DestinationRectangle.X -
                     collision.Width, koopa.DestinationRectangle.Y));
                }
                koopa.ChangeDirection();
            }

        }
    }
}