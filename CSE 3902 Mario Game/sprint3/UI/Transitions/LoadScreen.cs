using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class LoadScreen
    {
        Game1 Game;
        int MarioLives;
        IMarioSprite mario;
        SpriteFont Font;
        string World;
        string OldWorld;
        public LoadScreen(Game1 game, int lives)
        {
            Game = game;
            MarioLives = lives;
            World = "";
            OldWorld = World;
        }
        public void Update()
        {
            World = Game.parser.GetLevel();
            if (World != OldWorld)
            {
                OldWorld = World;
            }
            MarioLives = Game.st.Lives;
        }
        public void Load(ContentManager content)
        {
            Font = content.Load<SpriteFont>("SMB");
            mario = MarioSpriteFactory.Instance.GetIdleSprite(MarioStateMachine.MarioSize.Small,false);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            Game.GraphicsDevice.Clear(Color.Black);

            spriteBatch.DrawString(Font, "WORLD", new Vector2(32 * 9, 120), Color.White);
            spriteBatch.DrawString(Font, World, new Vector2(32 * 13, 120), Color.White);

            spriteBatch.DrawString(Font, "x  " + MarioLives.ToString("D2"), new Vector2(32 * 12, 210), Color.White);

            spriteBatch.End();

            mario.Draw(spriteBatch, new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 5.0f), Game.MainCameraObject.DestinationRectangle.Y + (105)));
        }
        public void GameOver(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(Font, "GAME OVER", new Vector2(32 * 9, 210), Color.White);
            spriteBatch.End();
        }
        public void BlackScreen()
        {
            Game.GraphicsDevice.Clear(Color.Black);
        }
        public void TimeUp(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(Font, "Time Up", new Vector2(32 * 9, 210), Color.White);
            spriteBatch.End();
        }
    }
}
