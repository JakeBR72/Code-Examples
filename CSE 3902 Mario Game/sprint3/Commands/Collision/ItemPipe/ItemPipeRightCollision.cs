using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class ItemPipeRightCollision : ICommand
    {
        private ICollision Side;
        private IItem item;

        public ItemPipeRightCollision(ICollision side)
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
