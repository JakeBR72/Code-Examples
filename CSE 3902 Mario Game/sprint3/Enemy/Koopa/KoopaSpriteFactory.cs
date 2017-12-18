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
    class KoopaSpriteFactory
    {

        private Texture2D ShelledKoopa;
        private Texture2D RecoveringKoopa;
        private Texture2D WalkingLeftKoopa;
        private  Texture2D WalkingRightKoopa;
        private Texture2D FlippedKoopa;

        private static KoopaSpriteFactory instance = new KoopaSpriteFactory();

        public static KoopaSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private KoopaSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            ShelledKoopa = content.Load<Texture2D>("koopaShell");

            RecoveringKoopa = content.Load<Texture2D>("koopaRecover");

            WalkingLeftKoopa = content.Load<Texture2D>("koopaLeft");

            WalkingRightKoopa = content.Load<Texture2D>("koopaRight");

            FlippedKoopa = content.Load<Texture2D>("flippedShell");
        }

        public IKoopaSprite GetLeftMovingSprite()
        {
            return new LeftMovingKoopaSprite(WalkingLeftKoopa);
        }
        public IKoopaSprite GetRightMovingSprite()
        {
            return new RightMovingKoopaSprite(WalkingRightKoopa);
        }
        public IKoopaSprite GetShelledSprite()
        {
            return new ShelledKoopaSprite(ShelledKoopa);
        }
        public IKoopaSprite GetRecoveringSprite()
        {
            return new RecoveringKoopaSprite(RecoveringKoopa);
        }
        public IKoopaSprite GetFlippedSprite()
        {
            return new FlippedKoopaSprite(FlippedKoopa);
        }

    }

}
