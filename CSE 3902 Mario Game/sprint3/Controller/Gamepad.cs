using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    class Gamepad : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;
        List<Buttons> registeredButtons = new List<Buttons>();
        List<Buttons> PressedButtons = new List<Buttons>();
        private Game1 Game;
        private GamePadState PreviousState;
        private GamePadState CurrentState;
        private bool JumpKeyWasPressed;
        private bool FireballWasPressed;
        private int transCooldown = 1000;
        private int transCounter = 0;
        public int FireBallLimit { get; set; }
        private int fireBallCount;
        private string oldLevel;
        private bool isTransitioned = false;

        public Gamepad(Game1 game)
        {
            Game = game;
            FireBallLimit = Game.objects.Count + 4;
            controllerMappings = new Dictionary<Buttons, ICommand>();
            PreviousState = GamePad.GetState(PlayerIndex.One);

            RegisterButton(Buttons.DPadDown, new MarioDownCommand(game));
            RegisterButton(Buttons.DPadLeft, new MarioLeftCommand(game));
            RegisterButton(Buttons.DPadRight, new MarioRightCommand(game));
            RegisterButton(Buttons.X, new MarioRunCommand(game));
            RegisterButton(Buttons.A, new MarioUpCommand(game));
            RegisterButton(Buttons.Start, new GeneralGameCommands.ChangeLevel(game));
            RegisterButton(Buttons.Back, new GeneralGameCommands.Quit(game));
        }

        public void RegisterButton(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
            registeredButtons.Add(button);
        }

        public List<Buttons> GetPressedButtons(GamePadState state)
        {
            List<Buttons> PB = new List<Buttons>();

            foreach (Buttons button in registeredButtons) {
                if (state.IsButtonDown(button))
                    PB.Add(button);
            }

            return PB;
        }

        public void Update(GameTime gameTime)
        {
            fireBallCount = Game.objects.Count;
            CurrentState = GamePad.GetState(PlayerIndex.One);
            PressedButtons = GetPressedButtons(CurrentState);

            if (CurrentState.Buttons.A == ButtonState.Released)
                JumpKeyWasPressed = false;

            if (CurrentState.Buttons.X == ButtonState.Released)
                FireballWasPressed = false;

            foreach (Buttons button in PressedButtons)
            {
                Transition(button, gameTime);
                    if (button == Buttons.A)
                    {
                        if (!JumpKeyWasPressed)
                        {
                            DebugModeDelay(button);
                            JumpKeyWasPressed = true;
                        }else if(Game.Mario.Physics.YVelocity < 0)
                        {
                            Game.Mario.Physics.YVelocity -= .1;//hackish probably change.
                        }
                    }

                    if (button == Buttons.X && (CurrentState.DPad.Left == ButtonState.Pressed || CurrentState.DPad.Right == ButtonState.Pressed))
                        DebugModeDelay(button);
                    else if (button != Buttons.A && button != Buttons.X)
                        DebugModeDelay(button);

                    if (button == Buttons.X && !FireballWasPressed && FireBallLimit - fireBallCount > 0)
                    {
                        ICommand fb = new MarioFireBallCommand(Game);
                        fb.Execute();
                        FireballWasPressed = true;
                    }
            }

            PreviousState = CurrentState;
        }

        public void Transition(Buttons button, GameTime gameTime)
        {
            transCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (transCounter > 100000)
            {
                transCounter = 1001;
            }
            if ((button == Buttons.DPadDown && Game.Mario.marioCanTransition) || button == Buttons.DPadRight && Game.Mario.marioCanTransitionLeftPipe)
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

                if (level.Equals("1-2") && transCounter > transCooldown)
                {
                    MarioSoundBoard.Instance.PlayMarioPipe();
                    Game.changer.Transistion(Game.csvFileFive);
                    isTransitioned = true;
                    oldLevel = level;
                    MusicManager.Instance.SetBackgroundMusic("underground-theme");
                }
                else if (isTransitioned && oldLevel.Equals("1-2"))
                {
                    transCounter = 0;
                    MarioSoundBoard.Instance.PlayMarioPipe();
                    Game.changer.TransitionBack(Game.csvFileFour);
                    isTransitioned = false;
                }
            }
        }

        public void DebugModeDelay(Buttons button)
        {
            if (!(controllerMappings[button] is GeneralGameCommands.DebugMode) || !(PreviousState == CurrentState))
            {
                controllerMappings[button].Execute();
            }
        }
    }
}
