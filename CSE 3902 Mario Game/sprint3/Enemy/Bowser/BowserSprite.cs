using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class BowserSprite : IEnemySprite
    {
        Texture2D baseImage;
        public Rectangle DestinationRectangle { get; set; }
        public bool isFacingLeft { get; set; }
        public bool mouthIsOpen { get; set; }
        private int row = 0;
        private int openMouthFrame = 1;    //Mouth is open on frames 0 and 1
        private int closeMouthFrame = 2;    //Mouth is closed on frames 2 and 3
        private int startFrame;
        private int currentFrame = 0;
        private int totalFrames;
        private int openMouthFrames = 2;
        private int closedMouthFrames = 4;

        private int delay = 30;
        private int timer = 0;
        private int totalCycles = 0;

        public BowserSprite(Texture2D texture, bool facingLeft, bool mouthOpen)
        {
            baseImage = texture;
            isFacingLeft = facingLeft;
            mouthIsOpen = mouthOpen;

            if (!mouthIsOpen)
            {
                startFrame = closeMouthFrame;
                totalFrames = closedMouthFrames;
            } else
            {
                startFrame = openMouthFrame;
                totalFrames = openMouthFrames;
            }

            currentFrame = startFrame;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            int Width = baseImage.Width / 4;
            int Height = baseImage.Height / 2;

            if (!isFacingLeft)
                row = Height;
            else
                row = 0;

            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            Rectangle SourceRectangle = new Rectangle(currentFrame * Width, row, Width, Height);  //set second parameter to 0 for left facing, 'height' for right facing
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(baseImage, DestinationRectangle, SourceRectangle, color);
            spriteBatch.End();
        }

        public void Update()
        {
            timer++;
            if (timer == delay)
            {
                timer = 0;
                currentFrame++;
                totalCycles++;

                if (currentFrame == totalFrames)
                {
                    currentFrame = startFrame;
                }

                if (mouthIsOpen)
                {
                    currentFrame = openMouthFrame;
                    totalCycles = 0;
                    totalFrames = openMouthFrames;
                }
            }
        }
    }
}
