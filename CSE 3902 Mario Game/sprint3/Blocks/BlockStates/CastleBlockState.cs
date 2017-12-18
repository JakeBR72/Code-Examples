﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class CastleBlockState : IBlockState
    {
        private IBlock block;
        public bool BumpingBlock { get; set; }

        public CastleBlockState()
        {
            BumpingBlock = false;
        }
        public bool Breakable()
        {
            return false;
        }
        public IBlockSprite GetSprite()
        {
            return BlockSpriteFactory.Instance.CreateCastleBlock(block.Location);
        }

        public void UseBlock(bool marioFacingLeft)
        {
        }

        public void ProduceItem(bool marioFacingLeft)
        {
        }

        public void StoreItem(IItem item)
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