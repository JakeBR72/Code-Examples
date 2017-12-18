using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioFireBallCommand : ICommand
    {
        private Game1 Game;
        private MarioStateMachine.MarioSize currentSize = new MarioStateMachine.MarioSize();

        public MarioFireBallCommand(Game1 s2)
        {
            this.Game = s2;
        }

        public void Execute()
        {
            bool FacingLeft = Game.Mario.FacingLeft();
            currentSize = Game.Mario.Size();

            if (FacingLeft)
            {                
                ShootFireBall(-1);
            }
            else
            {
                
                ShootFireBall(1);
            }

        }
        void ShootFireBall(int direction)
        {
            if (Game.Mario.Health() == MarioStateMachine.MarioHealth.Dead)
            {
                return;
            }
            if (currentSize == MarioStateMachine.MarioSize.Fire)
            {
                MarioSoundBoard.Instance.PlayMarioFireball();
                    IObject fireBall = ObjectSpriteFactory.Instance.GetFireBall();
                    fireBall.Location = Game.Mario.Location + new Vector2(5*direction,5);
                    Game.objects.Add(fireBall);
                    Fireball fb = (Fireball)fireBall;
                    fb.physics.XVelocity *=  direction;
            }

        }
    }
}
