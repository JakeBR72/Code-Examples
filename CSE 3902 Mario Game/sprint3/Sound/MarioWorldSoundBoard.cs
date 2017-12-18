using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioWorldSoundBoard
    {
        private static MarioWorldSoundBoard instance = new MarioWorldSoundBoard();
        private ContentManager content;

        public float Volume { get; set; } 
        public static MarioWorldSoundBoard Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioWorldSoundBoard()
        {

        }

        public void SetContent(ContentManager Content)
        {
             content = Content;
        }

        public void PlayFireworks()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("fireworks"));
        }

        public void PlayFlagpole()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("flag-pole"));
        }

        public void PlayGameOver()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("game-over"));
        }

        public void PlayPause()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("pause"));
        }

        public void PlayStageClear()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("stage-clear"));
        }

        public void PlayTimeWarning()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("time-warning"));
        }

        public void PlayWorldClear()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("world-clear"));
        }
        private void LowerVolumeAndPlay(SoundEffect sound)
        {
            SoundEffectInstance soundInstance = sound.CreateInstance();
            soundInstance.Volume = soundInstance.Volume * Volume;
            soundInstance.Play();
        }
    }
}
