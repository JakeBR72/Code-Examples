using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System;

namespace MarioGame
{
    public class MainMenu
    {
        Game1 Game;
        SpriteFont Font;
        KeyboardState kbState;
        GamePadState padState;
        KeyboardState prevkbState;
        GamePadState prevPadState;
        Vector2 pointerLoc, testLoc, worldOneLoc, worldOneTwoLoc,worldOneFourLoc, AchievementsLoc, worldsLoc,loadsLoc;
        IMarioSprite mario;
        Pointer pointer;
        IObject bush, mountain, smallCloud, bigCloud;
        IBlockSprite block;
        Logo logo;
        IIcon goomba, konami, boxFinder, firedUp, jumpMan, niceTry, notMarioMaker, brickBreaker, worldComplete, seeingStars;
        private bool buttonPressed = false;
        private bool pointerDraw = false;
        private bool worldsPressed = false;
        private bool achievementSet = false;

        public bool canLoad { get; set; } = false;

        public MainMenu(Game1 game)
        {
            Game = game;
            worldsLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (109));
            testLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (110));
            worldOneLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (125));
            loadsLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (124));
            worldOneTwoLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (140));
            AchievementsLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (139));
            worldOneFourLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (155));
            
        }
        public void Load(ContentManager content)
        {
            Font = content.Load<SpriteFont>("SMB");
            mario = MarioSpriteFactory.Instance.GetIdleSprite(MarioStateMachine.MarioSize.Small, false);
            pointer = (Pointer)ObjectSpriteFactory.Instance.GetPointer();
            bush = ObjectSpriteFactory.Instance.GetBigBush();
            mountain = ObjectSpriteFactory.Instance.GetBigMountain();
            smallCloud = ObjectSpriteFactory.Instance.GetLittleCloud();
            bigCloud = ObjectSpriteFactory.Instance.GetBigCloud();
            block = BlockSpriteFactory.Instance.CreateFloorBlock(new Vector2(0,0));
            logo = (Logo)ObjectSpriteFactory.Instance.GetLogo();
            goomba = AchievementFactory.Instance.GetFirstGoomba();
            konami = AchievementFactory.Instance.GetTheCode();
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
            kbState = Keyboard.GetState();
            padState = GamePad.GetState(PlayerIndex.One);
            StartMenu(kbState, padState);
            MapSelect(kbState, padState,prevkbState,prevPadState);
            WorldSelect(kbState, padState, prevkbState, prevPadState);
            prevkbState = kbState;
            prevPadState = padState;

        }

        void StartMenu(KeyboardState kb, GamePadState pad)
        {

            if ((kb.IsKeyDown(Keys.Enter) || pad.IsButtonDown(Buttons.Start)) && !buttonPressed)
            {
                buttonPressed = true;
                achievementSet = false;
                worldsPressed = false;
                pointerDraw = true;
                pointerLoc = worldsLoc;
            }

            if ((kb.IsKeyDown(Keys.X) || pad.IsButtonDown(Buttons.B) && buttonPressed))
            {
                buttonPressed = false;
                achievementSet = false;
                worldsPressed = false;
                pointerDraw = false;
                pointerLoc = new Vector2();
            }

            if ((kb.IsKeyDown(Keys.X) || pad.IsButtonDown(Buttons.B) && achievementSet))
            {
                buttonPressed = true;
                achievementSet = false;
                worldsPressed = false;
                pointerLoc = worldsLoc;
            }
            if ((kb.IsKeyDown(Keys.X) || pad.IsButtonDown(Buttons.B) && !achievementSet))
            {
                buttonPressed = false;
                worldsPressed = false;
                pointerDraw = false;
                pointerLoc = new Vector2();
            }
            if ((kb.IsKeyDown(Keys.X) || pad.IsButtonDown(Buttons.B) && worldsPressed))
            {
                buttonPressed = true;
                worldsPressed = false;
                achievementSet = false;
                pointerDraw = true;
                pointerLoc = worldsLoc;
            }
            if ((kb.IsKeyDown(Keys.X) || pad.IsButtonDown(Buttons.B) && !worldsPressed))
            {
                buttonPressed = false;
                pointerDraw = false;
                achievementSet = false;
                pointerDraw = false;
                pointerLoc = new Vector2();
            }

        }

        void MapSelect(KeyboardState kb, GamePadState pad, KeyboardState prkb, GamePadState prpad)
        {
            worldsLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (109));
            testLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (110));
            worldOneLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (125));
            loadsLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (124));
            worldOneTwoLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (140));
            AchievementsLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (139));
            worldOneFourLoc = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 4f), Game.MainCameraObject.DestinationRectangle.Y + (155));

            if ((prkb != kb || prpad != pad) && worldsPressed && buttonPressed)
            {
                if ((kb.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp)) && pointerLoc.Equals(worldOneLoc))
                {
                    pointerLoc = testLoc;
                }
                else if ((kb.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp)) && pointerLoc.Equals(worldOneTwoLoc))
                {
                    pointerLoc = worldOneLoc;
                }
                else if ((kb.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp)) && pointerLoc.Equals(worldOneFourLoc))
                {
                    pointerLoc = worldOneTwoLoc;
                }

                // add more conditions if more menu choices

                if ((kb.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown)) && pointerLoc.Equals(testLoc))
                {
                    pointerLoc = worldOneLoc;
                }
                else if ((kb.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown)) && pointerLoc.Equals(worldOneLoc))
                {
                    pointerLoc = worldOneTwoLoc;
                }
                else if ((kb.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown)) && pointerLoc.Equals(worldOneTwoLoc))
                {
                    pointerLoc = worldOneFourLoc;
                }
                // add more conditions if more menu choices
            }
            else if ((prkb != kb || prpad != pad) && !worldsPressed && buttonPressed)
            {

                if ((kb.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown)) && pointerLoc.Equals(worldsLoc) && canLoad)
                {
                    pointerLoc = loadsLoc;
                }
                else if ((kb.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown)) && pointerLoc.Equals(worldsLoc) && !canLoad)
                {
                    pointerLoc = AchievementsLoc;
                }
                else if ((kb.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown)) && pointerLoc.Equals(loadsLoc))
                {
                    pointerLoc = AchievementsLoc;
                }

                if ((kb.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp)) && pointerLoc.Equals(AchievementsLoc) && canLoad)
                {
                    pointerLoc = loadsLoc;
                }
                else if ((kb.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp)) && pointerLoc.Equals(AchievementsLoc) && !canLoad)
                {
                    pointerLoc = worldsLoc;
                }
                else if((kb.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp)) && pointerLoc.Equals(loadsLoc))
                {
                    pointerLoc = worldsLoc;
                }
            }
        }
        private void UpdateFireBall()
        {
            KeyBoard tempKeyBoard = (KeyBoard)Game.keyboard;
            tempKeyBoard.FireBallLimit = Game.objects.Count + 4;
            Game.keyboard = (IController)tempKeyBoard;
            Gamepad tempGamePad = (Gamepad)Game.gamepad;
            tempGamePad.FireBallLimit = Game.objects.Count + 4;
            Game.gamepad = (IController)tempGamePad;
        }

        void WorldSelect(KeyboardState kb, GamePadState pad, KeyboardState prkb, GamePadState prpad)
        {
            if (prkb != kb || prpad != pad)
            {
                if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(testLoc))
                {
                    Game.atMainMenu = false;
                    Game.parser = new LevelParse(Game.csvFile, Game, Game.spriteBatch);
                    Game.parser.LevelParser();
                    Game.UI.SetTimer(400);
                    buttonPressed = false;
                    pointerDraw = false;
                    achievementSet = false;
                    UpdateFireBall();
                }
                else if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(worldOneLoc))
                {
                    Game.atMainMenu = false;
                    Game.parser = new LevelParse(Game.csvFileTwo, Game, Game.spriteBatch);
                    Game.parser.LevelParser();
                    Game.UI.SetTimer(400);
                    buttonPressed = false;
                    pointerDraw = false;
                    achievementSet = false;
                    UpdateFireBall();
                }
                else if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(worldOneTwoLoc))
                {
                    Game.atMainMenu = false;
                    Game.parser = new LevelParse(Game.csvFileFour, Game, Game.spriteBatch);
                    Game.parser.LevelParser();
                    Game.UI.SetTimer(400);
                    buttonPressed = false;
                    pointerDraw = false;
                    achievementSet = false;
                    UpdateFireBall();
                }
                else if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(worldOneFourLoc))
                {
                    Game.atMainMenu = false;
                    Game.parser = new LevelParse(Game.csvFileSix, Game, Game.spriteBatch);
                    Game.parser.LevelParser();
                    Game.UI.SetTimer(400);
                    buttonPressed = false;
                    pointerDraw = false;
                    achievementSet = false;
                    UpdateFireBall();
                }
                else if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(AchievementsLoc))
                {
                    achievementSet = true;

                }
                else if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(worldsLoc))
                {
                    worldsPressed = true;
                    pointerLoc = testLoc;
                }
                else if ((kb.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A)) && pointerLoc.Equals(loadsLoc))
                {
                    Game.atMainMenu = false;
                    buttonPressed = false;
                    pointerDraw = false;
                    achievementSet = false;
                    Game.data.LoadGame(Game);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            graphics.Clear(Color.CornflowerBlue);
            if (!achievementSet)
            {
                if (pointerDraw)
                {
                    pointer.Draw(spriteBatch, pointerLoc);
                }
                for (int i = 0; i < 24; i++)
                {
                    block.draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (i * 16), Game.MainCameraObject.DestinationRectangle.Y + (187)), Color.White);
                    block.draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (i * 16), Game.MainCameraObject.DestinationRectangle.Y + (203)), Color.White);
                    block.draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (i * 16), Game.MainCameraObject.DestinationRectangle.Y + (219)), Color.White);
                }

                bigCloud.Draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (40)));
                smallCloud.Draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 9.2f), Game.MainCameraObject.DestinationRectangle.Y + (60)));
                bush.Draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 8.7f), Game.MainCameraObject.DestinationRectangle.Y + (171)));
                mountain.Draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (152)));
                mario.Draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (171)));
                logo.Draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 3.4f), Game.MainCameraObject.DestinationRectangle.Y + (10)));

                spriteBatch.Begin();


                if (!buttonPressed)
                {
                    spriteBatch.DrawString(Font, "Press Start", new Vector2(32 * 9, 270), Color.White);
                    spriteBatch.DrawString(Font, "Enter/Start", new Vector2(16, 420), Color.White);
                }
                else
                {
                    if (!worldsPressed)
                    {
                        spriteBatch.DrawString(Font, "Z/A - Select  X/B - Back     Up/Down - Move", new Vector2(16, 420), Color.White);
                        spriteBatch.DrawString(Font, "World Select", new Vector2(32 * 9, 210), Color.White);
                        if (canLoad)
                        {
                            spriteBatch.DrawString(Font, "Load", new Vector2(32 * 9, 240), Color.White);
                        }
                        else
                        {
                            spriteBatch.DrawString(Font, "Load", new Vector2(32 * 9, 240), Color.Gray);
                        }
                        spriteBatch.DrawString(Font, "Achievements", new Vector2(32 * 9, 270), Color.White);
                    }
                    else if (worldsPressed)
                    {
                        spriteBatch.DrawString(Font, "Z/A - Select  X/B - Back     Up/Down - Move", new Vector2(16, 420), Color.White);
                        spriteBatch.DrawString(Font, "Test World", new Vector2(32 * 9, 210), Color.White);
                        spriteBatch.DrawString(Font, "World 1-1", new Vector2(32 * 9, 240), Color.White);
                        spriteBatch.DrawString(Font, "World 1-2", new Vector2(32 * 9, 270), Color.White);
                        spriteBatch.DrawString(Font, "World 1-4", new Vector2(32 * 9, 300), Color.White);
                    }
                }
                spriteBatch.End();
            }
            else
            {
              
                AchievementDraw(goomba, spriteBatch, Game.trophy.killedGoomba,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (10)));
                AchievementDraw(konami, spriteBatch, Game.trophy.theCode,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (70)));
                AchievementDraw(boxFinder, spriteBatch, Game.trophy.found,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (130)));
                AchievementDraw(firedUp, spriteBatch, Game.trophy.fireFlower,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (190)));
                AchievementDraw(jumpMan, spriteBatch, Game.trophy.jumper,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 1.1f), Game.MainCameraObject.DestinationRectangle.Y + (250)));
                AchievementDraw(niceTry, spriteBatch, Game.trophy.gameOver,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 15.1f), Game.MainCameraObject.DestinationRectangle.Y + (10)));
                AchievementDraw(notMarioMaker, spriteBatch, Game.trophy.marioMade,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 15.1f), Game.MainCameraObject.DestinationRectangle.Y + (70)));
                AchievementDraw(brickBreaker, spriteBatch, Game.trophy.buster,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 15.1f), Game.MainCameraObject.DestinationRectangle.Y + (130)));
                AchievementDraw(worldComplete, spriteBatch, Game.trophy.completed,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 15.1f), Game.MainCameraObject.DestinationRectangle.Y + (190)));
                AchievementDraw(seeingStars, spriteBatch, Game.trophy.gotAStar,
                    new Vector2(Game.MainCameraObject.DestinationRectangle.X + (16 * 15.1f), Game.MainCameraObject.DestinationRectangle.Y + (250)));


                spriteBatch.Begin();
                spriteBatch.DrawString(Font, "X/B - Back", new Vector2(16, 420), Color.White);
                spriteBatch.End();
            }
        }

        static void AchievementDraw(IIcon icon, SpriteBatch sb, bool achieved, Vector2 loc)
        {
            if (achieved)
            {
                icon.Draw(sb, loc, Color.White);
            }
            else
            {
                icon.Draw(sb, loc, Color.Black);
            }
        }
    }
}
