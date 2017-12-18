using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class MarioBlockBottomCollision : ICommand
    {
        private Game1 Game;
        private ICollision Side;
        private IMario Mario;
        private IBlock Block;
        private Rectangle Collision;

        public MarioBlockBottomCollision(ICollision side , Game1 game)
        {
            Side = side;
            Mario = (IMario)Side.BottomOrRight;
            Block = (IBlock)Side.TopOrLeft;
            Collision = Side.Collision;
            Game = game;
        }
        public void Execute()
        {
            Mario.marioCanTransition = false;
            Mario.marioCanTransitionLeftPipe = false;
            if (Mario.Physics.YVelocity >= 0)
            {
                return;
            }
            Mario.Physics.YVelocity = 0;

            if (!(Block.State is HiddenBlockState) || Mario.State() == MarioStateMachine.MarioState.Jumping)
            {
                if (MarioCanKillBrickBlock())
                {
                    CreateBlockExplosion();
                }
                Block.UseBlock(Mario.FacingLeft());
                MoveMario();
            }
            if(Block.State is QuestionBlockState)
            {
                Game.trophy.found = true;
            }

            Game.RumbleHelper.Rumble(PlayerIndex.One, Game.RumbleHelper.LowRumble, Game.RumbleHelper.LowRumble, Game.RumbleHelper.QuickRumble);
        }
        private void MoveMario()
        {
            Mario.SetPosition(new Vector2(Mario.DestinationRectangle.X, Mario.DestinationRectangle.Y + Collision.Height));
        }
        private bool MarioCanKillBrickBlock()
        {
            return Block.Breakable() && Mario.State() == MarioStateMachine.MarioState.Jumping && (Mario.Size() == MarioStateMachine.MarioSize.Big || Mario.Size() == MarioStateMachine.MarioSize.Fire);
        }
        private void CreateBlockExplosion()
        {
            ItemBlockSoundBoard.Instance.PlayBlockBreak();
            Block.BeRemoved = true;
            Game.st.BreakBlock();
            ScoreAssignments sa = new ScoreAssignments();
            Game.UI.DisplayScore(sa.BrickBlock,Block.Location);
            BlockExplosionPiece piece1 = (BlockExplosionPiece)ObjectSpriteFactory.Instance.GetBlockExplosion(Block.Location, Block.Color);
            BlockExplosionPiece piece2 = (BlockExplosionPiece)ObjectSpriteFactory.Instance.GetBlockExplosion(Block.Location, Block.Color);
            BlockExplosionPiece piece3 = (BlockExplosionPiece)ObjectSpriteFactory.Instance.GetBlockExplosion(Block.Location, Block.Color);
            BlockExplosionPiece piece4 = (BlockExplosionPiece)ObjectSpriteFactory.Instance.GetBlockExplosion(Block.Location, Block.Color);
            piece1.ExplodeTopLeft();
            piece2.ExplodeTopRight();
            piece3.ExplodeBottomLeft();
            piece4.ExplodeBottomRight();
            Game.backGround.Add(piece1);
            Game.backGround.Add(piece2);
            Game.backGround.Add(piece3);
            Game.backGround.Add(piece4);
        }
    }
}