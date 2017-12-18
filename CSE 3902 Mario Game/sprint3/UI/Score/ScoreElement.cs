using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class ScoreElement
    {
        public int Score;
        public Vector2 Location;
        public int timer;
        public ScoreElement(int score, Vector2 location)
        {
            Score = score;
            Location = location;
            timer = 50;
        }
    }
}
