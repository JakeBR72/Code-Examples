using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class GoombaBlockCollision : ICommand
    {
        private Game1 Game;
        private ICollision side;
        private Goomba goomba;
        private Rectangle collision;
        private IBlock block;

        public GoombaBlockCollision(Goomba goomba, ICollision side, Game1 game)
        {
            Game = game;
            this.goomba = goomba;
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
                goomba.BeFlipped();
                Game.st.DefeatGoomba();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.Goomba, goomba.Location);
                return;
            }
            goomba.Physics.YVelocity = 0;
            MoveGoomba();
        }
        private void MoveGoomba()
        {
            if (collision.Width > collision.Height)
            {
                goomba.SetPosition(new Vector2(goomba.DestinationRectangle.X,
                    goomba.DestinationRectangle.Y - collision.Height));
            }else if (collision.Height > collision.Width)
            {
                if (side.BottomOrRight is Goomba)
                {
                    goomba.SetPosition(new Vector2(goomba.DestinationRectangle.X +
                        collision.Width, goomba.DestinationRectangle.Y));
                }
                else
                {
                    goomba.SetPosition(new Vector2(goomba.DestinationRectangle.X -
                        collision.Width, goomba.DestinationRectangle.Y));
                }
                goomba.ChangeDirection();
            }
        }
    }
}