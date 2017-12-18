﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class Bottom : ICollision
    {
        public Rectangle Collision { get; set; }
        public IGameObject TopOrLeft { get; set; }
        public IGameObject BottomOrRight { get; set; }
        public Bottom(Rectangle collision)
        {
            Collision = collision;
        }
    }
}
