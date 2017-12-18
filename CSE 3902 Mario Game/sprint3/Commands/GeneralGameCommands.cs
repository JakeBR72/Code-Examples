using System;
using Microsoft.Xna.Framework;
namespace MarioGame
{
    class GeneralGameCommands
    {
        public class DebugMode : ICommand
        {
            private Game1 Game;

            public DebugMode(Game1 s2)
            {
                Game = s2;
            }

            public void Execute()
            {
                if (Game.DebugMode)
                {
                    Game.DebugMode = false;
                }
                else
                {
                    Game.DebugMode = true;
                }
            }
        }

        public class Quit : ICommand
        {
            private Game1 Game;

            public Quit(Game1 s2)
            {
                this.Game = s2;
            }

            public void Execute()
            {
                Game.Exit();
            }
        }
        public class ChangeLevel : ICommand
        {
            private Game1 Game;

            public ChangeLevel(Game1 s2)
            {
                Game = s2;
                Game.toggleCastle = false;
            }

            public void Execute()
            {
                string nextLevel = Game.csvFile;
                if(Game.curLevel == Game.csvFile)
                {
                    nextLevel = Game.csvFileTwo;
                }
                else if(Game.curLevel ==Game.csvFileTwo)
                {
                    nextLevel = Game.csvFileFour;
                } else if(Game.curLevel == Game.csvFileFour)
                {
                    nextLevel = Game.csvFileSix;
                }
                Game.changer = new LevelChanger(nextLevel, Game, Game.spriteBatch);
                Game.EnableControls = true;
                Game.timerEnabled = true;
                Game.changer.changeLevel();
            }
        }
    }  
}