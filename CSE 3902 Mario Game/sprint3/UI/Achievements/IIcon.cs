using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public interface IIcon
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void Update();
        Rectangle DestinationRectangle { get; set; }
        Vector2 Location { get; set; }
    }
}
