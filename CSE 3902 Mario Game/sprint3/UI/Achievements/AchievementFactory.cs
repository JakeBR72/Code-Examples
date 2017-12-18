using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class AchievementFactory
    {
        Texture2D theCode, firstGoomba, boxFinder, firedUp, jumpMan, niceTry, notMarioMaker, brickBreaker, worldComplete, seeingStars;
        private static AchievementFactory instance = new AchievementFactory();
        public static AchievementFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private AchievementFactory()
        {
        }

        public void LoadAllContent(ContentManager content)
        {
            theCode = content.Load<Texture2D>("theCode");
            firstGoomba = content.Load<Texture2D>("firstGoombaKilled");
            boxFinder = content.Load<Texture2D>("boxFinder");
            firedUp = content.Load<Texture2D>("firedUp");
            jumpMan = content.Load<Texture2D>("jumpMan");
            niceTry = content.Load<Texture2D>("gameOver");
            notMarioMaker = content.Load<Texture2D>("notMarioMaker");
            brickBreaker = content.Load<Texture2D>("brickBreaker");
            worldComplete = content.Load<Texture2D>("worldComplete");
            seeingStars = content.Load<Texture2D>("seeingStars");

        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetFirstGoomba()
        {
            return new FirstGoombaKilled(firstGoomba,1,1);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetTheCode()
        {
            return new TheCode(theCode, 1, 1);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetBoxFinder()
        {
            return new TheCode(boxFinder, 1, 1);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetFiredUp()
        {
            return new TheCode(firedUp, 1, 1);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetJumpMan()
        {
            return new TheCode(jumpMan, 1, 1);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetNiceTry()
        {
            return new TheCode(niceTry, 1, 1);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetNotMarioMaker()
        {
            return new TheCode(notMarioMaker, 1, 1);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetBrickBreaker()
        {
            return new TheCode(brickBreaker, 1, 1);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetWorldComplete()
        {
            return new TheCode(worldComplete, 1, 1);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IIcon GetSeeingStars()
        {
            return new TheCode(seeingStars, 1, 1);
        }
    }
}
