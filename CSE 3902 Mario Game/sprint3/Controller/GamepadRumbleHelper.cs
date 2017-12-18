using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    public class GamepadRumbleHelper
    {
        public float LowRumble { get; set; } = (float)0.3;
        public float MidRumble { get; set; } = (float)0.5;
        public float HighRumble { get; set; } = (float)0.8;
        public float QuickRumble { get; set; } = 100;
        public float ShortRumble { get; set; } = 500;
        public float LongRumble { get; set; } = 1000;

        PlayerIndex GamepadIndex;
        float LMotor, RMotor;
        float RumbleTime;
        bool RumbleIsActive;

        public GamepadRumbleHelper() {}

        public void Rumble (PlayerIndex Index, float LeftMotor, float RightMotor, float Time)
        {
            GamepadIndex = Index;
            LMotor = LeftMotor;
            RMotor = RightMotor;
            RumbleTime = Time;
            RumbleIsActive = true;
        }

        public void Update(GameTime gameTime)
        {
            if (RumbleIsActive)
            {
                float ElapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                RumbleTime -= ElapsedTime;

                RumbleIsActive = !(RumbleTime < 0);

                GamePad.SetVibration(GamepadIndex, LMotor, RMotor);
            } else
            {
                GamePad.SetVibration(GamepadIndex, 0, 0);
            }
        }
    }
}
