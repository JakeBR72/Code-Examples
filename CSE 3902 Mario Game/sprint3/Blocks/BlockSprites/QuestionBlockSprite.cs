using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class QuestionBlockSprite : IBlockSprite
    {
        private Texture2D Texture;
        private int CurrentFrame;
        private int TotalFrame;
        private int Delay;
        private int Timer;
        public Rectangle DestinationRectangle { get; set; }
        public QuestionBlockSprite(Texture2D texture, int totalFrames)
        {
            Texture = texture;
            TotalFrame = totalFrames;
            CurrentFrame = 1;
            Delay = 10;
            Timer = 0;
        }

        public void draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            int Width = Texture.Width / TotalFrame;
            int Height = Texture.Height;
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            Rectangle SourceRectangle = new Rectangle(CurrentFrame * Width, 0, Width, Height);
                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle,color);
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
    }
}
