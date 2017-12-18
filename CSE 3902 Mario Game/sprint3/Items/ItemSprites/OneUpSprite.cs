﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class OneUpSprite : IItemSprite
    {
        public Rectangle DestinationRectangle { get; set; }
        private Texture2D Texture;
        public OneUpSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void draw(SpriteBatch spriteBatch, Vector2 location)
        {
                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, Texture.Width, Texture.Height);
            spriteBatch.Draw(Texture, location, Color.White);
            spriteBatch.End();
        }

        public void update()
        {
        }
        public int getTextureHeight()
        {
            return Texture.Height;
        }
    }
}