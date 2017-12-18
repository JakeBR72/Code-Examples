namespace MarioGame
{
    public class ScoreTracker
    {
        public int Score { get; set; }
        public int Coins { get; set; }
        public int Lives { get; set; }
        public int ScoreMultiplier { get; set; }
        public bool IsComboJumping { get; set; }
        public bool StarCombo { get; set; }
        public bool jumper { get; set; }

        private ScoreAssignments SA = new ScoreAssignments();
        private int StartingLives = 3;
        private int BaseMultiplier = 2;
        private int MultiplicationFactor = 2;
        private int ScoreMultiplierCutoff = 32;
        private bool GiveFlagpolePoints;
        private bool GiveTimePoints;

        public ScoreTracker()
        {
            Score = 0;
            Coins = 0;
            Lives = StartingLives;
            IsComboJumping = false;
            StarCombo = false;
            ScoreMultiplier = BaseMultiplier;
            GiveFlagpolePoints = true;
            GiveTimePoints = false;
        }

        public void AddCoin()
        {
            Score += SA.Coin;
            Coins++;
        }

        public void ResetCoinCount()
        {
            Coins = 0;
        }

        public void AddLife()
        {
            Score += SA.PowerUp;
            Lives++;
        }

        public void LoseLife()
        {
            Lives--;
        }

        public void PowerUp()
        {
            Score += SA.PowerUp;
        }

        public void BreakBlock()
        {
            Score += SA.BrickBlock;
        }

        public void DefeatGoomba()
        {
            StompEnemy(SA.Goomba);
        }

        public void PiranaFire()
        {
            Score += SA.Pirana;
        }

        public void KoopaStomp()
        {
            StompEnemy(SA.KoopaStomp);
        }

        public void StompEnemy(int StompScore)
        {
            if (IsComboJumping || StarCombo)
            {
                if (ScoreMultiplier >= ScoreMultiplierCutoff)
                {
                    AddLife();
                    jumper = true;
                    ItemBlockSoundBoard.Instance.PlayOneUp();
                }
                else
                {
                    Score += StompScore * ScoreMultiplier;
                    ScoreMultiplier *= MultiplicationFactor;
                }
            }
            else
            {
                Score += StompScore;
                IsComboJumping = true;
            }
        }

        public void KoopaFire()
        {
            Score += SA.KoopaFire;
        }

        public void AllowFlagpolePoints()
        {
            GiveFlagpolePoints = true;
        }

        public void Flagpole(int level)
        {
            if (GiveFlagpolePoints)
            {
                switch (level)
                {
                    case 0:
                        Score += SA.FlagpoleLevelZero;
                        break;
                    case 1:
                        Score += SA.FlagpoleLevelOne;
                        break;
                    case 2:
                        Score += SA.FlagpoleLevelTwo;
                        break;
                    case 3:
                        Score += SA.FlagpoleLevelThree;
                        break;
                    case 4:
                        Score += SA.FlagpoleLevelFour;
                        break;
                    case 5:
                        Score += SA.FlagpoleLevelFive;
                        break;
                    default:
                        break;
                }
                GiveFlagpolePoints = false;
                GiveTimePoints = true;
            }
        }

        public void TimePoints(int RemainingTime)
        {
            if (GiveTimePoints)
            {
                Score += RemainingTime;
                GiveTimePoints = false;
            }
        }

        public void EndJumpingCombo()
        {
            IsComboJumping = false;
            if (!StarCombo)
                ScoreMultiplier = BaseMultiplier;
        }

        public void EnterStarCombo()
        {
            Score += SA.PowerUp;
            StarCombo = true;
        }

        public void EndStarCombo()
        {
            StarCombo = false;
            ScoreMultiplier = BaseMultiplier;
        }
    }
}
