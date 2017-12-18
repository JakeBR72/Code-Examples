using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;

namespace MarioGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch { get; set; }

        public IMario Mario { get; set; }

        public bool DebugMode { get; set; }
        public string curLevel { get; set; }
        public string csvFile { get; } = Path.Combine(System.Environment.CurrentDirectory, @"Levels\", "level.csv");
        public string csvFileTwo { get; } = Path.Combine(System.Environment.CurrentDirectory, @"Levels\", "worldOneOne.csv");
        public string csvFileThree { get; } = Path.Combine(System.Environment.CurrentDirectory, @"Levels\", "worldOneOneUnderground.csv");
        public string csvFileFour { get; } = Path.Combine(System.Environment.CurrentDirectory, @"Levels\", "worldOneTwo.csv");
        public string csvFileFive { get; } = Path.Combine(System.Environment.CurrentDirectory, @"Levels\", "worldOneTwoUnderground.csv");
        public string csvFileSix { get; } = Path.Combine(System.Environment.CurrentDirectory, @"Levels\", "worldOneFour.csv");
        public LevelParse parser { get; set; }
        public LevelEditor editor { get; set; }
        public bool toggleCastle { get; set; } = false;
        public LevelChanger changer { get; set; }
        public CollisionFinderInit finderInit { get; set; }
        public ICommand GameReset { get; set; }

        private int countToRestart = 100;

        public Collection<IKoopa> koopaList { get; } = new Collection<IKoopa>();
        public Collection<Goomba> goombaList { get; } = new Collection<Goomba>();
        public Collection<IPiranaPlant> piranaPlantList { get; } = new Collection<IPiranaPlant>();
        public Collection<IBowser> bowserList { get; } = new Collection<IBowser>();
        public Collection<IBlock> blocks { get; } = new Collection<IBlock>();
        public Collection<IItem> items { get; } = new Collection<IItem>();
        public Collection<IObject> objects { get; } = new Collection<IObject>();
        public Collection<IObject> backGround { get; } = new Collection<IObject>();
        public Collection<ICollisionFinder> CollisionFinder { get; } = new Collection<ICollisionFinder>();
        public SaveDataManagement data { get; set; }
        public IController keyboard { get; set; }
        public IController gamepad { get; set; }
        public GamepadRumbleHelper RumbleHelper { get; set; }
        public MouseController mouse { get; set; }
        public bool EnableControls { get; set; } = true;

        public static ICamera MainCamera { get; set; }
        public IGameObject MainCameraObject { get; set; }
        private int delay = 0;
        public int lives { get; set; }
        public bool changingLevel { get; set; } = false;
        private int deathDelayScreen = 0;
        public bool needBlackScreen { get; set; } = false;
        public bool isGameOver { get; set; } = false;
        private bool soundPlayed = false;
        private bool alreadyKilled = false;
        public bool atMainMenu { get; set; } = true;

        public MainMenu home { get; set; }
        public MarioUI UI { get; set; }
        public bool timerEnabled { get; set; } = true;
        public LoadScreen load { get; set; }
        public ScoreTracker st { get; set; }
        public Cheater cheats { get; set; }
        public Trophies trophy { get; set; }
        public PauseMenu pauser { get; set; }

        public Game1()
        {
            st = new ScoreTracker();
            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 448;
            graphics.PreferredBackBufferWidth = 768;
            Content.RootDirectory = "Content";
            finderInit = new CollisionFinderInit(this);
            lives = st.Lives;
            load = new LoadScreen(this, lives);
        }

        protected override void Initialize()
        {
            base.Initialize();
            MainCamera = new MarioCamera(GraphicsDevice.Viewport, this);
            MainCameraObject = MainCamera;
            UI = new MarioUI(this);
            UI.Load(Content);
            finderInit.CollisionInit();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            home = new MainMenu(this);
            home.Load(Content);
            cheats = new Cheater(st, UI, this);
            editor = new LevelEditor(this);
            changer = new LevelChanger(csvFile, this, spriteBatch);
            GameReset = new GeneralGameCommands.ChangeLevel(this);
            mouse = new MouseController(this);
            pauser = new PauseMenu(this, spriteBatch);
            pauser.Load(Content);
            trophy = new Trophies(spriteBatch, this);
            trophy.Load();
            RumbleHelper = new GamepadRumbleHelper();
            data = new SaveDataManagement(this);
            keyboard = new KeyBoard(this);
            gamepad = new Gamepad(this);
        }

        protected override void LoadContent()
        {
            MarioSpriteFactory.Instance.LoadAllTextures(Content);
            GoombaSpriteFactory.Instance.LoadAllTextures(Content);
            KoopaSpriteFactory.Instance.LoadAllTextures(Content);
            PiranaSpriteFactory.Instance.LoadAllTextures(Content);
            BowserSpriteFactory.Instance.LoadAllTextures(Content);
            ObjectSpriteFactory.Instance.LoadAllTextures(Content);
            AchievementFactory.Instance.LoadAllContent(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            MusicManager.Instance.SetContent(Content);
            SoundBoardManager.SetVolume((float).25);
            SoundBoardManager.SetContent(Content);
            load.Load(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected void GameNotOverDraw(GameTime gameTime)
        {
            parser.Draw();
            trophy.Draw();
            Mario.Draw(spriteBatch);
            pauser.Draw();
            if ((Mario.Health() == MarioStateMachine.MarioHealth.Dead && deathDelayScreen > 70 && st.Lives >= 0 && !(UI.getTime() <= 0)) || changingLevel)
            {
                load.Draw(spriteBatch);
                if (delay > 100)
                {
                    changingLevel = false;
                    st.EndStarCombo();
                    deathDelayScreen = 0;
                    delay = 0;

                    st.LoseLife();
                    st.AllowFlagpolePoints();
                    st.TimePoints(UI.Time);
                    UI.SetTimer(400);
                }
                else
                {
                    delay++;
                }
            }
            else if ((Mario.Health() == MarioStateMachine.MarioHealth.Dead && !(UI.getTime() <= 0) || changingLevel) && st.Lives < 0)
            {
                isGameOver = true;
                changingLevel = false;
            }
            if (needBlackScreen)
            {
                load.BlackScreen();
                if (delay > 30)
                {
                    needBlackScreen = false;
                    delay = 0;
                }
                else
                {
                    delay++;
                }
            }
            if (UI.getTime() <= 0)
            {
                if (Mario.Health() == MarioStateMachine.MarioHealth.Normal && !alreadyKilled)
                {
                    Mario.KillMario();
                    alreadyKilled = true;
                }
                if (deathDelayScreen > 70)
                {
                    load.TimeUp(spriteBatch);
                    if (delay > 150)
                    {
                        alreadyKilled = false;
                        st.EndStarCombo();
                        deathDelayScreen = 0;
                        delay = 0;
                        st.LoseLife();
                        st.AllowFlagpolePoints();
                        st.TimePoints(UI.Time);
                        UI.SetTimer(400);
                    }
                    else
                    {
                        delay++;
                    }
                }
            }
            UI.Draw(spriteBatch);
            editor.Draw(spriteBatch);
            if (Mario.Health() == MarioStateMachine.MarioHealth.Dead)
            {
                deathDelayScreen++;
            }
            base.Draw(gameTime);
        }
        protected override void Update(GameTime gameTime)
        {
            if (atMainMenu)
            {
                home.Update();
            }
            else
            {
                pauser.Update();
                trophy.Update();
                if (!pauser.isPaused())
                {
                    cheats.Update();
                    if (Mario.Health() == MarioStateMachine.MarioHealth.Dead)
                    {
                        countToRestart--;
                    }
                    if (countToRestart == 0)
                    {
                        countToRestart = 100;
                        changer.changeLevel();
                        LevelChanger.SetBGMusic(curLevel);
                    }
                    if (EnableControls)
                    {
                        keyboard.Update(gameTime);
                        gamepad.Update(gameTime);
                        mouse.Update(gameTime);
                        RumbleHelper.Update(gameTime);
                    }
                    if (!changingLevel)
                    {
                        Mario.Update(gameTime);
                        parser.Update();
                    }
                    MainCamera.Update(Mario);
                    load.Update();
                    UI.Update(gameTime);
                    if (!timerEnabled)
                    {
                        UI.StopTimer();
                    }
                    parser.ToggleCastle(toggleCastle);
                    base.Update(gameTime);
                }
                else
                {
                    pauser.Update();
                    if (EnableControls)
                    {
                        keyboard.Update(gameTime);
                        gamepad.Update(gameTime);
                        mouse.Update(gameTime);
                        RumbleHelper.Update(gameTime);
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (atMainMenu)
            {
                home.Draw(spriteBatch, GraphicsDevice);
            }
            else
            {
                
                if (!(curLevel.Contains("Underground") || curLevel.Contains("Four")))
                {
                    GraphicsDevice.Clear(Color.CornflowerBlue);
                }
                else
                {
                    GraphicsDevice.Clear(Color.Black);
                }
                if (!isGameOver)
                {
                    GameNotOverDraw(gameTime);
                }
                else
                {
                    MusicManager.Instance.StopBackgroundMusic();
                    parser.Draw();
                    Mario.Draw(spriteBatch);
                    UI.Draw(spriteBatch);
                    trophy.Draw();
                    if (delay > 150)
                    {
                        load.GameOver(spriteBatch);
                        if (!soundPlayed)
                        {
                            MarioWorldSoundBoard.Instance.PlayGameOver();
                            soundPlayed = true;
                        }
                        else if (soundPlayed && delay > 350)
                        {
                            changer.changeLevel();
                            LevelChanger.SetBGMusic(curLevel);
                            delay = 0;
                            soundPlayed = false;
                            st = new ScoreTracker();
                            isGameOver = false;
                        }
                    }
                    delay++;
                }
            }
        }
    }
}
