using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public static class SoundBoardManager
    {


        public static void SetVolume(float volume)
        {
            MarioWorldSoundBoard.Instance.Volume = volume;
            MarioSoundBoard.Instance.Volume = volume;
            ItemBlockSoundBoard.Instance.Volume = volume;
        }

        public static void SetContent(ContentManager content)
        {
            MarioWorldSoundBoard.Instance.SetContent(content);
            MarioSoundBoard.Instance.SetContent(content);
            ItemBlockSoundBoard.Instance.SetContent(content);
        }

    }
}
