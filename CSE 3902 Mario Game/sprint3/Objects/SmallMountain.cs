using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class SmallMountain : IObject
    {
        public bool ShouldUpdate { get; set; }
        public bool BeRemoved { get; set; }
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        public bool isWarpPipe { get; set; }
        public bool isExitPipe { get; set; }
        public Rectangle DestinationRectangle { get; set; }
        public Vector2 Location { get; set; }
        public SmallMountain(Texture2D texture,int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            BeRemoved = false;
        }
        public void Update()
        {
 
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