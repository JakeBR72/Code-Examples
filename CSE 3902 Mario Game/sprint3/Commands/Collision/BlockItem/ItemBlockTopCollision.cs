using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame 
{
    public class ItemBlockTopCollision : ICommand
    {
        private IItem item;
        private IBlock block;
        private Rectangle Collision;

        public ItemBlockTopCollision(ICollision side)
        {

            item = (IItem)side.TopOrLeft;
            block = (IBlock)side.BottomOrRight;
            Collision = side.Collision;

        }
        public void Execute()
        {
            if( item is Star || block.State.BumpingBlock)
            {
                item.Physics.YVelocity = item.Physics.YMaxVelocity;
            }
            item.Location = new Vector2(item.DestinationRectangle.X, item.DestinationRectangle.Y - Collision.Height);
            item.DestinationRectangle = new Rectangle(item.DestinationRectangle.X, item.DestinationRectangle.Y - Collision.Height,
                item.DestinationRectangle.Width, item.DestinationRectangle.Height);
        }
    } 
}
