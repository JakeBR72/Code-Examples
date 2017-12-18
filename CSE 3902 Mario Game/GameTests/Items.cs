using Microsoft.Xna.Framework;
using MarioGame;
using System.Collections.Generic;

namespace GameTests
{
    class Items
    {
        private Vector2 DefaultSpawn = new Vector2(250);
        public List<IGameObject> AllItems = new List<IGameObject>();

        public void Initialize()
        {
            IGameObject Mushroom = new Mushroom(DefaultSpawn);
            IGameObject FireFlower = new FireFlower(DefaultSpawn);
            IGameObject Coin = new Coin(DefaultSpawn);
            IGameObject OneUp = new OneUp(DefaultSpawn);
            IGameObject Star = new Star(DefaultSpawn);

            AllItems.Add(Mushroom);
            AllItems.Add(FireFlower);
            AllItems.Add(Coin);
            AllItems.Add(OneUp);
            AllItems.Add(Star);
        }
    }
}
