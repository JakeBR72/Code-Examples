using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class ObjectPipeCollisionHandler : ICollisionHandler
    {
        private ICollision Side;
        public ObjectPipeCollisionHandler(ICollision side)
        {
            Side = side;
        }
        public void handleCollision()
        {
            ICommand Command;
            Command = new ObjectPipeCollision(Side);
            Command.Execute();
        }
    }
}
