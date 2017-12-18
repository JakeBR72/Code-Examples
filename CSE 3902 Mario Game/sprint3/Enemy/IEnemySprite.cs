using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IEnemySprite
    {

        Rectangle DestinationRectangle { get; set; }

        void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade);

        void Update();
    }
}
