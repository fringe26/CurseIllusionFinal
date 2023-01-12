using UnityEngine;

namespace Managers
{
    [System.Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
        public string Description;
        [Range(0,1)]
        public float Volume;
        [Range(0.1f,3f)]
        public float Pitch;
        public bool Loop;

        [HideInInspector]
        public AudioSource Source;
    }
}