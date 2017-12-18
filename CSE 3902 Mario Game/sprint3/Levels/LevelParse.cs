using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace MarioGame
{
    /*
     * Parser reference guide:
     * ma = mario, bc = big cloud, fb = floor block,
     * lc = little cloud, mp = medium pipe, sp = small pipe,
     * tp = tall pipe, bm = big mountain, lm = little mountain,
     * lb = large bush, sb = small bush, ca = castle,
     * db = dark block, ib = item block, ub = used block,
     * bb = brick block, hb = hidden block, ff =fire flower,
     * st = star, cn = coin, ou =one up, gb = goomba,
     * kp = koopa, ms = mushroom, '__' = nothing, fp = flagpole
     * zb = castle block, bs = Bowser, lv = lava tile, lw = lava wave
     * ty = Thank you Mario, td = Toad, ta = Bridge Block, tc = Bridge End
     * ax = Axe
    */
    
    public class LevelParse
    {
        private Game1 game;
        private SpriteBatch spriteBatch;
        Color shade;
        Castle castle;
        public LevelParse(string csvFile, Game1 game1, SpriteBatch SpriteBatch)
        {
            game1.curLevel = csvFile;
            game = game1;
            spriteBatch = SpriteBatch;
            if (csvFile.Contains("Underground"))
            {
                shade = Color.Cyan;
                MusicManager.Instance.SetBackgroundMusic("underground-theme");
            } else if (csvFile.Contains("Four"))
            {
                shade = Color.White;
                MusicManager.Instance.SetBackgroundMusic("castle-theme");
            }
            else
            {
                shade = Color.White;
                MusicManager.Instance.SetBackgroundMusic("main-theme");
            }
        }

        public void LevelParser()
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
            StreamReader reader = new StreamReader(game.curLevel);
            int yCounter = 0;
            int pixel = 16;
            try
            {
                string newLine;
                while ((newLine = reader.ReadLine()) != null)
                {
                    
                    String[] sprites = newLine.Split(',');
                    int xCounter = 0;
                    foreach (string s in sprites)
                    {
                        if (s.Equals("__"))
                        {
                            //do nothing, better than iterating through everything else
                        }
                        else if (s.Equals("ma"))
                        {
                            game.Mario = new Mario(new Vector2(xCounter * pixel, yCounter * pixel), game);
                            game.Mario.Draw(spriteBatch);
                        }
                        else if (s.Equals("bc"))
                        {
                            IObject bc = ObjectSpriteFactory.Instance.GetBigCloud();
                            bc.Draw(spriteBatch, new Vector2((xCounter * pixel) - 64, ((yCounter + 1) * pixel) - 24));
                            bc.isWarpPipe = false;
                            bc.isExitPipe = false;
                            game.backGround.Add(bc);

                        }
                        else if (s.Equals("fb"))
                        {
                            game.blocks.Add(new Block(new Vector2(xCounter * pixel, yCounter * pixel), new FloorBlockState()));
                        }
                        else if (s.Equals("lc"))
                        {
                            IObject lc = ObjectSpriteFactory.Instance.GetLittleCloud();
                            lc.Draw(spriteBatch, new Vector2((xCounter * pixel) - 32, ((yCounter + 1) * pixel) - 24));
                            lc.isWarpPipe = false;
                            lc.isExitPipe = false;
                            game.backGround.Add(lc);

                        }
                        else if (s.Equals("mp"))
                        {
                            IObject mp = ObjectSpriteFactory.Instance.GetMedPipe();
                            mp.Draw(spriteBatch, new Vector2((xCounter * pixel) - 32, ((yCounter + 1) * pixel) - 48));
                            mp.isWarpPipe = false;
                            mp.isExitPipe = false;
                            game.objects.Add(mp);

                        }
                        else if (s.Equals("sp"))
                        {
                            IObject sp = ObjectSpriteFactory.Instance.GetSmallPipe();
                            sp.Draw(spriteBatch, new Vector2((xCounter * pixel) - 32, ((yCounter + 1) * pixel) - 32));
                            sp.isWarpPipe = false;
                            sp.isExitPipe = false;
                            game.objects.Add(sp);

                        }
                        else if (s.Equals("tp"))
                        {
                            IObject tp = ObjectSpriteFactory.Instance.GetTallPipe();
                            tp.Draw(spriteBatch, new Vector2((xCounter * pixel) - 32, ((yCounter + 1) * pixel) - 64));
                            tp.isWarpPipe = false;
                            tp.isExitPipe = false;
                            game.objects.Add(tp);

                        }
                        else if (s.Equals("pr"))
                        {
                            game.piranaPlantList.Add(new PiranaPlant(new Vector2((xCounter * pixel)-24, (yCounter*pixel)-20)));
                        }
                        else if (s.Equals("bm"))
                        {
                            IObject bm = ObjectSpriteFactory.Instance.GetBigMountain();
                            bm.Draw(spriteBatch, new Vector2((xCounter * pixel) - 80, ((yCounter + 1) * pixel) - 35));
                            bm.isWarpPipe = false;
                            bm.isExitPipe = false;
                            game.backGround.Add(bm);

                        }
                        else if (s.Equals("lm"))
                        {
                            IObject lm = ObjectSpriteFactory.Instance.GetSmallMountain();
                            lm.Draw(spriteBatch, new Vector2((xCounter * pixel) - 48, ((yCounter + 1) * pixel) - 19));
                            lm.isWarpPipe = false;
                            lm.isExitPipe = false;
                            game.backGround.Add(lm);

                        }
                        else if (s.Equals("lb"))
                        {
                            IObject lb = ObjectSpriteFactory.Instance.GetBigBush();
                            lb.Draw(spriteBatch, new Vector2((xCounter * pixel) - 64, ((yCounter + 1) * pixel) - 16));
                            lb.isWarpPipe = false;
                            lb.isExitPipe = false;
                            game.backGround.Add(lb);

                        }else if(s.Equals("el"))
                        {
                            IObject el = ObjectSpriteFactory.Instance.GetElevator();
                            el.Draw(spriteBatch, new Vector2((xCounter * pixel), ((yCounter)) * pixel));
                            el.isWarpPipe = false;
                            el.isExitPipe = false;
                            game.objects.Add(el);
                        }
                        else if (s.Equals("sb"))
                        {
                            IObject sb = ObjectSpriteFactory.Instance.GetSmallBush();
                            sb.Draw(spriteBatch, new Vector2((xCounter * pixel) - 32, ((yCounter + 1) * pixel) - 16));
                            sb.isWarpPipe = false;
                            sb.isExitPipe = false;
                            game.backGround.Add(sb);

                        }
                        else if (s.Equals("ca"))
                        {
                            IObject ca = ObjectSpriteFactory.Instance.GetCastle();
                            ca.Draw(spriteBatch, new Vector2((xCounter * pixel) - 80, ((yCounter + 1) * pixel) - 128));
                            ca.isWarpPipe = false;
                            ca.isExitPipe = false;
                            game.objects.Add(ca);
                            castle = (Castle)ca;
                            
                        }
                        else if(s.Equals("wp"))
                        {
                            IObject wp = ObjectSpriteFactory.Instance.GetTallPipe();
                            wp.Draw(spriteBatch, new Vector2((xCounter * pixel) - 32, ((yCounter + 1) * pixel) - 64));
                            wp.isWarpPipe = true;
                            wp.isExitPipe = false;
                            game.objects.Add(wp);
                        }
                        else if (s.Equals("lp"))
                        {
                            IObject pi = ObjectSpriteFactory.Instance.GetPiping();
                            IObject lp = ObjectSpriteFactory.Instance.GetLPipe();
                            pi.Draw(spriteBatch, new Vector2((xCounter * pixel) + 4, ((yCounter + 1) * pixel) - 128));
                            lp.Draw(spriteBatch, new Vector2((xCounter * pixel) - 30, ((yCounter + 1) * pixel) - 33));
                            lp.isWarpPipe = true;
                            lp.isExitPipe = false;
                            pi.isWarpPipe = false;
                            pi.isExitPipe = false;                  
                            game.objects.Add(pi);
                            game.objects.Add(lp);
                        }
                        else if (s.Equals("pp"))
                        {
                            IObject pp = ObjectSpriteFactory.Instance.GetSmallPipe();
                            pp.Draw(spriteBatch, new Vector2((xCounter * pixel) - 32, ((yCounter + 1) * pixel) - 32));
                            pp.isWarpPipe = true;
                            pp.isExitPipe = false;
                            game.objects.Add(pp);
                        }
                        else if (s.Equals("ep"))
                        {
                            IObject ep = ObjectSpriteFactory.Instance.GetSmallPipe();
                            ep.Draw(spriteBatch, new Vector2((xCounter * pixel) - 32, ((yCounter + 1) * pixel) - 32));
                            ep.isWarpPipe = false;
                            ep.isExitPipe = true;
                            game.objects.Add(ep);
                        }
                        else if (s.Equals("lv"))
                        {
                            IObject lv = ObjectSpriteFactory.Instance.GetLavaTile();
                            lv.Draw(spriteBatch, new Vector2((xCounter * pixel), ((yCounter + 1) * pixel) - 16));
                            lv.isWarpPipe = false;
                            lv.isExitPipe = false;
                            game.backGround.Add(lv);
                        }
                        else if (s.Equals("lw"))
                        {
                            IObject lw = ObjectSpriteFactory.Instance.GetLavaWave();
                            lw.Draw(spriteBatch, new Vector2((xCounter * pixel), ((yCounter + 1) * pixel) - 16));
                            lw.isWarpPipe = false;
                            lw.isExitPipe = false;
                            game.backGround.Add(lw);
                        }
                        else if (s.Equals("ty"))
                        {
                            IObject ty = ObjectSpriteFactory.Instance.GetThankYou();
                            ty.Draw(spriteBatch, new Vector2((xCounter * pixel) - 77, ((yCounter + 1) * pixel) - 24));
                            ty.isWarpPipe = false;
                            ty.isExitPipe = false;
                            game.backGround.Add(ty);
                        }
                        else if (s.Equals("td"))
                        {
                            IObject td = ObjectSpriteFactory.Instance.GetToad();
                            td.Draw(spriteBatch, new Vector2((xCounter * pixel), ((yCounter + 1) * pixel) - 24));
                            td.isWarpPipe = false;
                            td.isExitPipe = false;
                            game.backGround.Add(td);
                        }
                        else if (s.Equals("tc"))
                        {
                            IObject tc = ObjectSpriteFactory.Instance.GetBridgeRope();
                            tc.Draw(spriteBatch, new Vector2((xCounter * pixel), ((yCounter + 1) * pixel) - 16));
                            tc.isWarpPipe = false;
                            tc.isExitPipe = false;
                            game.objects.Add(tc);
                        }
                        else if (s.Equals("ax"))
                        {
                            IObject ax = ObjectSpriteFactory.Instance.GetAxe();
                            ax.Draw(spriteBatch, new Vector2((xCounter * pixel), ((yCounter + 1) * pixel) - 16));
                            ax.isWarpPipe = false;
                            ax.isExitPipe = false;
                            game.objects.Add(ax);
                        }
                        else if (s.Equals("db"))
                        {
                            game.blocks.Add(new Block(new Vector2(xCounter * pixel, yCounter * pixel), new HardBlockState()));   
                        }
                        else if (s.Equals("cb"))
                        {
                            IBlock cb = new Block(new Vector2(xCounter * pixel, yCounter * pixel), new QuestionBlockState());
                            game.blocks.Add(cb);
                            IItem coin = new Coin(new Vector2((xCounter * pixel)+4, yCounter * pixel));
                            cb.StoreItem(coin);
                            game.items.Add(coin);            
                        }
                        else if (s.Equals("kb"))
                        {
                            IBlock kb = new Block(new Vector2(xCounter * pixel, yCounter * pixel), new BrickBlockState());
                            game.blocks.Add(kb);
                            IItem coin = new Coin(new Vector2((xCounter * pixel)+4, yCounter * pixel));
                            kb.StoreItem(coin);
                            game.items.Add(coin);
                        }
                        else if (s.Equals("mc"))
                        {
                            IBlock mc = new Block(new Vector2(xCounter * pixel, yCounter * pixel), new BrickBlockState());
                            game.blocks.Add(mc);
                            for (int i = 0; i < 10; ++i)
                            {
                                IItem coin = new Coin(new Vector2((xCounter * pixel) + 4, yCounter * pixel));
                                mc.StoreItem(coin);
                                game.items.Add(coin);
                            }
                        }
                        else if (s.Equals("tb"))
                        {
                            IBlock tb = new Block(new Vector2(xCounter * pixel, yCounter * pixel), new BrickBlockState());
                            game.blocks.Add(tb);
                            IItem coin = new Star(new Vector2(xCounter * pixel, yCounter * pixel));
                            tb.StoreItem(coin);
                            game.items.Add(coin);
                        }
                        else if (s.Equals("mb"))
                        {
                            IBlock cb = new Block(new Vector2(xCounter * pixel, yCounter * pixel), new QuestionBlockState());
                            game.blocks.Add(cb);
                            IItem mush = new Mushroom(new Vector2(xCounter * pixel, yCounter * pixel));
                            cb.StoreItem(mush);
                            game.items.Add(mush);
                        }
                        else if (s.Equals("fp"))
                        {
                            IBlock fp = new Block(new Vector2(xCounter * pixel, yCounter * pixel), new QuestionBlockState());
                            game.blocks.Add(fp);
                            IItem flower = new FireFlower(new Vector2(xCounter * pixel, yCounter * pixel));
                            fp.StoreItem(flower);
                            game.items.Add(flower);
                        }
                        else if (s.Equals("ub"))
                        {
                            game.blocks.Add(new Block(new Vector2(xCounter * pixel, yCounter * pixel), new UsedBlockState()));        
                        }
                        else if (s.Equals("bb"))
                        {
                            game.blocks.Add(new Block(new Vector2(xCounter * pixel, yCounter * pixel), new BrickBlockState()));             
                        }
                        else if (s.Equals("zb"))
                        {
                            game.blocks.Add(new Block(new Vector2(xCounter * pixel, yCounter * pixel), new CastleBlockState()));
                        }
                        else if (s.Equals("ta"))
                        {
                            game.blocks.Add(new Block(new Vector2(xCounter * pixel, yCounter * pixel), new BridgeBlockState()));
                        }
                        else if (s.Equals("hb"))
                        {
                            IBlock hiddenBlock = new Block(new Vector2(xCounter * pixel, yCounter * pixel), new HiddenBlockState());
                            game.blocks.Add(hiddenBlock);
                            IItem oneUp = new OneUp(new Vector2(xCounter * pixel, yCounter * pixel));
                            hiddenBlock.StoreItem(oneUp);
                            game.items.Add(oneUp);
                        }
                        else if (s.Equals("ff"))
                        {
                            game.items.Add(new FireFlower(new Vector2(xCounter * pixel, yCounter * pixel)));           
                        }
                        else if (s.Equals("st"))
                        {
                            game.items.Add(new Star(new Vector2(xCounter * pixel, yCounter * pixel)));
                        }
                        else if (s.Equals("ou"))
                        {
                            game.items.Add(new OneUp(new Vector2(xCounter * pixel, yCounter * pixel)));     
                        }
                        else if (s.Equals("ms"))
                        {
                            game.items.Add(new Mushroom(new Vector2(xCounter * pixel, yCounter * pixel)));    
                        }
                        else if (s.Equals("cn"))
                        {
                            game.items.Add(new Coin(new Vector2(xCounter * pixel, yCounter * pixel)));  
                        }
                        else if (s.Equals("gb"))
                        {
                            game.goombaList.Add(new Goomba(new Vector2(xCounter * pixel, yCounter * pixel)));               
                        }
                        else if (s.Equals("kp"))
                        {
                            game.koopaList.Add(new Koopa(new Vector2(xCounter * pixel, (yCounter * pixel)-7)));        
                        }
                        else if (s.Equals("rk"))
                        {
                            Koopa koopa = new Koopa(new Vector2(xCounter * pixel, (yCounter * pixel) - 7));
                            game.koopaList.Add(new RedKoopa(koopa));
                        }
                        else if (s.Equals("bs"))
                        {
                            Bowser bowser = new Bowser(new Vector2(xCounter * pixel, (yCounter * pixel) - 16), game);
                            game.bowserList.Add(bowser);
                        }
                        else if (s.Equals("fg"))
                        {
                            IObject fp = ObjectSpriteFactory.Instance.GetFlagPole();
                            fp.Draw(spriteBatch, new Vector2((xCounter * pixel) - 24, ((yCounter +1) * pixel) - 168));
                            fp.isWarpPipe = false;
                            fp.isExitPipe = false;
                            game.objects.Add((FlagPole)fp);
                        }      
                        xCounter++;
                    }
                    yCounter++;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                reader.Close();
            }
        }
        public void Update()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                UpdateUtilities.UpdateWithThreads(game);
            }
            else
            {
                UpdateUtilities.UpdateWithoutThreads(game);
            }
            foreach (ICollisionFinder Finder in game.CollisionFinder)
            {
                Finder.findCollision();
            }
        }

        public void Draw()
        {
            foreach (IPiranaPlant minion in game.piranaPlantList)
            {
                minion.Draw(spriteBatch, minion.Location, shade);
            }
            foreach (IObject back in game.backGround)
            {
                back.Draw(spriteBatch, back.Location);
            }
            foreach (IObject obj in game.objects)
            {
                obj.Draw(spriteBatch, obj.Location);
            }
            foreach (IItem item in game.items)
            {
                item.draw(spriteBatch, item.Location);
            }
            foreach (IBlock block in game.blocks)
            {
                block.draw(spriteBatch, block.Location, shade);
            }
            foreach (Goomba minion in game.goombaList)
            {
                minion.Draw(spriteBatch, minion.Location, shade);
            }
            foreach (IKoopa minion in game.koopaList)
            {
                minion.Draw(spriteBatch, minion.Location, shade);
            }
            foreach (IBowser bowser in game.bowserList)
            {
                bowser.Draw(spriteBatch, bowser.Location, shade);
            }

        }
        public string GetLevel()
        {
            string levelName;
            string[] explode = game.curLevel.Split('\\');
            levelName = explode[explode.Length - 1].Substring(0, explode[explode.Length - 1].Length - 4);
            if (levelName == "worldOneOne")
                levelName = "1-1";
            else if (levelName == "level")
                levelName = "Test";
            else if (levelName == "worldOneOneUnderground")
                levelName = "1-1G";
            else if (levelName == "worldOneTwo")
                levelName = "1-2";
            else if (levelName == "worldOneTwoUnderground")
                levelName = "1-2G";
            else if (levelName == "worldOneFour")
                levelName = "1-4";
            
            return levelName;
        }
        public void ToggleCastle(bool toggle)
        {
            foreach(IObject obj in game.objects){
                if(obj is Castle)
                {
                    castle = (Castle)obj;
                    castle.castleCanUpdate = toggle;
                }
            }
        }
    }
}
