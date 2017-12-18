using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class MarioInvisibleSprite : IMarioSprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle DestinationRectangle { get; set; }
        private int Columns;

        public Color Shade { get; set; }

        public MarioInvisibleSprite(Texture2D texture, int columns)
        {
            Shade = Color.White;
            Texture = texture;
            Columns = columns;
        }

        public void Update(GameTime gameTime)
        {

        }
        public Rectangle Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int Width = 16;
            int Height = 16;
            Rectangle SourceRectangle;

            SourceRectangle = new Rectangle(Width * Columns, 0, Width, Height);
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Shade);
            spriteBatch.End();
            return DestinationRectangle;
        }
    }
}
