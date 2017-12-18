using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public class MusicManager
    {
        private SoundEffectInstance backGroundMusic = null;
        private static MusicManager instance = new MusicManager();
        private ContentManager content;
        public String currentSong { get; set; }

        public float musicVolume {get; set;} 

        public static MusicManager Instance
        {
            get
            {
                return instance;
            }
        }

        private MusicManager()
        {
            musicVolume = (float).25;
        }

        public void SetContent(ContentManager Content)
        {
            content = Content;
        }
        
        public void PlayBackgroundMusic()
        {
            backGroundMusic.Play();
        }
        
        public void SetBackgroundMusic(String fileName, bool loop)
        {
            if (backGroundMusic != null)
            {
                backGroundMusic.Stop();
            }
            SoundEffect music = content.Load<SoundEffect>(fileName);
            currentSong = fileName;
            backGroundMusic = music.CreateInstance();
            backGroundMusic.Volume = backGroundMusic.Volume * musicVolume;
            backGroundMusic.IsLooped = loop;
            backGroundMusic.Play();
        }

        public void SetBackgroundMusic(String fileName)
        {
            SetBackgroundMusic(fileName, true);            
        }

        public void StopBackgroundMusic()
        {
            backGroundMusic.Stop();
        }

        public void PauseBackgroundMusic()
        {
            backGroundMusic.Pause();
        }

        public void ResumeBackgroundMusic()
        {
            backGroundMusic.Resume();
        }
    }
}
