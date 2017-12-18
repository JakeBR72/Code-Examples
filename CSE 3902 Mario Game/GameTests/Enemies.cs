using Microsoft.Xna.Framework;
using MarioGame;
using System.Collections.Generic;

namespace GameTests
{
    class Enemies
    {
        private Vector2 DefaultSpawn = new Vector2(250);
        public List<IGameObject> AllEnemies = new List<IGameObject>();

        public void Initialize()
        {
            IGameObject Goomba = new Koopa(DefaultSpawn);
            IGameObject Koopa = new Koopa(DefaultSpawn);

            AllEnemies.Add(Goomba);
            AllEnemies.Add(Koopa);
        }
    }
}
