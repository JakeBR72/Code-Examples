using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class ItemBlockCollisionHandler : ICollisionHandler
    {
        private ICollision Side;
        public ItemBlockCollisionHandler(ICollision side)
        {
            Side = side;
        }
        public void handleCollision()
        {
            ICommand command;
            if (Side is Top)
            {
                command = new ItemBlockTopCollision(Side);
                command.Execute();
            }
            else if (Side is Left)
            {
                if (Side.TopOrLeft.DestinationRectangle.Bottom < Side.BottomOrRight.DestinationRectangle.Center.Y)
                {
                    command = new ItemBlockTopCollision(Side);
                    command.Execute();
                }
                else
                {
                    command = new ItemBlockLeftCollision(Side);
                    command.Execute();
                }
            }
            else if (Side is Right)
            {
                if (Side.BottomOrRight.DestinationRectangle.Bottom < Side.TopOrLeft.DestinationRectangle.Center.Y)
                {
                    IGameObject temp = Side.BottomOrRight;
                    Side.BottomOrRight = Side.TopOrLeft;
                    Side.TopOrLeft = temp;
                    command = new ItemBlockTopCollision(Side);
                    command.Execute();
                }
                else
                {
                    command = new ItemBlockRightCollision(Side);
                    command.Execute();
                }
            }
            else if (Side is Bottom)
            {
                command = new ItemBlockBottomCollision(Side);
                command.Execute();
            }
        }
    }
}
