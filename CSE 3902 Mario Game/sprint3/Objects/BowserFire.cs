using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class BowserFire : IObject
    {
        public bool ShouldUpdate { get; set; }
        public bool BeRemoved { get; set; }
        public Vector2 Location { get; set; }
        public Texture2D Texture;
        public int Rows;
        public int Columns;
        private int currentFrame;
        public bool isWarpPipe { get; set; }
        public bool isExitPipe { get; set; }
        public IPhysics physics;
        public Rectangle DestinationRectangle { get; set; }

        private int timer = 0;
        private int delay = 10;
        private bool toggleFrame = false;

        public BowserFire(Texture2D texture, int rows, int columns)
        {
            physics = new BowserFirePhysics(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            BeRemoved = false;
        }
        public void Update()
        {
            physics.UpdatePosition();

            if (timer == delay)
            {
                if (toggleFrame)
                {
                    currentFrame = 0;
                    toggleFrame = false;
                }
                else
                {
                    currentFrame = 1;
                    toggleFrame = true;
                }

                timer = 0;
            }

            timer++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            Location = location;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
