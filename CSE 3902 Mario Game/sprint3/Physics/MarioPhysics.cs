using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class MarioPhysics : IPhysics
    {
        public double GravityCoef { get; set; }
        public double XDampingCoef { get; set; }
        public double XMaxVelocity { get; set; }
        public double YMaxVelocity { get; set; }
        public double XMinVelocity { get; set; }
        public double YMinVelocity { get; set; }
        public double XVelocity { get; set; }
        public double YVelocity { get; set; }
        public Vector2 MaxPosition { get; set; }
        public Vector2 MinPosition { get; set; }
        private IMario Mario;
        private int resetTimer = 0;
        private Game1 game;
        public MarioPhysics(IMario mario, Game1 Game)
        {
            Mario = mario;
            GravityCoef = PhysicsUtilites.GlobalGravityCoef;
            MaxPosition = new Vector2(PhysicsUtilites.XMaxPosition, PhysicsUtilites.YMaxPosition);
            MinPosition = new Vector2(PhysicsUtilites.XMinPosition, PhysicsUtilites.YMinPosition);
            XDampingCoef = PhysicsUtilites.PlayerFrictionCoef;
            XMaxVelocity = PhysicsUtilites.PlayerMaxVelocityX;
            YMaxVelocity = PhysicsUtilites.PlayerMaxVelocityY;
            XMinVelocity = PhysicsUtilites.PlayerMinVelocityX;
            YMinVelocity = PhysicsUtilites.PlayerMinVelocityY;
            XVelocity = 0;
            YVelocity = 0;
            game = Game;
        }
        public bool IsMovingX()
        {
            return XVelocity >= PhysicsUtilites.CheckIfMovingBound || XVelocity <= -PhysicsUtilites.CheckIfMovingBound;
        }
        public bool IsMovingY()
        {
            return YVelocity >= PhysicsUtilites.CheckIfMovingBound || YVelocity <= -PhysicsUtilites.CheckIfMovingBound;
        }

        public void UpdatePosition()
        { 
            PhysicsUtilites.ClampVelocity((IPhysics)this);
            double xPos = Mario.DestinationRectangle.Location.X;
            double yPos = Mario.DestinationRectangle.Location.Y;
            xPos += Math.Round(XVelocity);
            yPos += Math.Round(YVelocity);
            if (yPos > MinPosition.Y)
            {
                Mario.KillMario();
            }
            if(xPos > MaxPosition.X)
            {
                XMinVelocity = PhysicsUtilites.PlayerMinVelocityX;
            }
            if(xPos > PhysicsUtilites.FlagPosition && yPos < 0)
            {
                XVelocity = 0;
                xPos = PhysicsUtilites.FlagPosition;
            }
            if(xPos > PhysicsUtilites.FlagPosition-1)
            {                
                resetTimer++;
                if (resetTimer >= 500)
                {
                    game.GameReset.Execute();
                    game.toggleCastle = false;
                }
            }
            if(xPos >= PhysicsUtilites.XMaxPosition)
            {
                Mario.DrawInvisibleSprite = true;
                game.toggleCastle = true;
            }else
            {

                game.toggleCastle = false;
            }
            Vector2 pos = PhysicsUtilites.ClampPosition(xPos, yPos, (IPhysics)this);
            Mario.SetPosition(pos);
            XVelocity = XVelocity * XDampingCoef;
            YVelocity += GravityCoef;
        }
    }
}
