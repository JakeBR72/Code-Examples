using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class CameraUpdateCollisionFinder : ICollisionFinder
    {
        private Game1 Game;
        public CameraUpdateCollisionFinder(Game1 game)
        {
            Game = game;
        }
        public void findCollision()
        {
            ICollision side = new NullCollision();
            for (int i=0; i<Game.goombaList.Count; ++i)
            {
                side = CollisionDetector.detectCollision(Game.MainCameraObject, Game.goombaList[i]);
                if (!(side is NullCollision))
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
                else
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateNullCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
            }
            for (int i = 0; i < Game.koopaList.Count; ++i)
            {
                side = CollisionDetector.detectCollision(Game.MainCameraObject, Game.koopaList[i]);
                if (!(side is NullCollision))
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
                else
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateNullCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
            }
            for (int i = 0; i < Game.piranaPlantList.Count; ++i)
            {
                side = CollisionDetector.detectCollision(Game.MainCameraObject, Game.piranaPlantList[i]);
                if (!(side is NullCollision))
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
                else
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateNullCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
            }
            for (int i = 0; i < Game.items.Count; ++i)
            {
                side = CollisionDetector.detectCollision(Game.MainCameraObject, Game.items[i]);
                if (!(side is NullCollision))
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
            }
            for (int i = 0; i < Game.blocks.Count; ++i)
            {
                side = CollisionDetector.detectCollision(Game.MainCameraObject, Game.blocks[i]);
                if (!(side is NullCollision))
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
                else
                {
                    ICollisionHandler cameraUpdate = new CameraUpdateNullCollisionHandler(side);
                    cameraUpdate.handleCollision();
                }
            }
        }
    }
}
