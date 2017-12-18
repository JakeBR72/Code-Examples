using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class NullItem : IItem
    {
        public bool IsCollidable { get; set; }
        public bool BeRemoved { get; set; }

        public Rectangle DestinationRectangle { get; set; }

        public Vector2 Location { get; set; }

        public IPhysics Physics { get; set; }

        public bool ShouldUpdate { get; set; }
        public NullItem()
        {
            IsCollidable = false;
            DestinationRectangle = new Rectangle();
            Location = new Vector2();
            Physics = new ItemPhysics(this);
            ShouldUpdate = false;
            BeRemoved = false; 
        }
        public void DontDraw()
        {
        }

        public void draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }

        public void GetProduced(bool marioFacingLeft)
        {
        }

        public void update()
        {
        }
    }
}
