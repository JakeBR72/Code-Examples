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
    public class BlockExplosionPiece : IObject
    {
        public Rectangle DestinationRectangle { get; set; }

        public bool isExitPipe { get; set; }

        public bool isWarpPipe { get; set; }

        public Vector2 Location { get; set; }

        public bool ShouldUpdate { get; set; }
        public bool BeRemoved { get; set; }
        public IPhysics Physics { get; set; }
        private Texture2D Texture;
        private Color Color;
        public BlockExplosionPiece(Texture2D texture, Vector2 location, Color color)
        {
            Texture = texture;
            Location = location;
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, texture.Width / 2, texture.Height / 2);
            Physics = new ObjectPhysics(this);
            Color = color;
            BeRemoved = false;
        }
        public void ExplodeTopLeft()
        {
            Physics.XMaxVelocity = PhysicsUtilites.BlockExplosionMaxVelocityX;
            Physics.YMaxVelocity = PhysicsUtilites.BlockExplosionMaxVelocityY;
            Physics.XMinVelocity = PhysicsUtilites.BlockExplosionMinVelocityX;
            Physics.YMinVelocity = PhysicsUtilites.BlockExplosionMinVelocityY;
            Physics.XVelocity = PhysicsUtilites.BlockExplosionMinVelocityX;
            Physics.YVelocity = PhysicsUtilites.BlockExplosionMaxVelocityY;
            Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
        }
        public void ExplodeTopRight()
        {
            Physics.XMaxVelocity = PhysicsUtilites.BlockExplosionMaxVelocityX;
            Physics.YMaxVelocity = PhysicsUtilites.BlockExplosionMaxVelocityY;
            Physics.XMinVelocity = PhysicsUtilites.BlockExplosionMinVelocityX;
            Physics.YMinVelocity = PhysicsUtilites.BlockExplosionMinVelocityY;
            Physics.XVelocity = PhysicsUtilites.BlockExplosionMaxVelocityX;
            Physics.YVelocity = PhysicsUtilites.BlockExplosionMaxVelocityY;
            Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
        }
        public void ExplodeBottomLeft()
        {
            Physics.XMaxVelocity = PhysicsUtilites.BlockExplosionMaxVelocityX;
            Physics.YMaxVelocity = PhysicsUtilites.BlockExplosionMaxVelocityY;
            Physics.XMinVelocity = PhysicsUtilites.BlockExplosionMinVelocityX;
            Physics.YMinVelocity = PhysicsUtilites.BlockExplosionMinVelocityY;
            Physics.XVelocity = PhysicsUtilites.BlockExplosionMinVelocityX;
            Physics.YVelocity = PhysicsUtilites.BlockExplosionMaxVelocityY / 2;
            Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
        }
        public void ExplodeBottomRight()
        {
            Physics.XMaxVelocity = PhysicsUtilites.BlockExplosionMaxVelocityX;
            Physics.YMaxVelocity = PhysicsUtilites.BlockExplosionMaxVelocityY;
            Physics.XMinVelocity = PhysicsUtilites.BlockExplosionMinVelocityX;
            Physics.YMinVelocity = PhysicsUtilites.BlockExplosionMinVelocityY;
            Physics.XVelocity = PhysicsUtilites.BlockExplosionMaxVelocityX;
            Physics.YVelocity = PhysicsUtilites.BlockExplosionMaxVelocityY / 2;
            Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Texture.Width / 3, Texture.Height / 3);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(Texture, DestinationRectangle, Color);
            spriteBatch.End();
        }

        public void Update()
        {
            Physics.UpdatePosition();
            if (Location.Y >= Physics.MinPosition.Y)
            {
                BeRemoved = true;
            }
        }
    }
}
