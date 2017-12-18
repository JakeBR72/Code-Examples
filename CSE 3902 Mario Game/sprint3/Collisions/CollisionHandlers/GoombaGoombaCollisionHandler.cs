using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class GoombaGoombaCollisionHandler : ICollisionHandler
    {
        private ICollision Side;
        public GoombaGoombaCollisionHandler(ICollision side)
        {
            Side = side;
        }

        public void handleCollision()
        {
            ICommand Command;
            Command = new GoombaGoombaCollision(Side);
            Command.Execute();
            
        }
    }
}
