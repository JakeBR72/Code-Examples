using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace MarioGame
{
    public class MarioFlagAnimation
    {
        IMario Mario; //Wherefore art thou?
        Game1 game;

        public MarioFlagAnimation(IMario mario, Game1 Game)
        {
            Mario = mario;
            game = Game;
        }

        public void Execute()
        {
            game.toggleCastle = true;
            Mario.SetLeft();
            Mario.SetPosition(new Vector2(Mario.Location.X, Mario.Location.Y));
            Mario.SetRight();
            Mario.Run();
            Mario.Physics.XMinVelocity = 1;
            game.timerEnabled = false;
            game.trophy.completed = true;
            MusicManager.Instance.SetBackgroundMusic("level-complete", false);
            Mario.Physics.GravityCoef = PhysicsUtilites.GlobalGravityCoef;
        }
    }
}
