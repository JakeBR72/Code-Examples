using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioCoinCollision : ICommand
    {
        private IItem coin;

        public MarioCoinCollision(ICollision side)
        {
            if (side.BottomOrRight is IItem)
            {
                coin = (IItem)side.BottomOrRight;
            }
            else
            {
                coin = (IItem)side.TopOrLeft;
            }
        }
        public void Execute()
        {
            coin.BeRemoved = true;
        }
    }
}
