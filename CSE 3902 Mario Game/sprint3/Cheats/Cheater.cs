using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class Cheater
    {
        Game1 game;
        ScoreTracker score;
        MarioUI UI;
        KeyboardState kb;
        Collection<Keys> konamiKeys = new Collection<Keys>();
        Collection<Buttons> konamiButtons  = new Collection<Buttons>();
        KeyboardState prevkb;
        GamePadState Pad;
        GamePadState prevpad;
        int delayKb = 0;
        int wrongDelayKb = 0;
        int indexKb = 0;
        int delayPad = 0;
        int wrongDelayPad = 0;
        int indexPad = 0;

        public Cheater(ScoreTracker st, MarioUI ui, Game1 Game)
        {
            game = Game;
            score = st;
            UI = ui;
            prevkb = Keyboard.GetState();
            prevpad = GamePad.GetState(PlayerIndex.One);
            konamiKeys = new Collection<Keys> { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left,Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A};
            konamiButtons = new Collection<Buttons> { Buttons.DPadUp, Buttons.DPadUp , Buttons.DPadDown , Buttons.DPadDown,
                Buttons.DPadLeft, Buttons.DPadRight, Buttons.DPadLeft,Buttons.DPadRight,Buttons.B, Buttons.A };
        }
        public void Update()
        {
            KonamiCode();
            konamiCodeController();
        }

        void KonamiCode()
        {
            kb = Keyboard.GetState();
            if (indexKb < konamiKeys.Count && kb.IsKeyDown(konamiKeys[indexKb]))
            {
                indexKb++;
            }
            else
            {
                wrongDelayKb++;
            }
            if (kb.GetPressedKeys().Length == 0 || (kb == prevkb))
            {
                delayKb++;
            }
            else
            {
                delayKb = 0;
            }
            if(delayKb > 300 || wrongDelayKb > 100)
            {
                delayKb = 0;
                indexKb = 0;
                wrongDelayKb = 0;
            }
            
            prevkb = kb;

           
            if(indexKb == konamiKeys.Count)
            {
                score.Lives += 99;
                score.Score += 999999;
                UI.SetTimer(999);
                delayKb = 0;
                indexKb = 0;
                wrongDelayKb = 0;
                game.trophy.theCode = true;
                
            }
        }

        void konamiCodeController()
        {
            Pad = GamePad.GetState(PlayerIndex.One);
            if (indexPad < konamiButtons.Count && Pad.IsButtonDown(konamiButtons[indexPad]))
            {
                indexPad++;
            }
            else
            {
                wrongDelayPad++;
            }
            if (GetPressedButtons(Pad).Length == 0 || (Pad == prevpad))
            {
                delayPad++;
            }
            else
            {
                delayPad = 0;
            }
            if (delayPad > 300 || wrongDelayPad > 100)
            {
                delayPad = 0;
                wrongDelayPad = 0;
                indexPad = 0;
            }
            if (indexPad == konamiKeys.Count)
            {
                score.Lives += 99;
                score.Score += 999999;
                UI.SetTimer(999);
                delayPad = 0;
                indexPad = 0;
                wrongDelayPad = 0;
                game.trophy.theCode = true;

            }

        }

        static Buttons[] GetPressedButtons(GamePadState pad)
        {
            Buttons[] buttonsPressed = new Buttons[25];
            int count = 0;
            if (pad.IsButtonDown(Buttons.A))
            {
                buttonsPressed.SetValue(Buttons.A, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.B))
            {
                buttonsPressed.SetValue(Buttons.B, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.Back))
            {
                buttonsPressed.SetValue(Buttons.Back, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.BigButton))
            {
                buttonsPressed.SetValue(Buttons.BigButton, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.DPadDown))
            {
                buttonsPressed.SetValue(Buttons.DPadDown, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.DPadUp))
            {
                buttonsPressed.SetValue(Buttons.DPadUp, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.DPadLeft))
            {
                buttonsPressed.SetValue(Buttons.DPadLeft, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.DPadRight))
            {
                buttonsPressed.SetValue(Buttons.DPadRight, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.LeftShoulder))
            {
                buttonsPressed.SetValue(Buttons.LeftShoulder, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.LeftStick))
            {
                buttonsPressed.SetValue(Buttons.LeftStick, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.LeftThumbstickDown))
            {
                buttonsPressed.SetValue(Buttons.LeftThumbstickDown, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.LeftThumbstickUp))
            {
                buttonsPressed.SetValue(Buttons.LeftThumbstickUp, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                buttonsPressed.SetValue(Buttons.LeftThumbstickLeft, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.LeftThumbstickRight))
            {
                buttonsPressed.SetValue(Buttons.LeftThumbstickRight, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.RightThumbstickDown))
            {
                buttonsPressed.SetValue(Buttons.RightThumbstickDown, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.RightThumbstickUp))
            {
                buttonsPressed.SetValue(Buttons.RightThumbstickUp, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.RightThumbstickLeft))
            {
                buttonsPressed.SetValue(Buttons.RightThumbstickLeft, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.RightThumbstickRight))
            {
                buttonsPressed.SetValue(Buttons.RightThumbstickRight, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.RightShoulder))
            {
                buttonsPressed.SetValue(Buttons.RightShoulder, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.RightStick))
            {
                buttonsPressed.SetValue(Buttons.RightStick, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.RightTrigger))
            {
                buttonsPressed.SetValue(Buttons.RightTrigger, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.Start))
            {
                buttonsPressed.SetValue(Buttons.Start, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.X))
            {
                buttonsPressed.SetValue(Buttons.X, count);
                count++;
            }
            if (pad.IsButtonDown(Buttons.Y))
            {
                buttonsPressed.SetValue(Buttons.Y, count);
                count++;
            }

            return buttonsPressed;
        }
    }
}
