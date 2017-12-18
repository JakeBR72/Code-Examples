using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame 
{
    public class MarioFlagPoleCollision : ICommand
    {
        public Game1 Game { get; set; }
        private ICollision Side;
        private IMario Mario;
        private FlagPole flag;

        public MarioFlagPoleCollision(ICollision side, Game1 game)
        {
            Side = side;
            Game = game;

            if (Side.BottomOrRight is IMario)
            {
                Mario = (IMario)Side.BottomOrRight;
                flag = (FlagPole)Side.TopOrLeft;
            }
            else
            {
                Mario = (IMario)Side.TopOrLeft;
                flag = (FlagPole)Side.BottomOrRight;
            }
        }
        public void Execute()
        {
            Game.EnableControls = false;
            if (Mario.Location.Y < 60 && Mario.Location.Y >= 32)
            {
                flag.Goal(0);
                Game.st.Flagpole(0);
            }
            else if (Mario.Location.Y < 88 && Mario.Location.Y >= 60)
            {
                flag.Goal(1);
                Game.st.Flagpole(1);
            }
            else if (Mario.Location.Y < 116 && Mario.Location.Y >= 88)
            {
                flag.Goal(2);
                Game.st.Flagpole(2);
            }
            else if (Mario.Location.Y < 144 && Mario.Location.Y >= 116)
            {
                flag.Goal(3);
                Game.st.Flagpole(3);
            }
            else if (Mario.Location.Y < 172 && Mario.Location.Y >= 144)
            {
                flag.Goal(4);
                Game.st.Flagpole(4);
            }
            else if (Mario.Location.Y < 200 && Mario.Location.Y >= 172)
            {
                flag.Goal(5);
                Game.st.Flagpole(5);
            }
            if (!flag.flagCheck && flag.Location.X - Mario.Location.X < 0)
            {
                Mario.Physics.GravityCoef = 0;
                Mario.Jump();
                MarioWorldSoundBoard.Instance.PlayFlagpole();
                Mario.Physics.YVelocity = 1;
                Mario.Physics.XVelocity = 0;
                flag.flagCheck = true;
            }
            if (Mario.Location.Y >= 144)
            {
                Mario.SetPosition(new Vector2(Mario.Location.X, 144));
                Mario.Idle();
                MarioFlagAnimation marioFlagAnimation = new MarioFlagAnimation(Mario,Game);
                flag.Goal(5);
                Game.st.Flagpole(5);
                marioFlagAnimation.Execute();
            }
        }
    }
}

