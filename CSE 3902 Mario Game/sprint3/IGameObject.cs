using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IGameObject
    {
        bool ShouldUpdate { get; set; }
        Rectangle DestinationRectangle { get; set; }
    }
}
