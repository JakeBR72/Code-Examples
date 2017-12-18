using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class ItemPipeCollisionHandler : ICollisionHandler
    {
        private ICollision Side;
        public ItemPipeCollisionHandler(ICollision side)
        {
            Side = side;
        }
        public void handleCollision()
        {
            ICommand command;
            if (Side is Top)
            {
                command = new ItemPipeTopCollision(Side);
                command.Execute();
            }
            else if (Side is Left)
            {
                if (Side.TopOrLeft.DestinationRectangle.Bottom < Side.BottomOrRight.DestinationRectangle.Center.Y)
                {
                    command = new ItemPipeTopCollision(Side);
                    command.Execute();
                }
                else
                {
                    command = new ItemPipeLeftCollision(Side);
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
                    command = new ItemPipeTopCollision(Side);
                    command.Execute();
                }
                else
                {
                    command = new ItemPipeRightCollision(Side);
                    command.Execute();
                }
            }
        }
    }
}
