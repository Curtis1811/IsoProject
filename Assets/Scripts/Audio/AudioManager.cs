using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public GameObject AudioManagerGameObject;
        public AudioClip TestSound;

        private List<PlayAudio> _allSoundsList;

        // Start is called before the first frame update
        void Start()
        {
            _allSoundsList = new List<PlayAudio>();

            AudioManagerGameObject = this.GameObject();
            PlayMusic(TestSound, -1);
        }

        // Update is called once per frame
        void Update()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="music">Music clip to be played.</param>
        /// <param name="loops">How many loops the music track does before finishing. '-1' for infinite loop.</param>
        void PlayMusic(AudioClip music, int loops)
        {
            var newMusic = new PlayMusic(music, loops);
            _allSoundsList.Add(newMusic);
        }

        void ClearAllSounds()
        {
            _allSoundsList.ForEach(e => Destroy(e.audioSourceObject));
            _allSoundsList.Clear();
        }
    }
}
