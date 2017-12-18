using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface ICamera : IGameObject
    {
        Matrix GetViewMatrix();
        void Update(IGameObject target);
    }
}
