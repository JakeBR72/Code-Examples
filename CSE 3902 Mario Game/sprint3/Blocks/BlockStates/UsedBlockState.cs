using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class UsedBlockState : IBlockState
    {
        private IItem storedItem;
        private IBlock block;
        private bool marioFacingLeft;
        public bool BumpingBlock { get; set; }
        public UsedBlockState()
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
            return BlockSpriteFactory.Instance.CreateUsedBlock(block.Location);
        }

        public void StoreItem(IItem item)
        {
            storedItem = item;
            item.IsCollidable = false;
            item.DontDraw();
        }

        public void UseBlock(bool MarioFacingLeft)
        {
            marioFacingLeft = MarioFacingLeft;
            if (storedItem is Coin) { ProduceItem(marioFacingLeft); }
        }

        public void ProduceItem(bool MarioFacingLeft)
        {
            marioFacingLeft = MarioFacingLeft;
            storedItem.ShouldUpdate = true;
            storedItem.GetProduced(marioFacingLeft);
            storedItem = new NullItem();
        }
        public void SetBlock(IBlock b)
        {
            this.block = b;
        }
        public void Update()
        {
            if (BumpingBlock)
            {
                CheckForEndOfBeingBumped();
            }
        }
        public void BumpBlock()
        {
            ItemBlockSoundBoard.Instance.PlayBlockBump();
            block.Physics.YVelocity = block.Physics.YMaxVelocity;
            BumpingBlock = true;
        }
        private void CheckForEndOfBeingBumped()
        {
            if (block.Location.Y >= block.Physics.MinPosition.Y)
            {
                block.Physics.YVelocity = 0;
                BumpingBlock = false;
                if (!(storedItem is Coin)) { ProduceItem(marioFacingLeft); }
            }
            else if (block.Location.Y <= block.Physics.MaxPosition.Y)
            {
                block.Physics.YVelocity = block.Physics.YMinVelocity;
            }
        }
    }
}
