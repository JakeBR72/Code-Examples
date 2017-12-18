using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public interface IPiranaPlant : IGameObject
    {
        bool BeRemoved { get; set; }
        void Draw(SpriteBatch spriteBatch, Vector2 Location, Color shade);
        void Update();
        void SetPosition(Vector2 location);
        void KillPirana();
        Vector2 Location { get; set; }
        IPhysics Physics { get; set; }
    }
}
