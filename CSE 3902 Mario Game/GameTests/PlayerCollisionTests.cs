using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using MarioGame;
using System.Diagnostics;
using System.Collections.Generic;

namespace GameTests
{
    [TestClass]
    public class PlayerCollisionTests
    {
        private Game1 GameDummy = null;
        private Blocks Blocks = new Blocks();
        private Enemies Enemies = new Enemies();
        private Items Items = new Items();

        private int DefaultSize = 50;
        public Vector2 DefaultSpawn = new Vector2(250);
        private Vector2 LeftSpawn = new Vector2(240, 250);
        private Vector2 RightSpawn = new Vector2(260, 250);
        private Vector2 UpperSpawn = new Vector2(250, 240);
        private Vector2 LowerSpawn = new Vector2(250, 260);

        IGameObject Player;

        private bool TestCollisionFromDirection(List<IGameObject> GameObjects, Vector2 PlayerSpawnLocation)
        {
            bool PassTest = true;
            Player = new Mario(DefaultSpawn, GameDummy);
            ICollision Side = new NullCollision();

            foreach (IGameObject GameObject in GameObjects)
            {
                Player.DestinationRectangle = new Rectangle((int)PlayerSpawnLocation.X, (int)PlayerSpawnLocation.Y, DefaultSize, DefaultSize);
                GameObject.DestinationRectangle = new Rectangle((int)DefaultSpawn.X, (int)DefaultSpawn.Y, DefaultSize, DefaultSize);
                Side = CollisionDetector.detectCollision(Player, GameObject);

                if (PlayerSpawnLocation.Equals(UpperSpawn))
                {
                    if (Side is NullCollision || !(Side is Top))
                    {
                        PassTest = false;
                        Debug.WriteLine("Error: Object " + GameObject.ToString() + "'s collision type was " + Side.ToString() + ", expected Top");
                    }
                } else if (PlayerSpawnLocation.Equals(LowerSpawn))
                {
                    if (Side is NullCollision || !(Side is Bottom))
                    {
                        PassTest = false;
                        Debug.WriteLine("Error: Object " + GameObject.ToString() + "'s collision type was " + Side.ToString() + ", expected Bottom");
                    }

                } else if (PlayerSpawnLocation.Equals(LeftSpawn))
                {
                    if (Side is NullCollision || !(Side is Left))
                    {
                        PassTest = false;
                        Debug.WriteLine("Error: Object " + GameObject.ToString() + "'s collision type was " + Side.ToString() + ", expected Left");
                    }

                } else if (PlayerSpawnLocation.Equals(RightSpawn))
                {
                    if (Side is NullCollision || !(Side is Right))
                    {
                        PassTest = false;
                        Debug.WriteLine("Error: Object " + GameObject.ToString() + "'s collision type was " + Side.ToString() + ", expected Right");
                    }

                } else
                {
                    PassTest = false;
                    Debug.WriteLine("Error: Invalid collision direction");
                }
            }

            return PassTest;
        }

        [TestMethod]
        public void TestPlayerBlockCollision()
        {
            Blocks.Initialize();

            bool PassCollisionFromAbove = TestCollisionFromDirection(Blocks.AllBlocks, UpperSpawn);
            bool PassCollisionFromBelow = TestCollisionFromDirection(Blocks.AllBlocks, LowerSpawn);
            bool PassCollisionFromLeft = TestCollisionFromDirection(Blocks.AllBlocks, LeftSpawn);
            bool PassCollisionFromRight = TestCollisionFromDirection(Blocks.AllBlocks, RightSpawn);

            Assert.IsTrue(PassCollisionFromAbove && PassCollisionFromBelow && PassCollisionFromLeft && PassCollisionFromRight);
        }

        [TestMethod]
        public void TestPlayerEnemyCollision()
        {
            Enemies.Initialize();

            bool PassCollisionFromAbove = TestCollisionFromDirection(Enemies.AllEnemies, UpperSpawn);
            bool PassCollisionFromBelow = TestCollisionFromDirection(Enemies.AllEnemies, LowerSpawn);
            bool PassCollisionFromLeft = TestCollisionFromDirection(Enemies.AllEnemies, LeftSpawn);
            bool PassCollisionFromRight = TestCollisionFromDirection(Enemies.AllEnemies, RightSpawn);

            Assert.IsTrue(PassCollisionFromAbove && PassCollisionFromBelow && PassCollisionFromLeft && PassCollisionFromRight);
        }

        [TestMethod]
        public void TestPlayerItemCollision()
        {
            Items.Initialize();

            bool PassCollisionFromAbove = TestCollisionFromDirection(Items.AllItems, UpperSpawn);
            bool PassCollisionFromBelow = TestCollisionFromDirection(Items.AllItems, LowerSpawn);
            bool PassCollisionFromLeft = TestCollisionFromDirection(Items.AllItems, LeftSpawn);
            bool PassCollisionFromRight = TestCollisionFromDirection(Items.AllItems, RightSpawn);

            Assert.IsTrue(PassCollisionFromAbove && PassCollisionFromBelow && PassCollisionFromLeft && PassCollisionFromRight);
        }
    }
}
