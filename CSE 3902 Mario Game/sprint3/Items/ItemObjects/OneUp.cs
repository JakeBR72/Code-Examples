using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class OneUp : IItem
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
        private bool goLeftAfterProduced;
        private bool isBeingDrawn;
        private int productionTimer;
        public OneUp(Vector2 location)
        {
            Location = location;
            Physics = new ItemPhysics(this);
            Sprite = ItemSpriteFactory.Instance.CreateOneUp(location);
            IsCollidable = true;
            beingProduced = false;
            isBeingDrawn = true;
            BeRemoved = false;
            productionTimer = 0;
        }
        public void DontDraw()
        {
            isBeingDrawn = false;
        }
        public void GetProduced(bool marioFacingLeft)
        {
            ItemBlockSoundBoard.Instance.PlayPowerUpAppear();
            goLeftAfterProduced = marioFacingLeft;
            beingProduced = true;
            Physics.MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, (int)Location.Y - Sprite.getTextureHeight());
            Physics.YVelocity = PhysicsUtilites.ItemProductionVelocity;
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
                if (beingProduced && productionTimer % 3 == 0)
                {
                    Physics.UpdatePosition();
                    CheckForEndOfBeingProduced();
                }
                else if (!beingProduced)
                {
                    Physics.UpdatePosition();
                }
            }
        }
        private void CheckForEndOfBeingProduced()
        {
            if (Location.Y <= Physics.MaxPosition.Y)
            {
                Physics.YVelocity = 0;
                Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
                IsCollidable = true;
                Physics.MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, PhysicsUtilites.YMaxPosition);
                beingProduced = false;
                if (goLeftAfterProduced)
                {
                    Physics.XVelocity = Physics.XMinVelocity;
                }
                else
                {
                    Physics.XVelocity = Physics.XMaxVelocity;
                }
            }
        }
    }
}
