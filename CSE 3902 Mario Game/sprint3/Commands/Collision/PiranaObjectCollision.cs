using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class PiranaObjectCollision : ICommand
    {
        private Game1 Game;
        private ICollision side;
        private IPiranaPlant pirana;
        public PiranaObjectCollision(IPiranaPlant pirana, ICollision side, Game1 game)
        {
            this.pirana = pirana;
            this.side = side;
            Game = game;
        }
        public void Execute()
        {
            if (side.TopOrLeft is Fireball)
            {
                Fireball fb = (Fireball)side.TopOrLeft;
                fb.collisionEnemy = true;
                pirana.KillPirana();
                Game.st.DefeatGoomba();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.Pirana, pirana.Location);
            }
            else if (side.BottomOrRight is Fireball)
            {
                Fireball fb = (Fireball)side.BottomOrRight;
                fb.collisionEnemy = true;
                pirana.KillPirana();
                Game.st.DefeatGoomba();
                ScoreAssignments sa = new ScoreAssignments();
                Game.UI.DisplayScore(sa.Pirana, pirana.Location);
            }

        }
    }
}