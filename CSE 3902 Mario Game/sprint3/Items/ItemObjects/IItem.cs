using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IItem : IGameObject
    {
        Vector2 Location { get; set; }
        IPhysics Physics { get; set; }
        bool IsCollidable { get; set; }
        bool BeRemoved { get; set; }
        void GetProduced(bool marioFacingLeft);
        void DontDraw();
        void draw(SpriteBatch spriteBatch, Vector2 location);
        void update();
    }
}
