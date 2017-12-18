using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IMarioSprite
    {
        Color Shade { get; set; }
        Rectangle DestinationRectangle { get; set; }
        void Update(GameTime gameTime);
        Rectangle Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
