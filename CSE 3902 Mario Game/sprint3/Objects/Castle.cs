using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace MarioGame
{
    class Castle : IObject
    {
        public bool ShouldUpdate { get; set; }
        public bool BeRemoved { get; set; }
        public Texture2D Texture;
        public int Rows;
        public int Columns;
        private int currentFrame;
        public bool castleCanUpdate { get; set; } = false;
        public bool isWarpPipe { get; set; }
        public bool isExitPipe { get; set; }
        public Rectangle DestinationRectangle { get; set; }
        public Vector2 Location { get; set; }
        int i = 0;
        int time;
        public Castle(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            BeRemoved = false;
            time = 20;
        }
        public void Update()
        {
            if (castleCanUpdate)
            {
                if(currentFrame >= 4)
                {
                    
                    time = 10;
                }
                if (i > time)
                {
                    currentFrame++;
                    if((currentFrame-1)% 3 == 0)
                    {
                        MarioWorldSoundBoard.Instance.PlayFireworks();
                    }
                    i = 0;
                }
                if (currentFrame == Rows * Columns)
                {
                    currentFrame = 4;
                }
                i++;
            }else
            {
                currentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            Location = location;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}