using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class ItemBlockRightCollision : ICommand
    {
        private ICollision Side;
        private IItem item;

        public ItemBlockRightCollision(ICollision side)
        {
            Side = side;
            item = (IItem)Side.BottomOrRight;

        }
        public void Execute()
        {
            item.Physics.XVelocity = -(item.Physics.XVelocity);
        }
    }
}
