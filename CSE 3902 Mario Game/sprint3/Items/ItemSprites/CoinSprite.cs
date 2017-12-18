using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class CoinSprite : IItemSprite
    {
        public Rectangle DestinationRectangle { get; set; }
        private Texture2D Texture;
        private int CurrentFrame = 1;
        private int TotalFrame;
        private int Delay = 10;
        private int Timer = 0;
        public CoinSprite(Texture2D texture, int totalFrames = 3)
        {
            Texture = texture;
            TotalFrame = totalFrames;
        }

        public void draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int Width = Texture.Width / TotalFrame;
            int Height = Texture.Height;
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            Rectangle SourceRectangle = new Rectangle(CurrentFrame * Width, 0, Width, Height);
                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void update()
        {
            Timer++;
            if (Timer == Delay)
            {
                Timer = 0;
                CurrentFrame++;
                if (CurrentFrame == TotalFrame)
                {
                    CurrentFrame = 0;
                }
            }
        }
        public int getTextureHeight()
        {
            return Texture.Height;
        }
    }
}
