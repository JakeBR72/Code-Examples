using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class BlockSpriteFactory
    {
        Texture2D brickBlockTexture, floorBlockTexture, hardBlockTexture,
        questionBlockTexture, usedBlockTexture, castleBlockTexture, bridgeBlockTexture;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();
        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BlockSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            brickBlockTexture = content.Load<Texture2D>("brickBlock");
            floorBlockTexture = content.Load<Texture2D>("floorBlock");
            hardBlockTexture = content.Load<Texture2D>("hardBlock");
            questionBlockTexture = content.Load<Texture2D>("itemBlock");
            usedBlockTexture = content.Load<Texture2D>("usedBlock");
            castleBlockTexture = content.Load<Texture2D>("castleBlock");
            bridgeBlockTexture = content.Load<Texture2D>("bridgeBlock");
        }
        public IBlockSprite CreateHardBlock(Vector2 location)
        {
            IBlockSprite hardBlockSprite = new HardBlockSprite(hardBlockTexture);
            hardBlockSprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, hardBlockTexture.Width, hardBlockTexture.Height);
            return hardBlockSprite;
        }
        public IBlockSprite CreateUsedBlock(Vector2 location)
        {
            IBlockSprite usedBlockSprite = new UsedBlockSprite(usedBlockTexture);
            usedBlockSprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, usedBlockTexture.Width, usedBlockTexture.Height);
            return usedBlockSprite;
        }
        public IBlockSprite CreateQuestionBlock(Vector2 location)
        {
            IBlockSprite questionBlockSprite = new QuestionBlockSprite(questionBlockTexture, 3);
            questionBlockSprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, questionBlockTexture.Width, questionBlockTexture.Height);
            return questionBlockSprite;
        }
        public IBlockSprite CreateBrickBlock(Vector2 location)
        {
            IBlockSprite brickBlockSprite = new BrickBlockSprite(brickBlockTexture);
            brickBlockSprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, brickBlockTexture.Width, brickBlockTexture.Height);
            return brickBlockSprite;
        }
        public IBlockSprite CreateFloorBlock(Vector2 location)
        {
            IBlockSprite floorBlockSprite = new FloorBlockSprite(floorBlockTexture);
            floorBlockSprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, floorBlockTexture.Width, floorBlockTexture.Height);
            return floorBlockSprite;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public IBlockSprite CreateInvisbleBlock(Vector2 location)
        {
            IBlockSprite invBlockSprite = new InvisibleSprite(brickBlockTexture);
            invBlockSprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, brickBlockTexture.Width, brickBlockTexture.Height);
            return invBlockSprite;
        }
        public IBlockSprite CreateCastleBlock(Vector2 location)
        {
            IBlockSprite castleBlockSprite = new CastleBlockSprite(castleBlockTexture);
            castleBlockSprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, castleBlockTexture.Width, castleBlockTexture.Height);
            return castleBlockSprite;
        }
        public IBlockSprite CreateBridgeBlock(Vector2 location)
        {
            IBlockSprite bridgeBlockSprite = new BridgeBlockSprite(bridgeBlockTexture);
            bridgeBlockSprite.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, castleBlockTexture.Width, castleBlockTexture.Height);
            return bridgeBlockSprite;
        }
    }
}
