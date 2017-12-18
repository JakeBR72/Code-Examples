using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MarioGame
{
    public class LevelChanger
    {
        private IMario mario;
        public Collection<IKoopa> koopaTemp { get; } = new Collection<IKoopa>();
        public Collection<Goomba> goombaTemp { get; } = new Collection<Goomba>();
        public Collection<IPiranaPlant> piranaTemp { get; } = new Collection<IPiranaPlant>();
        public Collection<IBlock> blocksTemp { get; } = new Collection<IBlock>();
        public Collection<IItem> itemsTemp { get; } = new Collection<IItem>();
        public Collection<IObject> objectsTemp { get; } = new Collection<IObject>();
        public Collection<IObject> backGroundTemp { get; } = new Collection<IObject>();
        string file;
        Game1 game;
        SpriteBatch SpriteBatch;
        public LevelChanger(string fileNameOne, Game1 Game1, SpriteBatch spriteBatch)
        {
            file = fileNameOne;
            game = Game1;
            SpriteBatch = spriteBatch;
            game.parser = new LevelParse(file, game, spriteBatch);
        }
        private void UpdateFireBall()
        {
            KeyBoard tempKeyBoard = (KeyBoard)game.keyboard;
            tempKeyBoard.FireBallLimit = game.objects.Count + 4;
            game.keyboard = (IController)tempKeyBoard;
            Gamepad tempGamePad = (Gamepad)game.gamepad;
            tempGamePad.FireBallLimit = game.objects.Count + 4;
            game.gamepad = (IController)tempGamePad;
        }

        public void changeLevel()
        {
            game.changingLevel = true;
            game.piranaPlantList.Clear();
            game.goombaList.Clear();
            game.koopaList.Clear();
            game.blocks.Clear();
            game.items.Clear();
            game.objects.Clear();
            game.backGround.Clear();
            game.bowserList.Clear();
            game.parser.LevelParser();
            UpdateFireBall();
            game.EnableControls = true;
        }

        public static void SetBGMusic(string currentLevel)
        {
            if (currentLevel.Contains("Underground"))
            {
                MusicManager.Instance.SetBackgroundMusic("underground-theme");
            }
            else if (currentLevel.Contains("Four"))
            {
                MusicManager.Instance.SetBackgroundMusic("castle-theme");
            }
            else
            {
                MusicManager.Instance.SetBackgroundMusic("main-theme");
            }
        }

        public void Transistion(string File)
        {
            game.toggleCastle = false;
            game.needBlackScreen = true;
            MarioSoundBoard.Instance.PlayMarioPipe();
            SaveState();
            game.parser = new LevelParse(File, game, SpriteBatch);
            ClearList();
            game.parser.LevelParser();
            if(mario.Size() == MarioStateMachine.MarioSize.Big)
            {
                game.Mario.SetBig();
            }
            else if(mario.Size() == MarioStateMachine.MarioSize.Fire)
            {
                game.Mario.SetFire();
            }
            UpdateFireBall();

        }
        public void TransitionBack(string File)
        {
            
            game.needBlackScreen = true;
            MarioSoundBoard.Instance.PlayMarioPipe();
            LoadState();
            game.parser = new LevelParse(File, game, SpriteBatch);
            UpdateFireBall();

        }
        public void SaveState() 
        {
            ClearTemp();
            foreach (Goomba minion in game.goombaList)
            {
                goombaTemp.Add(minion);
            }
            foreach (PiranaPlant minion in game.piranaPlantList)
            {
                piranaTemp.Add(minion);
            }
            foreach (IKoopa minion in game.koopaList)
            {
                koopaTemp.Add(minion);
            }
            foreach (IBlock block in game.blocks)
            {
                blocksTemp.Add(block);
            }
            foreach (IItem item in game.items)
            {
                itemsTemp.Add(item);
            }
            foreach (IObject objs in game.objects)
            {
                objectsTemp.Add(objs);
            }
            foreach (IObject objs in game.backGround)
            {
                backGroundTemp.Add(objs);
            }
            mario = game.Mario;

        }
        public void LoadState()
        {
            ClearList();
            foreach(Goomba minion in goombaTemp)
            {
                game.goombaList.Add(minion);
            }
            foreach(PiranaPlant minion in piranaTemp)
            {
                game.piranaPlantList.Add(minion);
            }
            foreach(IKoopa minion in koopaTemp)
            {
                game.koopaList.Add(minion);
            }
            foreach(IBlock block in blocksTemp)
            {
                game.blocks.Add(block);
            }
            foreach(IItem item in itemsTemp)
            {
                game.items.Add(item);
            }
            foreach(IObject objs in objectsTemp)
            {
                game.objects.Add(objs);
                if (objs.isExitPipe)
                {
                    game.Mario.SetPosition(new Vector2(objs.Location.X, objs.Location.Y+16));
                }
            }
            foreach (IObject objs in backGroundTemp)
            {
                game.backGround.Add(objs);
               
            }
            ClearTemp();
        }
        public void ClearList()
        {
            game.goombaList.Clear();
            game.koopaList.Clear();
            game.blocks.Clear();
            game.items.Clear();
            game.objects.Clear();
            game.piranaPlantList.Clear();
            game.bowserList.Clear();
            game.backGround.Clear();
        }
        public void ClearTemp()
        {
            goombaTemp.Clear();
            koopaTemp.Clear();
            blocksTemp.Clear();
            itemsTemp.Clear();
            objectsTemp.Clear();
            piranaTemp.Clear();
            backGroundTemp.Clear();
        }
    }
}
