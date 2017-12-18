using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IItemSprite
    {
        Rectangle DestinationRectangle { get; set; }
        void draw(SpriteBatch spriteBatch, Vector2 location);
        void update();
        int getTextureHeight();
    }
}
