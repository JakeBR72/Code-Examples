using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class KoopaBlockCollision : ICommand
    {
        private Game1 Game;
        private ICollision side;
        private IKoopa koopa;
        private Rectangle collision;
        private IBlock block;

        public KoopaBlockCollision(IKoopa koopa, ICollision side, Game1 game)
        {
            Game = game;
            this.koopa = koopa;
            this.side = side;
            collision = side.Collision;
            if (side.BottomOrRight is IBlock)
            {
                block = (IBlock)side.BottomOrRight;
            }
            else
            {
                block = (IBlock)side.TopOrLeft;
            }
        }
        public void Execute()
        {
            if (block.State.BumpingBlock)
            {
                koopa.KillKoopa();
                Game.st.KoopaStomp();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.KoopaStomp, koopa.Location);
                return;
            }
            koopa.Physics.YVelocity = 0;
            MoveKoopa();
        }
        private void MoveKoopa()
        {
            if (collision.Width > collision.Height)
            {
                koopa.SetPosition(new Vector2(koopa.DestinationRectangle.X,
                    koopa.DestinationRectangle.Y - collision.Height));
            }else if (collision.Height > collision.Width)
            {
                if (side.BottomOrRight is IKoopa)
                {
                    koopa.SetPosition(new Vector2(koopa.DestinationRectangle.X +
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