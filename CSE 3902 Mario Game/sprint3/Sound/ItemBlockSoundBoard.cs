using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class ItemBlockSoundBoard
    {
        private static ItemBlockSoundBoard instance = new ItemBlockSoundBoard();
        private ContentManager content;

        public float Volume { get; set; }
        public static ItemBlockSoundBoard Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemBlockSoundBoard()
        {

        }

        public void SetContent(ContentManager Content)
        {
            content = Content;
        }

        public void PlayBlockBreak()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("block-break"));
        }

        public void PlayBlockBump()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("block-bump"));
        }

        public void PlayCoinCollect()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("coin-collect"));
        }

        public void PlayOneUp()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("one-up"));
        }

        public void PlayPowerUpAppear()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("powerup-appear"));
        }

        private void LowerVolumeAndPlay(SoundEffect sound)
        {
            SoundEffectInstance soundInstance = sound.CreateInstance();
            soundInstance.Volume = soundInstance.Volume * Volume;
            soundInstance.Play();
        }
    }
}
