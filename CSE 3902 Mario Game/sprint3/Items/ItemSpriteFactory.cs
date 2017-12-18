using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class ItemSpriteFactory
    {
        Texture2D coinTexture, fireFlowerTexture, mushroomTexture,
        oneUpTexture, starTexture;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ItemSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            coinTexture = content.Load<Texture2D>("coin");
            fireFlowerTexture = content.Load<Texture2D>("fireFlower");
            mushroomTexture = content.Load<Texture2D>("mushroom");
            oneUpTexture = content.Load<Texture2D>("oneUp");
            starTexture = content.Load<Texture2D>("star");
        }
        public IItemSprite CreateCoin(Vector2 location)
        {
            IItemSprite sprite = new CoinSprite(coinTexture);
            sprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, coinTexture.Width, coinTexture.Height);
            return sprite;
        }
        public IItemSprite CreateFireFlower(Vector2 location)
        {
            IItemSprite sprite = new FireFlowerSprite(fireFlowerTexture);
            sprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, fireFlowerTexture.Width, fireFlowerTexture.Height);
            return sprite;
        }
        public IItemSprite CreateMushroom(Vector2 location)
        {
            IItemSprite sprite = new MushroomSprite(mushroomTexture);
            sprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, mushroomTexture.Width, mushroomTexture.Height);
            return sprite;
        }
        public IItemSprite CreateOneUp(Vector2 location)
        {
            IItemSprite sprite = new OneUpSprite(oneUpTexture);
            sprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, oneUpTexture.Width, oneUpTexture.Height);
            return sprite;
        }
        public IItemSprite CreateStar(Vector2 location)
        {
            IItemSprite sprite = new StarSprite(starTexture, 4);
            sprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, starTexture.Width, starTexture.Height);
            return sprite;
        }
    }
}
