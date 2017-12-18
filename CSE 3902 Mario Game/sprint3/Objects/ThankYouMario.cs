using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class ThankYouMario : IObject
    {
        public bool ShouldUpdate { get; set; }
        public bool BeRemoved { get; set; }
        public Texture2D Texture;
        public int Rows;
        public int Columns;
        private int currentFrame;
        public bool isWarpPipe { get; set; }
        public bool isExitPipe { get; set; }
        public Rectangle DestinationRectangle { get; set; }
        public Vector2 Location { get; set; }

        public ThankYouMario(Texture2D texture, int rows, int columns)
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
