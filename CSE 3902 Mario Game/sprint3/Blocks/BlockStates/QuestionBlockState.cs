﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class QuestionBlockState : IBlockState
    {
        private IItem storedItem;
        private IBlock block;
        public bool BumpingBlock { get; set; }
        public QuestionBlockState()
        {
            storedItem = new NullItem();
            BumpingBlock = false;
        }
        public bool Breakable()
        {
            return false;
        }
        public IBlockSprite GetSprite()
        {
            return BlockSpriteFactory.Instance.CreateQuestionBlock(block.Location);
        }

        public void StoreItem(IItem item)
        {
            storedItem = item;
            item.IsCollidable = false;
            item.DontDraw();
        }

        public void UseBlock(bool marioFacingLeft)
        {
            IBlockState state = new UsedBlockState();
            state.StoreItem(storedItem);
            state.SetBlock(block);
            block.State = state;
            block.setSpriteFromState();
            block.State.UseBlock(marioFacingLeft);
            block.State.BumpBlock();
        }

        public void ProduceItem(bool marioFacingLeft)
        {
        }
        public void BumpBlock()
        {

        }
        public void SetBlock(IBlock b)
        {
            this.block = b;
        }
        public void Update()
        {
        }
    }
}