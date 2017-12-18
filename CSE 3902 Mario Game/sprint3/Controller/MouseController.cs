using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace MarioGame
{
    public class MouseController : IController
    {
        private Game1 Game;
        private MouseState CurrentState;
        private bool m1Down;
        private bool m2Down;
        private int oldScrollWheelValue;
        private string selected;
        private Vector2 ClickLocation;
        public Vector2 GetMousePosition
        {
            get {return ClickLocation;}
        }

        public MouseController(Game1 game)
        {
            Game = game;
        }

        public void Update(GameTime gameTime)
        {
            if (Game.DebugMode)
            {
                CurrentState = Mouse.GetState();
                ClickLocation = Game.MainCameraObject.DestinationRectangle.Location.ToVector2() + CurrentState.Position.ToVector2() / 2;
                ClickLocation.X = (int)(ClickLocation.X / 16) * 16;
                ClickLocation.Y = (int)(ClickLocation.Y / 16) * 16;
                if (!m1Down && CurrentState.LeftButton == ButtonState.Pressed)
                {
                    m1Down = true;
                    selected = Game.editor.GetObject;
                    RemoveObject();
                    CreateObject();
                    if (Game.trophy.placer < 11)
                    {
                        Game.trophy.placer++;
                    }
                }
                else if (CurrentState.LeftButton == ButtonState.Released)
                {
                    m1Down = false;
                }
                if (!m2Down && CurrentState.RightButton == ButtonState.Pressed)
                {
                    RemoveObject();
                    m2Down = true;
                }
                else if (CurrentState.RightButton == ButtonState.Released)
                {
                    m2Down = false;
                }
                if (CurrentState.ScrollWheelValue > oldScrollWheelValue)
                {
                    Game.editor.NextObject();
                    oldScrollWheelValue = CurrentState.ScrollWheelValue;
                }
                if (CurrentState.ScrollWheelValue < oldScrollWheelValue)
                {
                    Game.editor.PreviousObject();
                    oldScrollWheelValue = CurrentState.ScrollWheelValue;
                }
            }
        }

        private void CreateObject()
        {
            RemoveObject();
            switch (selected)
            {
                //Blocks
                case "BrickBlock":
                    Game.blocks.Add(new Block(ClickLocation, new BrickBlockState()));
                    break;
                case "FloorBlock":
                    Game.blocks.Add(new Block(ClickLocation, new FloorBlockState()));
                    break;
                case "HardBlock":
                    Game.blocks.Add(new Block(ClickLocation, new HardBlockState()));
                    break;
                case "QuestionBlock":
                    Game.blocks.Add(new Block(ClickLocation, new QuestionBlockState()));
                    break;
                case "UsedBlock":
                    Game.blocks.Add(new Block(ClickLocation, new UsedBlockState()));
                    break;
                //Items
                case "Coin":
                    Game.items.Add(new Coin(ClickLocation));
                    break;
                case "FireFlower":
                    Game.items.Add( new FireFlower(ClickLocation));
                    break;
                case "Mushroom":
                    Game.items.Add(new Mushroom(ClickLocation));
                    break;
                case "OneUp":
                    Game.items.Add(new OneUp(ClickLocation));
                    break;
                case "Star":
                    Game.items.Add(new Star(ClickLocation));
                    break;
                //Enemies
                case "Goomba":
                    Game.goombaList.Add(new Goomba(ClickLocation));
                    break;
                case "Koopa":
                    Game.koopaList.Add(new Koopa(ClickLocation));
                    break;


                default:
                    break;
            }
        }

        private void RemoveObject()
        {
            foreach (IBlock block in Game.blocks)
            {
                if (block.Location == ClickLocation)
                {
                    block.BeRemoved = true;
                }
            }
            foreach (IItem item in Game.items)
            {
                if (item.Location == ClickLocation)
                {
                    item.BeRemoved = true;
                }
            }
            foreach (IObject obj in Game.objects)
            {
                if (obj.Location == ClickLocation)
                {
                    obj.BeRemoved = true;
                }
            }
            foreach (Goomba goomba in Game.goombaList)
            {
                if (goomba.Location.X < ClickLocation.X+8 && goomba.Location.X > ClickLocation.X - 8)
                {
                    if (goomba.Location.Y < ClickLocation.Y + 8 && goomba.Location.Y > ClickLocation.Y - 8)
                    {
                        goomba.BeRemoved = true;
                    }
                }
            }
            foreach (IKoopa koopa in Game.koopaList)
            {
                if (koopa.Location.X < ClickLocation.X + 8 && koopa.Location.X > ClickLocation.X - 8)
                {
                    if (koopa.Location.Y < ClickLocation.Y + 8 && koopa.Location.Y > ClickLocation.Y - 8)
                    {
                        koopa.BeRemoved = true;
                    }
                }
            }
        }
    }
}
