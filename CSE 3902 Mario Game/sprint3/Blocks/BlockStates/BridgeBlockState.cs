
namespace MarioGame
{
    class BridgeBlockState : IBlockState
    {
        private IBlock block;
        public bool BumpingBlock { get; set; }

        public BridgeBlockState()
        {
            BumpingBlock = false;
        }
        public bool Breakable()
        {
            return false;
        }
        public IBlockSprite GetSprite()
        {
            return BlockSpriteFactory.Instance.CreateBridgeBlock(block.Location);
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
