using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class BowserSpriteFactory
    {
        private Texture2D Bowser;

        private static BowserSpriteFactory instance = new BowserSpriteFactory();

        public static BowserSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BowserSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            Bowser = content.Load<Texture2D>("bowser");
        }

        public IEnemySprite GetLeftFacingSprite(bool mouthIsOpen)
        {
            return new BowserSprite(Bowser, true, mouthIsOpen); //True for facingleft, false for mouthOpen
        }

        public IEnemySprite GetRightFacingSprite(bool mouthIsOpen)
        {
            return new BowserSprite(Bowser, false, mouthIsOpen);
        }
    }
}
