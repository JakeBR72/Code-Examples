using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class Left : ICollision
    {
        public Rectangle Collision { get; set; }
        public IGameObject TopOrLeft { get; set; }
        public IGameObject BottomOrRight { get; set; }
        public Left(Rectangle collision)
        {
            Collision = collision;
        }
    }
}
