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
    class GoombaSpriteFactory
    {

        private Texture2D FlippedGoomba;
        private Texture2D StompedGoomba;
        private Texture2D WalkingGoomba;


        private static GoombaSpriteFactory instance = new GoombaSpriteFactory();

        public static GoombaSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private GoombaSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            FlippedGoomba = content.Load<Texture2D>("flippedGoomba");

            StompedGoomba = content.Load<Texture2D>("goobaStomp");

            WalkingGoomba = content.Load<Texture2D>("goombaWalk");
        }

        public IGoombaSprite GetLeftMovingSprite()
        {
            return new LeftMovingGoombaSprite(WalkingGoomba);
        }
        public IGoombaSprite GetRightMovingSprite()
        {
            return new RightMovingGoombaSprite(WalkingGoomba);
        }
        public IGoombaSprite GetStompedSprite()
        {
            return new StompedGoombaSprite(StompedGoomba);
        }
        public IGoombaSprite GetFlippedSprite()
        {
            return new FlippedGoombaSprite(FlippedGoomba);
        }

    }

}
