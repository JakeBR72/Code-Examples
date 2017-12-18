using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MarioSoundBoard
    {
        private static MarioSoundBoard instance = new MarioSoundBoard();
        private ContentManager content;

        public float Volume { get; set; }
        public static MarioSoundBoard Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioSoundBoard()
        {

        }

        public void SetContent(ContentManager newContent)
        {
            this.content = newContent;
        }

        public void PlayMarioDamage()
        {
            SoundEffect sound = content.Load<SoundEffect>("mario-powerup");
            SoundEffectInstance soundInstance = sound.CreateInstance();
            soundInstance.Volume = soundInstance.Volume / 4;
            soundInstance.Pitch = soundInstance.Pitch -(float) .2;
            soundInstance.Play();
        }

        public void PlayMarioDie()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("mario-die"));
        }

        public void PlayMarioFireball()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("mario-fireball"));
        }

        public void PlayMarioJump()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("mario-jump"));
        }

        public void PlayMarioKick()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("mario-kick"));
        }

        public void PlayMarioPipe()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("mario-pipe"));
        }

        public void PlayMarioPowerup()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("mario-powerup"));
        }

        public void PlayMarioStomp()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("mario-stomp"));
        }

        public void PlayMarioVine()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("mario-vine"));
        }

        public void PlayBowserFire()
        {
            LowerVolumeAndPlay(content.Load<SoundEffect>("bowserFireSE"));
        }

        private void LowerVolumeAndPlay(SoundEffect sound)
        {
            SoundEffectInstance soundInstance = sound.CreateInstance();
            soundInstance.Volume = soundInstance.Volume * Volume;
            soundInstance.Play();
        }
    }
}
