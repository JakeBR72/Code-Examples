namespace MarioGame
{
    class PlayerStateCommands
    {
        public class Small : ICommand
        {
            private Game1 Game;

            public Small(Game1 s2)
            {
                this.Game = s2;
            }

            public void Execute()
            {
                if (Game.DebugMode)
                {
                    Game.Mario.SetSmall();
                }
            }
        }

        public class Big : ICommand
        {
            private Game1 Game;

            public Big(Game1 s2)
            {
                this.Game = s2;
            }

            public void Execute()
            {
                if (Game.DebugMode)
                {
                    Game.Mario.SetBig();
                }
            }
        }

        public class Fire : ICommand
        {
            private Game1 Game;

            public Fire(Game1 s2)
            {
                this.Game = s2;
            }

            public void Execute()
            {
                if (Game.DebugMode)
                {
                    Game.Mario.SetFire();
                }
            }
        }

        public class Damage : ICommand
        {
            private Game1 Game;

            public Damage(Game1 s2)
            {
                this.Game = s2;
            }

            public void Execute()
            {
                if (Game.DebugMode)
                {
                    Game.Mario.TakeDamage();
                }
            }
        }

        public class Kill : ICommand
        {
            private Game1 Game;

            public Kill(Game1 s2)
            {
                this.Game = s2;
            }

            public void Execute()
            {
                if (Game.DebugMode)
                {
                    Game.Mario.KillMario();
                }
            }
        }
        public class Star : ICommand
        {
            private Game1 Game;

            public Star(Game1 s2)
            {
                Game = s2;
            }

            public void Execute()
            {
                if (Game.DebugMode)
                {
                    if (Game.Mario is Mario)
                    {
                        Mario tempMario = (Mario)Game.Mario;
                        tempMario.AddStar();
                    }
                    else if (Game.Mario is StarMario)
                    {
                        StarMario tempMario = (StarMario)Game.Mario;
                        tempMario.RemoveStar();
                    }
                }
            }
        }
    }
}