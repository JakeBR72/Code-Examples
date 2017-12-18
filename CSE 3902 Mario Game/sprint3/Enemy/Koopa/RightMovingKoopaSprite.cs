
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class RightMovingKoopaSprite : IKoopaSprite
    {
        Texture2D baseImage;
        public Rectangle DestinationRectangle { get; set; }

        private int currentFrame = 0;

        private int totalFrames = 2;

        private int delay = 10;

        private int timer = 0;

        public RightMovingKoopaSprite(Texture2D texture)
        {
            baseImage = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade)
        {
            int Width = baseImage.Width / 2;
            int Height = baseImage.Height;
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            Rectangle SourceRectangle = new Rectangle(currentFrame * Width, 0, Width, Height);
                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(baseImage, DestinationRectangle, SourceRectangle, shade);
            spriteBatch.End();
        }

        public void Update()
        {
            timer++;
            if (timer == delay)
            {
                timer = 0;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }

        }
    }
}