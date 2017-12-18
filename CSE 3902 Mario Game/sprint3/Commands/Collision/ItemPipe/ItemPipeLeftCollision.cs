using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class ItemPipeLeftCollision : ICommand
    {
        private ICollision Side;
        private IItem item;

        public ItemPipeLeftCollision(ICollision side)
        {
            Side = side;
            item = (IItem)Side.TopOrLeft;

        }
        public void Execute()
        {
            item.Physics.XVelocity = -(item.Physics.XVelocity);
        }
    }
}
