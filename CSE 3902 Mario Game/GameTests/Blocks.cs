using Microsoft.Xna.Framework;
using MarioGame;
using System.Collections.Generic;

namespace GameTests
{
    class Blocks
    {
        private Vector2 DefaultSpawn = new Vector2(250);
        public List<IGameObject> AllBlocks = new List<IGameObject>();
        
        public void Initialize()
        {
            IGameObject Brick = new Block(DefaultSpawn, new BrickBlockState());
            IGameObject Floor = new Block(DefaultSpawn, new FloorBlockState());
            IGameObject Hard = new Block(DefaultSpawn, new HardBlockState());
            IGameObject Question = new Block(DefaultSpawn, new QuestionBlockState());
            IGameObject Used = new Block(DefaultSpawn, new UsedBlockState());

            AllBlocks.Add(Brick);
            AllBlocks.Add(Floor);
            AllBlocks.Add(Hard);
            AllBlocks.Add(Question);
            AllBlocks.Add(Used);
        }
    }
}
