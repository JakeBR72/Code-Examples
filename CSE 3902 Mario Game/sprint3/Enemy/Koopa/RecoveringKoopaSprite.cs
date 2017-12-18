
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class RecoveringKoopaSprite : IKoopaSprite
    {
        Texture2D baseImage;
        public Rectangle DestinationRectangle { get; set; }

        public RecoveringKoopaSprite(Texture2D texture)
        {
            baseImage = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color shade)
        {
            int Width = baseImage.Width;
            int Height = baseImage.Height;
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            spriteBatch.Draw(baseImage, DestinationRectangle, shade);
            spriteBatch.End();
        }

        public void Update()
        {

        }


    }
}