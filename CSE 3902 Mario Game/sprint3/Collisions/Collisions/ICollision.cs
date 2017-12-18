using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface ICollision
    {
        Rectangle Collision { get; set; }
        IGameObject TopOrLeft { get; set; }
        IGameObject BottomOrRight { get; set; }
    }
}
