using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IBlockState
    {
        bool BumpingBlock { get; set; }
        bool Breakable();
        IBlockSprite GetSprite();
        void SetBlock(IBlock block);
        void StoreItem(IItem item);
        void UseBlock(bool marioFacingLeft);
        void ProduceItem(bool marioFacingLeft);
        void BumpBlock();
        void Update();
    }
}
