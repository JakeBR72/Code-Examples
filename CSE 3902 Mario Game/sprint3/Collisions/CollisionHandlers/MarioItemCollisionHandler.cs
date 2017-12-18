using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioItemCollisionHandler : ICollisionHandler
    {
        private ICollision Side;
        private IItem Item;
        private Game1 Game;

        public MarioItemCollisionHandler(ICollision side, Game1 g)
        {
            Side = side;
            Game = g;
            if (Side.TopOrLeft is IItem)
            {
                Item = (IItem)Side.TopOrLeft;
            }
            else
            {
                Item = (IItem)Side.BottomOrRight;
            }
        }
        public void handleCollision()
        {
            ICommand Command;
            if (Item is Coin)
            {
                Command = new MarioCoinCollision(Side);
                Command.Execute();
            }
            else if (Item is FireFlower)
            {
                Command = new MarioFireFlowerCollision(Side, Game);
                Command.Execute();
            }
            else if (Item is Mushroom)
            {
                Command = new MarioMushroomCollision(Side, Game);
                Command.Execute();
            }
            else if (Item is OneUp)
            {
                Command = new MarioOneUpCollision(Side, Game);
                Command.Execute();
            }
            else if (Item is Star)
            {
                Command = new MarioStarCollision(Side, Game);
                Command.Execute();
            }
        }
    }
}
