using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public static class PhysicsUtilites
    {
        // Globals
        public const double GlobalGravityCoef = 0.2;
        public const double GlobalMaxGravity = 0.4;
        public const double GlobalMinGravity = 0.1;
        public const int XMaxPosition = 3256;
        public const int FlagPosition = 3192;
        public const int XMinPosition = 0;
        public const int YMaxPosition = -200;
        public const int YMinPosition = 400;
        public const double CheckIfMovingBound = 0.2;
        public const double GlobalGravityIncStep = 1.005;
        public const double GlobalGravityDecStep = 0.995;

        // Player specific
        public const double PlayerMaxGravity = 0.5;
        public const double PlayerMinGravity = 0.15;
        public const double PlayerFrictionCoef = 0.865;
        public const double PlayerMaxVelocityX = 3;
        public const double PlayerMinVelocityX = -3;
        public const double PlayerMaxVelocityY = -3.75;
        public const double PlayerMinVelocityY = 5;
        public const double PlayerBumpVelocityY = -2;
        public const double PlayerRunVelocity = 3;
        public const double PlayerWalkVelocity = 2;
        public const double PlayerXVelocityIncStep = 0.25;

        // Item specific
        public const double ItemMaxVelocityX = 1;
        public const double ItemMinVelocityX = -1;
        public const double ItemMaxVelocityY = -3;
        public const double ItemMinVelocityY = 3;
        public const double ItemProductionVelocity = -1;
        public const double ItemCoinProductionVelocity = -4;

        // Block specific
        public const double BlockMaxVelocityX = 0;
        public const double BlockMinVelocityX = 0;
        public const double BlockMaxVelocityY = -1;
        public const double BlockMinVelocityY = 1;

        // FireBall specific
        public const double FireBallMaxVelocityX = 3;
        public const double FireBallMinVelocityX = -3;
        public const double FireBallMaxVelocityY = 3;
        public const double FireBallMinVelocityY = -3;

        // BlockExplosion specific
        public const double BlockExplosionMaxVelocityX = 1;
        public const double BlockExplosionMinVelocityX = -1;
        public const double BlockExplosionMaxVelocityY = -3;
        public const double BlockExplosionMinVelocityY = 3;

        // Goomba specific
        public const double GoombaMaxVelocityX = 0.8;
        public const double GoombaMinVelocityX = -0.8;
        public const double GoombaMaxVelocityY = -2;
        public const double GoombaMinVelocityY = 5;

        // Koopa specific
        public const double KoopaMaxVelocityX = 3.05;
        public const double KoopaMinVelocityX = -3.05;
        public const double KoopaMaxVelocityY = -2;
        public const double KoopaMinVelocityY = 5;

        //Pirana specific
        public const double PiranaMaxVelocityY = -.75;
        public const double PiranaMinVelocityY = .75;
        public const double EnemyInitVelocity = -0.6;

        //Bowser specific
        public const double BowserGravityCoef = 0.1;
        public const double BowserMaxVelocityX = 0.5;
        public const double BowserMinVelocityX = -0.5;
        public const double BowserMaxVelocityY = -4;
        public const double BowserMinVelocityY = 5;
        public const double BowserInitVelocity = -0.6;

        // BowserFire specific
        public const double BowserFireMaxVelocityX = -0.8;
        public const double BowserFireMinVelocityX = 0.8;
        public const double BowserFireMaxVelocityY = 0;
        public const double BowserFireMinVelocityY = 0;


        public static void ClampVelocity(IPhysics theObject)
        {
            if (theObject.XVelocity > theObject.XMaxVelocity)
            {
                theObject.XVelocity = theObject.XMaxVelocity;
            }
            else if (theObject.XVelocity < theObject.XMinVelocity)
            {
                theObject.XVelocity = theObject.XMinVelocity;
            }
            if (theObject.YVelocity < theObject.YMaxVelocity)
            {
                theObject.YVelocity = theObject.YMaxVelocity;
            }
            else if (theObject.YVelocity > theObject.YMinVelocity)
            {
                theObject.YVelocity = theObject.YMinVelocity;
            }
        } 
        public static Vector2 ClampPosition(double xPos, double yPos, IPhysics theObject)
        {
            if (xPos < theObject.MinPosition.X)
            {
                xPos = theObject.MinPosition.X;
            }
            if (yPos > theObject.MinPosition.Y)
            {
                yPos = theObject.MinPosition.Y;
            }
            else if (yPos < theObject.MaxPosition.Y)
            {
                yPos = theObject.MaxPosition.Y;
                theObject.YVelocity = 0;
            }
            return new Vector2((float)xPos, (float)yPos);
        }
    }
}