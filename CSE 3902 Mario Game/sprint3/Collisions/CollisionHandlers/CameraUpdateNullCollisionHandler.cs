using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class CameraUpdateNullCollisionHandler : ICollisionHandler
    {
        private ICollision Side;
        public CameraUpdateNullCollisionHandler(ICollision side)
        {
            Side = side;
        }
        public void handleCollision()
        {
            if (Side is Top || Side is Left)
            {
                Side.BottomOrRight.ShouldUpdate = false;
            }
            else if (Side is Right || Side is Bottom)
            {
                Side.TopOrLeft.ShouldUpdate = false;
            }
        }
    }
}
