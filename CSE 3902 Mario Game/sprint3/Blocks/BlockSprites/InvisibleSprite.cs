using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class InvisibleSprite : IBlockSprite
    {
        private Texture2D Texture;
        public Rectangle DestinationRectangle { get; set; }
        public InvisibleSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Texture.Width, Texture.Height);
        }

        public void update()
        {
        }
    }
}
