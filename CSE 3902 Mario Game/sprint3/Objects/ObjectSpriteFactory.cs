using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class ObjectSpriteFactory
    {
    private Texture2D BigBush, BigCloud,BigMountain,Piping,logo,
     FlagPole,LittleCloud,MedPipe,SmallBush,LPipe,Pointer,
     SmallMountain,SmallPipe,TallPipe, Castle, FireBall, FloorBlock,
     Elevator, LavaTile, LavaWave, ThankYouMario, Toad, BridgeRope,
     BowserFire, Axe;

        private static ObjectSpriteFactory instance = new ObjectSpriteFactory();
        public static ObjectSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private  ObjectSpriteFactory()
        {     
        }

        public void LoadAllTextures(ContentManager content)
        {
            BigBush = content.Load<Texture2D>("bigBush");
            BigCloud =content.Load<Texture2D>("bigCloud");
            BigMountain = content.Load<Texture2D>("bigMountain");
            Elevator = content.Load<Texture2D>("elevator");
            FlagPole = content.Load<Texture2D>("flagPole");
            LittleCloud =content.Load<Texture2D>("littleCloud");
            MedPipe = content.Load<Texture2D>("medPipe");
            SmallBush = content.Load<Texture2D>("littleBush");
            SmallMountain =content.Load<Texture2D>("smallMountain");
            SmallPipe =content.Load<Texture2D>("smallPipe");
            TallPipe = content.Load<Texture2D>("tallPipe");
            Castle = content.Load<Texture2D>("castle");
            FireBall = content.Load<Texture2D>("fireBalls");
            LPipe = content.Load<Texture2D>("leftPipe");
            Piping = content.Load<Texture2D>("piping");
            FloorBlock = content.Load<Texture2D>("floorBlock");
            Pointer = content.Load<Texture2D>("pointer");
            logo = content.Load<Texture2D>("logo");
            LavaTile = content.Load<Texture2D>("lavaBase");
            LavaWave = content.Load<Texture2D>("lavaWave");
            ThankYouMario = content.Load<Texture2D>("thankYouMario");
            Toad = content.Load<Texture2D>("toad");
            BridgeRope = content.Load<Texture2D>("bridgeRope");
            BowserFire = content.Load<Texture2D>("bowserFire");
            Axe = content.Load<Texture2D>("axe");
        }

        public IObject GetBigBush()
        {
            return new BigBush(BigBush,1,1);
        }

        public IObject GetBigCloud()
        {
            return new BigCloud(BigCloud,1,1);
        }

        public IObject GetBigMountain()
        {
            return new BigMountain(BigMountain,1,1);
        }
        public IObject GetElevator()
        {
            return new Elevator(Elevator, 1, 1);
        }

        public IObject GetFlagPole()
        {
            return new FlagPole(FlagPole,1,6);
        }

        public IObject GetLittleCloud()
        {
            return new LittleCloud(LittleCloud,1,1);
        }

        public IObject GetMedPipe()
        {
            return new MedPipe(MedPipe,1,1);
        }

        public IObject GetSmallBush()
        {
            return new SmallBush(SmallBush,1,1);
        }

        public IObject GetSmallMountain()
        {
            return new SmallMountain(SmallMountain,1,1);
        }

        public IObject GetSmallPipe()
        {
            return new SmallPipe(SmallPipe,1,1);
        }

        public IObject GetTallPipe()
        {
            return new TallPipe(TallPipe,1,1);
        }
        public IObject GetCastle()
        {
            return new Castle(Castle, 1, 16);
        }
        public IObject GetFireBall()
        {
            return new Fireball(FireBall, 1, 4);
        }
        public IObject GetLPipe()
        {
            return new leftPipe(LPipe, 1, 1);
        }
        public IObject GetPiping()
        {
            return new Piping(Piping, 1, 1);
        }
        public IObject GetBlockExplosion(Vector2 location, Color color)
        {
            return new BlockExplosionPiece(FloorBlock, location, color);
        }
        public IObject GetPointer()
        {
            return new Pointer(Pointer, 1, 1);
        }
        public IObject GetLogo()
        {
            return new Logo(logo, 1, 1);
        }
        public IObject GetLavaTile()
        {
            return new LavaTile(LavaTile, 1, 1);
        }
        public IObject GetLavaWave()
        {
            return new LavaWave(LavaWave, 1, 1);
        }
        public IObject GetThankYou()
        {
            return new ThankYouMario(ThankYouMario, 1, 1);
        }
        public IObject GetToad()
        {
            return new Toad(Toad, 1, 1);
        }
        public IObject GetBridgeRope()
        {
            return new BridgeRope(BridgeRope, 1, 1);
        }
        public IObject GetBowserFire()
        {
            return new BowserFire(BowserFire, 2, 2);
        }
        public IObject GetAxe()
        {
            return new Axe(Axe, 1, 3);
        }
    }
}