using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class PiranaSpriteFactory
    {

        private Texture2D PiranaPlant;


        private static PiranaSpriteFactory instance = new PiranaSpriteFactory();

        public static PiranaSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PiranaSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            PiranaPlant = content.Load<Texture2D>("PiranaPlant");
        }


        public IEnemySprite GetPiranaPlantSprite()
        {
            return new PiranaPlantSprite(PiranaPlant);
        }
    }

}
