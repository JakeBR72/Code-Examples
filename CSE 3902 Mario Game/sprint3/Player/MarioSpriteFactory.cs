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
    class MarioSpriteFactory
    {
        private Texture2D MarioSpriteSheet { get; set; }

        private static MarioSpriteFactory instance = new MarioSpriteFactory();

        public static MarioSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioSpriteFactory()
        {            
        }

        public void LoadAllTextures(ContentManager content)
        {
            MarioSpriteSheet = content.Load<Texture2D>("mario");
        }

        public IMarioSprite GetIdleSprite(MarioStateMachine.MarioSize size, bool facingLeft)
        { 
            return new MarioIdleSprite(MarioSpriteSheet,  16, 7, facingLeft, size);
        }
        public IMarioSprite GetRunningSprite(MarioStateMachine.MarioSize size, bool facingLeft)
        {
            return new MarioRunningSprite(MarioSpriteSheet,  16, 6, 3, facingLeft, size);
        }
        public IMarioSprite GetJumpingSprite(MarioStateMachine.MarioSize size, bool facingLeft)
        {
            return new MarioJumpingSprite(MarioSpriteSheet,  16, 2, facingLeft, size);
        }
        public IMarioSprite GetDuckingSprite(MarioStateMachine.MarioSize size, bool facingLeft)
        {
            return new MarioDuckingSprite(MarioSpriteSheet,  16, 1, facingLeft, size);
        }
        public IMarioSprite GetInvisibleSprite()
        {
            return new MarioInvisibleSprite(MarioSpriteSheet, 16);
        }
        public IMarioSprite GetDeadSprite()
        {
            return new MarioDeadSprite(MarioSpriteSheet, 16, 0);
        }

    }

}
