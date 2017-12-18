using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class MarioUI
    {
        Game1 Game;
        SpriteFont Font;
        SpriteFont Font2;
        int Score;
        IItemSprite Coin;
        private Vector2 coinLocation;
        int Coins;
        public int Time { get; set; }
        string World;
        int TimeSinceLastFrame;
        bool startTimer = false;
        Collection<ScoreElement> scoreDisplay;
        public MarioUI(Game1 game)
        {
            Game = game;
            Score = Game.st.Score;
            Coins = Game.st.Coins;
            Time = 400;
            World = "";
            coinLocation = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 3.7f), Game.MainCameraObject.DestinationRectangle.Y + (14));
            scoreDisplay = new Collection<ScoreElement>();
        }
        public void Load(ContentManager content)
        {
            Font = content.Load<SpriteFont>("SMB");
            Font2 = content.Load<SpriteFont>("SMB2");

            Coin = ItemSpriteFactory.Instance.CreateCoin(coinLocation);
        }
        public void Update(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > 1000)
            {
                TimeSinceLastFrame -= 1000;
                if (startTimer)
                {
                    Time--;
                    if(Time < 100 && !MusicManager.Instance.currentSong.Contains("hurry"))
                    {
                        MusicManager.Instance.SetBackgroundMusic(MusicManager.Instance.
                            currentSong.Substring(0, MusicManager.Instance.currentSong.
                            IndexOf('-')) + "-hurry");
                    }
                }
            }
            Coin.update();
            Coins = Game.st.Coins;
            Score = Game.st.Score;
            World = Game.parser.GetLevel();
            coinLocation = new Vector2(Game.MainCameraObject.DestinationRectangle.X + (32 * 3.7f), Game.MainCameraObject.DestinationRectangle.Y + (14));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
                Coin.draw(spriteBatch, coinLocation);
                spriteBatch.Begin();
                if (Game.DebugMode)
                {
                    spriteBatch.DrawString(Font, "DEBUG MODE", new Vector2(32 * 2, 50), Color.White);
                }

                spriteBatch.DrawString(Font, "MARIO", new Vector2(32 * 2, 10), Color.White);
                spriteBatch.DrawString(Font, Score.ToString("D6"), new Vector2(32 * 2, 30), Color.White);

                spriteBatch.DrawString(Font, "x" + Coins.ToString("D2"), new Vector2(32 * 8, 30), Color.White);

                spriteBatch.DrawString(Font, "WORLD", new Vector2(32 * 14, 10), Color.White);
                spriteBatch.DrawString(Font, World, new Vector2(32 * 14, 30), Color.White);

                spriteBatch.DrawString(Font, "TIME", new Vector2(32 * 20, 10), Color.White);
                spriteBatch.DrawString(Font, Time.ToString("D3"), new Vector2(32 * 20, 30), Color.White);
                spriteBatch.End();
                DrawScores(spriteBatch);         
        }

        private void DrawScores(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
            foreach (ScoreElement se in scoreDisplay)
            {
                if (se.timer > 0)
                {
                    se.timer--;
                    spriteBatch.DrawString(Font2, se.Score.ToString(), se.Location, Color.White);
                }
            }
            spriteBatch.End();
        }

        public void StopTimer()
        {
            startTimer = false;
        }
        public void SetTimer(int time)
        {
            startTimer = true;
            Time = time;
        }
        public int getTime()
        {
            return Time;
        }
        public void DisplayScore(int score,Vector2 location)
        {
            scoreDisplay.Add(new ScoreElement(score, location));
        }
    }
}
