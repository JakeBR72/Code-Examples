using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioOneUpCollision : ICommand
    {
        private Game1 Game;
        private IItem OneUp;

        public MarioOneUpCollision(ICollision Side, Game1 game)
        {
            Game = game;
            if (Side.BottomOrRight is IItem)
            {
                OneUp = (IItem)Side.BottomOrRight;
            }
            else
            {
                OneUp = (IItem)Side.TopOrLeft;
            }
        }

        public void Execute()
        {
            OneUp.BeRemoved = true;
            ItemBlockSoundBoard.Instance.PlayOneUp();
            Game.st.AddLife();
        }
    }
}
