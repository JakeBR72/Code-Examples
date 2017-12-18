using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class ObjectBlockCollisionHandler : ICollisionHandler
    {
        private ICollision Side;
        public ObjectBlockCollisionHandler(ICollision side)
        {
            Side = side;
        }
        public void handleCollision()
        {
            ICommand Command;
            Command = new ObjectBlockCollision(Side);
            Command.Execute();
        }
    }
}
