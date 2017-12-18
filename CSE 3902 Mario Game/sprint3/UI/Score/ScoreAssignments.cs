/*
    For scoring reference:
    http://themushroomkingdom.net/smb_breakdown.shtml
*/

namespace MarioGame
{
    class ScoreAssignments
    {
        public int Coin { get; set; }
        public int PowerUp { get; set; }
        public int BrickBlock { get; set; }
        public int Goomba { get; set; }
        public int Pirana { get; set; }
        public int KoopaStomp { get; set; }
        public int KoopaFire { get; set; }
        public int FlagpoleLevelZero { get; set; }
        public int FlagpoleLevelOne { get; set; }
        public int FlagpoleLevelTwo { get; set; }
        public int FlagpoleLevelThree { get; set; }
        public int FlagpoleLevelFour { get; set; }
        public int FlagpoleLevelFive { get; set; }


        public ScoreAssignments()
        {
            Coin = 200;
            BrickBlock = 50;
            PowerUp = 1000;
            Goomba = 100;
            KoopaStomp = 100;
            KoopaFire = 200;
            Pirana = 100;

            FlagpoleLevelZero = 5000;
            FlagpoleLevelOne = 2000;
            FlagpoleLevelTwo = 800;
            FlagpoleLevelThree = 400;
            FlagpoleLevelFour = 100;
            FlagpoleLevelFive = 50;
        }
    }
}
