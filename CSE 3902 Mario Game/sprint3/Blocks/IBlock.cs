using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IBlock : IGameObject
    {
        bool BeRemoved { get; set; }
        Vector2 Location { get; set; }
        IBlockState State { get; set; }
        IPhysics Physics { get; set; }
        Color Color { get; set; }
        bool Breakable();
        void draw(SpriteBatch SpriteBatch, Vector2 Location, Color color);
        void update();
        void setSpriteFromState();
        void StoreItem(IItem item);
        void UseBlock(bool marioFacingLeft);
        void ProduceItem(bool marioFacingLeft);
    }
}
