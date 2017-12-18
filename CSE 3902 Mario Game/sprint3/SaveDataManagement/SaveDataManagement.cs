using System;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Xml.Serialization;

namespace MarioGame
{
    public class SaveDataManagement
    {

        public IMario Mario { get; set; }
        public ScoreTracker score { get; set; }
        public Collection<Goomba> goombaList { get;  }
        public Collection<IPiranaPlant> piranaPlantList { get; }
        public Collection<Bowser> bowserList { get;  }
        public Collection<IKoopa> koopaList { get;  }
        public Collection<IBlock> blocks { get; }
        public Collection<IItem> items { get;  }
        public Collection<IObject> objects { get;  }
        public Collection<IObject> backGround { get; }
        public Collection<ICollisionFinder> CollisionFinder { get; }
        public IController keyboard { get; set; }
        public IController gamepad { get; set; }

        public SaveDataManagement(Game1 Game)
        {
            Mario = Game.Mario;
            score = Game.st;
            goombaList = new Collection<Goomba>();
            piranaPlantList = new Collection<IPiranaPlant>();
            bowserList = new Collection<Bowser>();
            koopaList = new Collection<IKoopa>();
            blocks = new Collection<IBlock>();
            items = new Collection<IItem>();
            objects = new Collection<IObject>();
            backGround = new Collection<IObject>();
            CollisionFinder = new Collection<ICollisionFinder>();
            keyboard = Game.keyboard;
            gamepad = Game.gamepad;
        }
        public void SaveGame(Game1 Game)
        {
            ClearTemp();
            foreach (IKoopa minion in Game.koopaList)
            {
                koopaList.Add(minion);
            }
            foreach (Goomba goomba in Game.goombaList)
            {
                goombaList.Add(goomba);
            }
            foreach(Bowser boss in Game.bowserList)
            {
                bowserList.Add(boss);
            }
            foreach (IPiranaPlant minion in Game.piranaPlantList)
            {
                piranaPlantList.Add(minion);
            }
            foreach (IBlock block in Game.blocks)
            {
                blocks.Add(block);
            }
            foreach (IItem item in Game.items)
            {
                items.Add(item);
            }
            foreach (IObject obj in Game.objects)
            {
                objects.Add(obj);
            }
            foreach (IObject back in Game.backGround)
            {
                backGround.Add(back);
            }
            foreach (ICollisionFinder collision in Game.CollisionFinder)
            {
                CollisionFinder.Add(collision);
            }

            keyboard = Game.keyboard;
            gamepad = Game.gamepad;

        }

        public void LoadGame(Game1 game)
        {
            ClearList(game);
            foreach (Goomba minion in goombaList)
            {
                game.goombaList.Add(minion);
            }
            foreach (PiranaPlant minion in piranaPlantList)
            {
                game.piranaPlantList.Add(minion);
            }
            foreach (Bowser boss in bowserList)
            {
                game.bowserList.Add(boss);
            }
            foreach (IKoopa minion in koopaList)
            {
                game.koopaList.Add(minion);
            }
            foreach (IBlock block in blocks)
            {
                game.blocks.Add(block);
            }
            foreach (IItem item in items)
            {
                game.items.Add(item);
            }
            foreach (IObject objs in objects)
            {
                game.objects.Add(objs);
            }
            foreach (IObject objs in backGround)
            {
                game.backGround.Add(objs);

            }
            ClearTemp();
        }

        static void ClearList(Game1 game)
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
        void ClearTemp()
        {
            goombaList.Clear();
            koopaList.Clear();
            blocks.Clear();
            items.Clear();
            objects.Clear();
            piranaPlantList.Clear();
            bowserList.Clear();
            backGround.Clear();
        }
    }
}
