using System;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public Sound[] Sounds;
        private static SoundManager _instance;

        public static SoundManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SoundManager>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            DontDestroyOnLoad(gameObject);
            foreach (var s in Sounds)
            {
                s.Source = gameObject.AddComponent<AudioSource>();
                s.Source.clip = s.Clip;
                s.Source.volume = s.Volume;
                s.Source.pitch = s.Pitch;
                s.Source.loop = s.Loop;
            }
            Play(SoundNames.Music,true);
        }

        public void Play(string name, bool loop = false)
        {
            Sound s = System.Array.Find(Sounds, sound => sound.Name == name);
            s.Source.loop = loop;
            if (!s.Source.isPlaying)
            {
                s?.Source.Play();
            }
            
        }

        public void Stop(string name)
        {
            Sound s = System.Array.Find(Sounds, sound => sound.Name == name);
            s?.Source.Stop();
        }
        public void SoundsToggle()
        {
            foreach (var sound in Sounds)
            {
                sound.Source.volume = sound.Source.volume == 0 ? 1 : 0;
            }
        }
    }
}