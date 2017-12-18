using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace MarioGame
{
    public class Coin : IItem
    {
        public bool ShouldUpdate { get; set; }
        public Vector2 Location { get; set; }
        public IPhysics Physics { get; set; }
        public bool IsCollidable { get; set; }
        public bool BeRemoved { get; set; }
        public Rectangle DestinationRectangle
        {
            get { return Sprite.DestinationRectangle; }
            set { Sprite.DestinationRectangle = value; }
        }
        private IItemSprite Sprite;
        private bool beingProduced;
        private bool isBeingDrawn;
        public Coin(Vector2 location)
        {
            Location = location;
            Physics = new ItemPhysics(this);
            Sprite = ItemSpriteFactory.Instance.CreateCoin(location);
            IsCollidable = true;
            beingProduced = false;
            isBeingDrawn = true;
            BeRemoved = false;
        }
        public void DontDraw()
        {
            isBeingDrawn = false;
        }
        public void GetProduced(bool marioFacingLeft)
        {
            beingProduced = true;
            Physics.MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, (int)Location.Y - Sprite.getTextureHeight()*3);
            Physics.YVelocity = PhysicsUtilites.ItemCoinProductionVelocity;
            isBeingDrawn = true;
        }
        public void draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (isBeingDrawn)
            {
                Location = location;
                Sprite.draw(spriteBatch, location);
            }
        }

        public void update()
        {
            if (ShouldUpdate)
            {
                DestinationRectangle = Sprite.DestinationRectangle;
                Sprite.update();
                Physics.UpdatePosition();
                if (beingProduced)
                {
                    CheckForEndOfBeingProduced();
                }
            }
        }
        private void CheckForEndOfBeingProduced()
        {
            if (Location.Y <= Physics.MaxPosition.Y)
            {
                Physics.YVelocity = 0;
                beingProduced = false;
                BeRemoved = true;
            }
        }
    }
}
