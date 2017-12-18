﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class HardBlockState : IBlockState
    {
        private IBlock block;
        public bool BumpingBlock { get; set; }
        public HardBlockState()
        {
            BumpingBlock = false;
        }
        public bool Breakable()
        {
            return false;
        }
        public IBlockSprite GetSprite()
        {
            return BlockSpriteFactory.Instance.CreateHardBlock(block.Location);
        }

        public void StoreItem(IItem item)
        {
        }

        public void UseBlock(bool marioFacingLeft)
        {
        }

        public void ProduceItem(bool marioFacingLeft)
        {
        }
        public void BumpBlock()
        {

        }
        public void SetBlock(IBlock blocks)
        {
            this.block = blocks;
        }
        public void Update()
        {
        }
    }
}