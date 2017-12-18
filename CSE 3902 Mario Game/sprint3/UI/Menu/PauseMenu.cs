using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    public class PauseMenu
    {
        Game1 Game;
        SpriteFont Font;
        SpriteBatch spriteBatch;
        KeyboardState kbState;
        GamePadState padState;
        KeyboardState prevkbState;
        GamePadState prevPadState;
        bool savedGame = false;
        bool exitPressed = false;
        bool exitAnyway = false;
        Pointer pointer;
        Vector2 resumeLoc, exitLoc, saveLoc, pointerLoc, yesLoc, noLoc;
        private bool paused;
        public PauseMenu(Game1 game, SpriteBatch sb)
        {
            Game = game;
            spriteBatch = sb;
            resumeLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (110));
            saveLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (125));
            yesLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 3f), Game.MainCameraObject.DestinationRectangle.Y + (125));
            noLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 6f), Game.MainCameraObject.DestinationRectangle.Y + (125));
            exitLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (140));
            pointerLoc = resumeLoc;
        }

        public void Load(ContentManager content)
        {
            Font = content.Load<SpriteFont>("SMB");
            pointer = (Pointer)ObjectSpriteFactory.Instance.GetPointer();
        }
        void pauseGame(KeyboardState kb, GamePadState pad, KeyboardState prkb, GamePadState prpad)
        {
            if (prkb != kb || prpad != pad)
            {
                if ((kb.IsKeyDown(Keys.Enter) || pad.IsButtonDown(Buttons.Start)) && !paused)
                {
                    paused = true;
                    MarioWorldSoundBoard.Instance.PlayPause();
                    MusicManager.Instance.PauseBackgroundMusic();
                    resumeLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (110));
                    pointerLoc = resumeLoc;
                }
            }
        }
        public bool isPaused()
        {
            return paused;
        }

        void pointerMove(KeyboardState kb, GamePadState pad, KeyboardState prkb, GamePadState prpad)
        {
            if ((prkb != kb || prpad != pad) && paused)
            {
                if ((kb.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown)) && pointerLoc.Equals(resumeLoc))
                {
                    saveLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (125));
                    pointerLoc = saveLoc;
                }
                else if((kb.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown)) && pointerLoc.Equals(saveLoc))
                {
                    exitLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (140));
                    pointerLoc = exitLoc;
                }
               else if ((kb.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp)) && pointerLoc.Equals(saveLoc))
                {
                    resumeLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (110));
                    pointerLoc = resumeLoc;
                }
                else if ((kb.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp)) && pointerLoc.Equals(exitLoc))
                {
                    saveLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (125));
                    pointerLoc = saveLoc;
                }
            }
        }
        
        void MenuSelect(KeyboardState kb, GamePadState pad, KeyboardState prkb, GamePadState prpad)
        {
            if ((prkb != kb || prpad != pad) && paused)
            {
                if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(resumeLoc))
                {
                    paused = false;
                    resumeLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (110));
                    pointerLoc = resumeLoc;
                    MusicManager.Instance.PlayBackgroundMusic();
                }
                if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(saveLoc))
                {
                    Game.home.canLoad = true;
                    Game.data.SaveGame(Game);
                    paused = false;
                    Game.atMainMenu = true;
                    pointerLoc = new Vector2();
                    Game.changer.ClearList();
                    MusicManager.Instance.SetBackgroundMusic("main-theme");
                }
                if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(exitLoc))
                {
                    if (savedGame || exitAnyway)
                    {
                        paused = false;
                        Game.atMainMenu = true;
                        exitPressed = false;
                        exitAnyway = false;
                        savedGame = false;
                        pointerLoc = new Vector2();
                        Game.changer.ClearList();
                        MusicManager.Instance.SetBackgroundMusic("main-theme");
                    }
                    else
                    {
                        exitPressed = true;
                        pointerLoc = yesLoc;
                    }

                }
            }
        }
        void YesNoSelect(KeyboardState kb, GamePadState pad, KeyboardState prkb, GamePadState prpad)
        {
            if ((prkb != kb || prpad != pad) && paused)
            {
                if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(yesLoc))
                {
                    Game.data.SaveGame(Game);
                    savedGame = true;
                    pointerLoc = exitLoc;
                    Game.home.canLoad = true;
                }
                if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(noLoc))
                {
                    exitAnyway = true;
                    exitLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (140));
                    pointerLoc = exitLoc;
                    Game.home.canLoad = false;
                }

                if((kb.IsKeyDown(Keys.Right) || pad.IsButtonDown(Buttons.DPadRight)) && pointerLoc.Equals(yesLoc))
                {
                    pointerLoc = noLoc;
                }
                if ((kb.IsKeyDown(Keys.Left) || pad.IsButtonDown(Buttons.DPadLeft)) && pointerLoc.Equals(noLoc))
                {
                    pointerLoc = yesLoc;
                }
            }
        }
        public void Update()
        {
            kbState = Keyboard.GetState();
            padState = GamePad.GetState(PlayerIndex.One);
            pauseGame(kbState, padState, prevkbState, prevPadState);
            YesNoSelect(kbState, padState, prevkbState, prevPadState);
            pointerMove(kbState, padState, prevkbState, prevPadState);
            MenuSelect(kbState, padState, prevkbState, prevPadState);          
            prevkbState = Keyboard.GetState();
            prevPadState = GamePad.GetState(PlayerIndex.One);
            resumeLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (110));
            saveLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (125));
            yesLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 3f), Game.MainCameraObject.DestinationRectangle.Y + (125));
            noLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 6f), Game.MainCameraObject.DestinationRectangle.Y + (125));
            exitLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (140));

        }

        public void Draw()
        {
            if (paused)
            {
                if (!exitPressed)
                {
                    pointer.Draw(spriteBatch, pointerLoc);
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Font, "Resume", new Vector2(32 * 9, 210), Color.White);
                    spriteBatch.DrawString(Font, "Save", new Vector2(32 * 9, 240), Color.White);
                    spriteBatch.DrawString(Font, "Exit", new Vector2(32 * 9, 270), Color.White);
                    spriteBatch.End();
                }
                else
                {
                    pointer.Draw(spriteBatch, pointerLoc);
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Font, "Do you want to Save?", new Vector2(32 * 6, 210), Color.White);
                    spriteBatch.DrawString(Font, "Yes", new Vector2(32 * 8, 240), Color.White);
                    spriteBatch.DrawString(Font, "No", new Vector2(32 * 14, 240), Color.White);
                    spriteBatch.End();
                }
                
            }
        }
    }
}
