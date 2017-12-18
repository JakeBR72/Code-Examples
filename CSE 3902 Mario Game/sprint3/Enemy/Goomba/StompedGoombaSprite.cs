
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class StompedGoombaSprite : IGoombaSprite
    {
        Texture2D baseImage;

        private int stompedHeightLost = 8;
        public Rectangle DestinationRectangle {get; set;}
        public StompedGoombaSprite(Texture2D texture)
        {
            baseImage = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade)
        {
            int Width = baseImage.Width;
            int Height = baseImage.Height;
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y + stompedHeightLost, Width, Height);
                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(baseImage, DestinationRectangle, shade);
            spriteBatch.End();
        }

        public void Update()
        {

        }


    }
}