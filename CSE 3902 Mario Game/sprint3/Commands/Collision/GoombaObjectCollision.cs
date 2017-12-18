using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class GoombaObjectCollision : ICommand
    {
        private Game1 Game;
        private ICollision side;
        private Goomba goomba;
        private Rectangle collision;
        public GoombaObjectCollision(Goomba goomba, ICollision side, Game1 game)
        {
            this.goomba = goomba;
            this.side = side;
            collision = side.Collision;
            Game = game;
        }
        public void Execute()
        {
            if (side.TopOrLeft is Fireball)
            {
                Fireball fb = (Fireball)side.TopOrLeft;
                fb.collisionEnemy = true;
                goomba.BeFlipped();
                Game.st.DefeatGoomba();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.Goomba, goomba.Location);
            }
            else if (side.BottomOrRight is Fireball)
            {
                Fireball fb = (Fireball)side.BottomOrRight;
                fb.collisionEnemy = true;
                goomba.BeFlipped();
                Game.st.DefeatGoomba();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.Goomba, goomba.Location);
            }
            else
            {
                goomba.Physics.YVelocity = 0;
                MoveGoomba();
            }
            
        }
        private void MoveGoomba()
        {
            if (collision.Width > collision.Height)
            {
                goomba.SetPosition(goomba.Location = new Vector2(goomba.DestinationRectangle.X,
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