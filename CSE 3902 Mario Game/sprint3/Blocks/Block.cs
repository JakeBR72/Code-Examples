using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class Block : IBlock
    {
        public bool ShouldUpdate { get; set; }
        public bool BeRemoved { get; set; }
        public Color Color { get; set; }
        public Vector2 Location { get; set; }
        public IBlockState State { get; set; }
        public IPhysics Physics { get; set; }
        public Rectangle DestinationRectangle
        {
          get { return Sprite.DestinationRectangle; }
          set { Sprite.DestinationRectangle = value; }
        }
        private IBlockSprite Sprite;
        public Block(Vector2 location, IBlockState initState)
        {
            Location = location;
            State = initState;
            State.SetBlock(this);
            setSpriteFromState();
            Physics = new BlockPhysics(this);
            BeRemoved = false;
        }
        public bool Breakable()
        {
            return State.Breakable();
        }
        public void draw(SpriteBatch spriteBatch, Vector2 location,Color color)
        {
            Location = location;
            Sprite.draw(spriteBatch, location, color);
            Color = color;
        }

        public void setSpriteFromState()
        {
            Sprite = State.GetSprite();
        }

        public void update()
        {
            if (ShouldUpdate)
            {
                Sprite.update();
                Physics.UpdatePosition();
                State.Update();
            }
        }

        public void StoreItem(IItem item)
        {
            State.StoreItem(item);
        }

        public void UseBlock(bool marioFacingLeft)
        {
            State.UseBlock(marioFacingLeft);
        }

        public void ProduceItem(bool marioFacingLeft)
        {
            State.ProduceItem(marioFacingLeft);
        }
    }
}
