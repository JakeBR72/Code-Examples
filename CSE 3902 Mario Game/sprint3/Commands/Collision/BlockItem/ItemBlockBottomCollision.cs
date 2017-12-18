using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class ItemBlockBottomCollision : ICommand
    {
        private ICollision Side;
        private IItem item;
        private Rectangle Collision;

        public ItemBlockBottomCollision(ICollision side)
        {
            Side = side;
            item = (IItem)Side.BottomOrRight;
            Collision = Side.Collision;

        }
        public void Execute()
        {
            if (item is Star)
            {
                item.Physics.YVelocity = item.Physics.YMinVelocity;
            }
            item.Location = new Vector2(item.DestinationRectangle.X, item.DestinationRectangle.Y + Collision.Height);
            item.DestinationRectangle = new Rectangle(item.DestinationRectangle.X, item.DestinationRectangle.Y + Collision.Height,
                item.DestinationRectangle.Width, item.DestinationRectangle.Height);
        }
    }
}
