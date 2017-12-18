using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioDeadSprite : IMarioSprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle DestinationRectangle { get; set; }
        private int Columns;
        
        public Color Shade { get; set; }

        private int CurrentFrame;

        public MarioDeadSprite(Texture2D texture,  int columns, int startFrame)
        {
            Shade = Color.White;
            Texture = texture;
            Columns = columns;
            CurrentFrame = startFrame;
        }

        public void Update(GameTime gameTime)
        {
           
        }
        public Rectangle Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            int Row = (int)((float)CurrentFrame / (float)Columns);
            int Column = CurrentFrame % Columns;
            int Width = 16;
            int Height = 32;
            Rectangle SourceRectangle;
            if (Row == 0)
            {
                Height = 16;
                SourceRectangle = new Rectangle(Width * Column, 0, Width, Height);
                DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            }
            else
            {
                SourceRectangle = new Rectangle(Width * Column, Height * Row - 16, Width, Height);
                DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            }
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Shade);
            spriteBatch.End();
            return DestinationRectangle;
        }
    }
}
