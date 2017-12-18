using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public interface IBlockSprite
    {
        Rectangle DestinationRectangle { get; set; }
        void draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void update();
    }
}
