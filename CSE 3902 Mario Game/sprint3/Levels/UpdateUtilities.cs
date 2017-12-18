using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MarioGame
{
    public static class UpdateUtilities
    {
        public static void UpdateWithThreads(Game1 game)
        {
            Thread goombasThread = new Thread(() => UpdateGoombas(game));
            Thread koopasThread = new Thread(() => UpdateKoopas(game));
            Thread piranasThread = new Thread(() => UpdatePiranas(game));
            Thread blocksThread = new Thread(() => UpdateBlocks(game));
            Thread bowserThread = new Thread(() => UpdateBowser(game));
            Thread itemsThread = new Thread(() => UpdateItems(game));
            Thread objectsThread = new Thread(() => UpdateObjects(game));
            Thread backgroundThread = new Thread(() => UpdateBackground(game));

            goombasThread.Start();
            koopasThread.Start();
            piranasThread.Start();
            blocksThread.Start();
            bowserThread.Start();
            itemsThread.Start();
            objectsThread.Start();
            backgroundThread.Start();

            goombasThread.Join();
            koopasThread.Join();
            piranasThread.Join();
            blocksThread.Join();
            bowserThread.Join();
            itemsThread.Join();
            objectsThread.Join();
            backgroundThread.Join();
        }
        public static void UpdateWithoutThreads(Game1 game)
        {
            UpdateGoombas(game);
            UpdateKoopas(game);
            UpdatePiranas(game);
            UpdateBlocks(game);
            UpdateBowser(game);
            UpdateItems(game);
            UpdateObjects(game);
            UpdateBackground(game);
        }

        public static void UpdateGoombas(Game1 game)
        {
            for (int i = 0; i < game.goombaList.Count; i++)
            {
                if (game.goombaList.ElementAt(i).BeRemoved)
                {
                    game.trophy.killedGoomba = true;
                    game.goombaList.RemoveAt(i);
                    i--;
                }
                else
                {
                    game.goombaList.ElementAt(i).Update();
                }
            }
        }

        public static void UpdateKoopas(Game1 game)
        {
            for (int i = 0; i < game.koopaList.Count; i++)
            {
                if (game.koopaList.ElementAt(i).BeRemoved)
                {
                    game.koopaList.RemoveAt(i);
                    i--;
                }
                else
                {
                    game.koopaList.ElementAt(i).Update();
                }
            }
        }
        public static void UpdatePiranas(Game1 game)
        {
            for (int i = 0; i < game.piranaPlantList.Count; i++)
            {
                if (game.piranaPlantList.ElementAt(i).BeRemoved)
                {
                    game.piranaPlantList.RemoveAt(i);
                    i++;
                }
                else
                {
                    game.piranaPlantList.ElementAt(i).Update();
                }
            }
        }

        public static void UpdateBlocks(Game1 game)
        {
            for (int i = 0; i < game.blocks.Count; i++)
            {
                if (game.blocks.ElementAt(i).BeRemoved)
                {
                    game.blocks.RemoveAt(i);
                    i--;
                }
                else
                {
                    game.blocks.ElementAt(i).update();
                }
            }
        }

        public static void UpdateBowser(Game1 game)
        {
            for (int i = 0; i < game.bowserList.Count; i++)
            {
                if (game.bowserList.ElementAt(i).BeRemoved)
                {
                    game.bowserList.RemoveAt(i);
                    i--;
                }
                else
                {
                    game.bowserList.ElementAt(i).Update();
                }
            }
        }

        public static void UpdateItems(Game1 game)
        {
            for (int i = 0; i < game.items.Count; i++)
            {
                if (game.items.ElementAt(i).BeRemoved)
                {
                    Vector2 location = game.items.ElementAt(i).Location;
                    if (game.items.ElementAt(i) is Coin)
                    {
                        game.UI.DisplayScore(200, location);
                        ItemBlockSoundBoard.Instance.PlayCoinCollect();
                        game.st.AddCoin();

                        if (game.st.Coins > 99)
                        {
                            game.st.ResetCoinCount();
                            game.st.AddLife();
                            ItemBlockSoundBoard.Instance.PlayOneUp();
                        }
                    }
                    game.items.RemoveAt(i);
                    i--;
                }
                else
                {
                    game.items.ElementAt(i).update();
                }
            }
        }

        public static void UpdateObjects(Game1 game)
        {
            for (int i = 0; i < game.objects.Count; i++)
            {
                if (game.objects[i] is Fireball)
                {
                    Fireball fb = (Fireball)game.objects[i];
                    if (fb.fireBallJump >= 15 || fb.Location.Y > 224 || fb.collisionBlock || fb.collisionPipe || fb.collisionEnemy)
                    {
                        game.objects.RemoveAt(i);
                    }
                    else
                    {
                        game.objects.ElementAt(i).Update();
                    }
                }
                else
                {
                    game.objects.ElementAt(i).Update();
                }
            }
        }

        public static void UpdateBackground(Game1 game)
        {
            for (int i = 0; i < game.backGround.Count; i++)
            {
                if (game.backGround.ElementAt(i).BeRemoved)
                {
                    game.backGround.RemoveAt(i);
                    i--;
                }
                else
                {
                    game.backGround.ElementAt(i).Update();
                }
            }
        }
    }
}
