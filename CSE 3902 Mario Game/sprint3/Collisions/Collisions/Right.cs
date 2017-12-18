using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class Right : ICollision
    {
        public Rectangle Collision { get; set; }
        public IGameObject TopOrLeft { get; set; }
        public IGameObject BottomOrRight { get; set; }
        public Right(Rectangle collision)
        {
            Collision = collision;
        }
    }
}
