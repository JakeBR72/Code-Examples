using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IObject : IGameObject
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        Vector2 Location { get; set; }
        bool isWarpPipe { get; set; }
        bool isExitPipe { get; set; }
        bool BeRemoved { get; set; }
    }
}
