using Microsoft.Xna.Framework;

namespace MarioGame
{
    class BowserFireCommand : ICommand
    {
        private Game1 Game;
        private Vector2 SpawnLocation;

        public BowserFireCommand(Vector2 spawnLocation, Game1 game)
        {
            Game = game;
            SpawnLocation = spawnLocation;
        }

        public void Execute()
        {
            KeyBoard tempKeyBoard = (KeyBoard)Game.keyboard;
            tempKeyBoard.FireBallLimit++;
            Game.keyboard = (IController)tempKeyBoard;
            Gamepad tempGamePad = (Gamepad)Game.gamepad;
            tempGamePad.FireBallLimit++;
            Game.gamepad = (IController)tempGamePad;
            MarioSoundBoard.Instance.PlayBowserFire();
            IObject bowserFire = ObjectSpriteFactory.Instance.GetBowserFire();
            bowserFire.Location = new Vector2(SpawnLocation.X - 10, SpawnLocation.Y + 5);
            BowserFire bf = (BowserFire)bowserFire;
            Game.objects.Add(bf);
        }
    }
}
