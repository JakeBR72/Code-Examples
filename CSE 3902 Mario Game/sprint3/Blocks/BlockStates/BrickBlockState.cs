using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class BrickBlockState : IBlockState
    {

        private Queue<IItem> storedItems;
        private IBlock block;
        private bool marioFacingLeft;
        public bool BumpingBlock { get; set; }
        public BrickBlockState()
        {
            storedItems = new Queue<IItem>();
            BumpingBlock = false;
        }
        public bool Breakable()
        {
            return storedItems.Count == 0;
        }
        public IBlockSprite GetSprite()
        {
            return BlockSpriteFactory.Instance.CreateBrickBlock(block.Location);
        }

        public void StoreItem(IItem item)
        {
            item.IsCollidable = false;
            item.DontDraw();
            storedItems.Enqueue(item);
        }

        public void UseBlock(bool MarioFacingLeft)
        {
            marioFacingLeft = MarioFacingLeft;
            BumpBlock();
        }

        public void ProduceItem(bool MarioFacingLeft)
        {
            marioFacingLeft = MarioFacingLeft;
            if (storedItems.Count != 0)
            {
                IItem item = storedItems.Dequeue();
                item.GetProduced(marioFacingLeft);
                if (storedItems.Count == 0)
                {
                    IBlockState state = new UsedBlockState();
                    state.StoreItem(item);
                    state.SetBlock(block);
                    block.State = state;
                    block.setSpriteFromState();
                    block.State.UseBlock(marioFacingLeft);
                    block.State.BumpBlock();
                }
            }
        }
        public void SetBlock(IBlock blocks)
        {
            this.block = blocks;
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
            if (storedItems.Count != 0)
            {
                block.BeRemoved = false;
                if (storedItems.ElementAt(0) is Coin) { ProduceItem(marioFacingLeft); }
            }
        }
        private void CheckForEndOfBeingBumped()
        {
            if (block.Location.Y >= block.Physics.MinPosition.Y)
            {
                block.Physics.YVelocity = 0;
                BumpingBlock = false;
                if (storedItems.Count > 0 && !(storedItems.ElementAt(0) is Coin))
                {
                    ProduceItem(marioFacingLeft);
                }
            }
            else if (block.Location.Y <= block.Physics.MaxPosition.Y)
            {
                block.Physics.YVelocity = block.Physics.YMinVelocity;
            }
        }
    }
}
