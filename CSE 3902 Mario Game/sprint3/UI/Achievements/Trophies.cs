using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MarioGame
{
    public class Trophies
    {
        SpriteBatch spriteBatch;
        Game1 Game;
        public Trophies(SpriteBatch sb, Game1 game)
        {
            spriteBatch = sb;
            Game = game;
        }
        IIcon goomba, konamiCode, boxFinder, firedUp, jumpMan, niceTry, notMarioMaker, brickBreaker, worldComplete, seeingStars;
        public bool killedGoomba { get; set; } = false;
        public bool theCode { get; set; } = false;
        public bool jumper { get; set; } = false;
        public bool completed { get; set; } = false;
        public bool found { get; set; } = false;

        public bool gameOver { get; set; } = false;
        public bool fireFlower { get; set; } = false;
        public bool marioMade { get; set; } = false;
        public bool buster { get; set; } = false;
        public bool gotAStar { get; set; } = false;

        public int breaker { get; set; } = 0;
        public int placer { get; set; } = 0;
        private int drawnGoomba = 0, drawnKonami = 0, drawnStar = 0, drawnNiceTry = 0, drawnBrickBreaker = 0,
            drawnJumpMan = 0, drawnFiredUp = 0, drawnNotMarioMaker = 0, drawnWorldComplete =0, drawnBoxFinder = 0;
        public void Load()
        {
            goomba = AchievementFactory.Instance.GetFirstGoomba();
            konamiCode = AchievementFactory.Instance.GetTheCode();
            boxFinder = AchievementFactory.Instance.GetBoxFinder();
            firedUp = AchievementFactory.Instance.GetFiredUp();
            jumpMan = AchievementFactory.Instance.GetJumpMan();
            niceTry = AchievementFactory.Instance.GetNiceTry();
            notMarioMaker = AchievementFactory.Instance.GetNotMarioMaker();
            brickBreaker = AchievementFactory.Instance.GetBrickBreaker();
            worldComplete = AchievementFactory.Instance.GetWorldComplete();
            seeingStars = AchievementFactory.Instance.GetSeeingStars();
        }

        public void Update()
        {
            if (Game.isGameOver)
            {
                gameOver = true;
            }
            jumper = Game.st.jumper;
            if(Game.Mario.Size() == MarioStateMachine.MarioSize.Fire)
            {
                fireFlower = true;
            }
            if (placer == 10)
            {
                marioMade = true;
            }
            if (breaker == 50)
            {
                buster = true;
            }
            if (Game.Mario is StarMario)
            {
                gotAStar = true;
            }
        }
        public void Draw()
        {
            drawnGoomba = TrophyGetter(goomba, drawnGoomba, killedGoomba);
            drawnKonami = TrophyGetter(konamiCode, drawnKonami, theCode);
            drawnStar = TrophyGetter(seeingStars, drawnStar, gotAStar);
            drawnNiceTry = TrophyGetter(niceTry, drawnNiceTry, gameOver);
            drawnBrickBreaker = TrophyGetter(brickBreaker, drawnBrickBreaker, buster);
            drawnJumpMan = TrophyGetter(jumpMan, drawnJumpMan, jumper);
            drawnFiredUp = TrophyGetter(firedUp, drawnFiredUp, fireFlower);
            drawnNotMarioMaker = TrophyGetter(notMarioMaker, drawnNotMarioMaker, marioMade);
            drawnWorldComplete = TrophyGetter(worldComplete, drawnWorldComplete, completed);
            drawnBoxFinder = TrophyGetter(boxFinder, drawnBoxFinder, found);
        }
        int TrophyGetter(IIcon icon, int delay, bool achieved)
        {
            if(delay < 200 && achieved)
            {
                icon.Draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (40)), Color.White);
                return delay + 1;
            }
            return delay;
        }
    }
}
