using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioGame
{
    public class KeyBoard : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        List<Keys> RegisteredKeys = new List<Keys>();
        private Game1 Game;
        private KeyboardState PreviousState;
        private KeyboardState CurrentState;
        private bool JumpKeyWasPressed;
        private bool FireballWasPressed;
        private int transCooldown = 1000;
        private int transCounter = 0;
        public int FireBallLimit { get; set; }
        private int fireBallCount;
        private string oldLevel;
        private bool isTransitioned = false;

        public KeyBoard(Game1 game)
        {
            Game = game;
            FireBallLimit = Game.objects.Count + 4;
            controllerMappings = new Dictionary<Keys, ICommand>();
            PreviousState = Keyboard.GetState();

            
            RegisterKey(Keys.X, new MarioRunCommand(game));
            RegisterKey(Keys.Z, new MarioUpCommand(game));
            RegisterKey(Keys.Down, new MarioDownCommand(game));
            RegisterKey(Keys.Left, new MarioLeftCommand(game));
            RegisterKey(Keys.Right, new MarioRightCommand(game));
            RegisterKey(Keys.G, new GlobalGravityIncrease(game));
            RegisterKey(Keys.F, new GlobalGravityDecrease(game));
            RegisterKey(Keys.R, new GlobalResetGravity(game));
            RegisterKey(Keys.Y, new PlayerStateCommands.Small(game));
            RegisterKey(Keys.T, new PlayerStateCommands.Star(game));
            RegisterKey(Keys.U, new PlayerStateCommands.Big(game));
            RegisterKey(Keys.I, new PlayerStateCommands.Fire(game));
            RegisterKey(Keys.L, new PlayerStateCommands.Damage(game));
            RegisterKey(Keys.O, new PlayerStateCommands.Kill(game));
            RegisterKey(Keys.P, new GeneralGameCommands.DebugMode(game));
            RegisterKey(Keys.Space, new GeneralGameCommands.ChangeLevel(game));
            RegisterKey(Keys.Escape, new GeneralGameCommands.Quit(game));

        }

        public void RegisterKey(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
            RegisteredKeys.Add(key);
        }

        
        public void Update(GameTime gameTime)
        {
            fireBallCount = Game.objects.Count;
            CurrentState = Keyboard.GetState();
            Keys[] keys = CurrentState.GetPressedKeys();

            if (CurrentState.IsKeyUp(Keys.Z))
                JumpKeyWasPressed = false;

            if (CurrentState.IsKeyUp(Keys.X))
                FireballWasPressed = false;

            foreach (Keys key in keys)
            {
                if (RegisteredKeys.Contains(key))
                {
                    Transition(key, gameTime);
                    if (key == Keys.Z)
                    {
                        if (!JumpKeyWasPressed)
                        {
                            DebugModeDelay(key);
                            JumpKeyWasPressed = true;
                        } else if (Game.Mario.Physics.YVelocity < 0)
                        {
                            Game.Mario.Physics.YVelocity -= .1;//hackish probably change.
                        }
                    } 

                    if(key == Keys.X && (CurrentState.IsKeyDown(Keys.Left) || CurrentState.IsKeyDown(Keys.Right)))
                        DebugModeDelay(key);
                    else if (key != Keys.Z && key != Keys.X)
                        DebugModeDelay(key);
                    if (key == Keys.X && !FireballWasPressed && FireBallLimit - fireBallCount > 0)
                    {
                        ICommand fb = new MarioFireBallCommand(Game);
                        fb.Execute();
                        FireballWasPressed = true;
                    }
                }
            }

            PreviousState = CurrentState;
        }

        public void Transition(Keys key, GameTime gameTime)
        {
            transCounter += gameTime.ElapsedGameTime.Milliseconds;
            if(transCounter > 100000)
            {
                transCounter = 1001;
            }
            if ((key == Keys.Down && Game.Mario.marioCanTransition) || key == Keys.Right && Game.Mario.marioCanTransitionLeftPipe)
            {
                string level = Game.parser.GetLevel();

                if (level.Equals("1-1") || level.Equals("Test"))
                {
                    MarioSoundBoard.Instance.PlayMarioPipe();
                    Game.changer.Transistion(Game.csvFileThree);
                    isTransitioned = true;
                    oldLevel = level;
                    MusicManager.Instance.SetBackgroundMusic("underground-theme");

                }
                else if (isTransitioned && oldLevel.Equals("Test"))
                {
                    Game.changer.TransitionBack(Game.csvFile);
                    isTransitioned = false;
                }
                else if (isTransitioned && oldLevel.Equals("1-1"))
                {
                    MarioSoundBoard.Instance.PlayMarioPipe();
                    Game.changer.TransitionBack(Game.csvFileTwo);
                    isTransitioned = false;
                }

                if (level.Equals("1-2") && transCounter > transCooldown) {
                    MarioSoundBoard.Instance.PlayMarioPipe();
                    Game.changer.Transistion(Game.csvFileFive);
                    isTransitioned = true;
                    oldLevel = level;
                    MusicManager.Instance.SetBackgroundMusic("underground-theme");
                } else if (isTransitioned && oldLevel.Equals("1-2"))
                {
                    transCounter = 0;
                    MarioSoundBoard.Instance.PlayMarioPipe();
                    Game.changer.TransitionBack(Game.csvFileFour);
                    isTransitioned = false;
                }
            }
        }
        public void DebugModeDelay(Keys key)
        {
            if (!(controllerMappings[key] is GeneralGameCommands.DebugMode) || !(PreviousState == CurrentState))
            {
                controllerMappings[key].Execute();
            }
        }
    }
}