using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class LevelEditor
    {
        private Game1 Game;
        private int objectIndex;
        private int maxObjects;
        private List<string> gameObjects;
        private IItem objItem;
        private Goomba objGoomba;
        private IKoopa objKoopa;
        private IBlock objBlock;

        public string GetObject
        {
            get{return gameObjects[objectIndex];}
        }
        public LevelEditor(Game1 game)
        {
            Game = game;
            objectIndex = 0;
            gameObjects = new List<string>();
            //Blocks
            gameObjects.Add("BrickBlock");
            gameObjects.Add("FloorBlock");
            gameObjects.Add("HardBlock");
            gameObjects.Add("QuestionBlock");
            gameObjects.Add("UsedBlock");
            //Items
            gameObjects.Add("Coin");
            gameObjects.Add("FireFlower");
            gameObjects.Add("Mushroom");
            gameObjects.Add("OneUp");
            gameObjects.Add("Star");
            //Enemies
            gameObjects.Add("Goomba");
            gameObjects.Add("Koopa");
            maxObjects = gameObjects.Count-1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game.DebugMode)
            {
                switch (GetObject)
                {
                    //Blocks
                    case "BrickBlock":
                        objBlock = new Block(new Vector2(0, 0), new BrickBlockState());
                        objBlock.draw(spriteBatch, Game.mouse.GetMousePosition, Color.White);
                        break;
                    case "FloorBlock":
                        objBlock = new Block(new Vector2(0, 0), new FloorBlockState());
                        objBlock.draw(spriteBatch, Game.mouse.GetMousePosition, Color.White);
                        break;
                    case "HardBlock":
                        objBlock = new Block(new Vector2(0, 0), new HardBlockState());
                        objBlock.draw(spriteBatch, Game.mouse.GetMousePosition, Color.White);
                        break;
                    case "QuestionBlock":
                        objBlock = new Block(new Vector2(0, 0), new QuestionBlockState());
                        objBlock.draw(spriteBatch, Game.mouse.GetMousePosition, Color.White);
                        break;
                    case "UsedBlock":
                        objBlock = new Block(new Vector2(0, 0), new UsedBlockState());
                        objBlock.draw(spriteBatch, Game.mouse.GetMousePosition, Color.White);
                        break;

                    //Items
                    case "Coin":
                        objItem = new Coin(new Vector2(0, 0));
                        objItem.draw(spriteBatch, Game.mouse.GetMousePosition);
                        break;
                    case "FireFlower":
                        objItem = new FireFlower(new Vector2(0, 0));
                        objItem.draw(spriteBatch, Game.mouse.GetMousePosition);
                        break;
                    case "Mushroom":
                        objItem = new Mushroom(new Vector2(0, 0));
                        objItem.draw(spriteBatch, Game.mouse.GetMousePosition);
                        break;
                    case "OneUp":
                        objItem = new OneUp(new Vector2(0, 0));
                        objItem.draw(spriteBatch, Game.mouse.GetMousePosition);
                        break;
                    case "Star":
                        objItem = new Star(new Vector2(0,0));
                        objItem.draw(spriteBatch, Game.mouse.GetMousePosition);
                        break;

                    //Enemies
                    case "Goomba":
                        objGoomba = new Goomba(new Vector2(0,0));
                        objGoomba.Draw(spriteBatch, Game.mouse.GetMousePosition, Color.White);
                        break;
                    case "Koopa":
                        objKoopa = new Koopa(new Vector2(0, 0));
                        objKoopa.Draw(spriteBatch, Game.mouse.GetMousePosition, Color.White);
                        break;
                    default:
                        break;
                }
            }
        }
        
        public void NextObject()
        {
            if (objectIndex == maxObjects)
            {
                objectIndex = 0;
            }else
            {
                objectIndex++;
            }
        }
        public void PreviousObject()
        {
            if(objectIndex == 0)
            {
                objectIndex = maxObjects;
            }else
            {
                objectIndex--;
            }
        }

    }
}
