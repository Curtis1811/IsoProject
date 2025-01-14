using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Audio 
{
    public abstract class PlayAudio
    {
        protected AudioClip sound;
        public GameObject audioSourceObject;
        protected AudioSource audioSource;
        private int loopAmount = 0;

        public PlayAudio(AudioClip sound, int loopAmount = 0)
        {
            string myName = this.GetType().Name;
            this.audioSourceObject = new(myName + "_Source");

            this.sound = sound;
            this.audioSource = audioSourceObject.AddComponent<AudioSource>();
            this.audioSource.clip = sound;
            this.loopAmount = loopAmount;

            if (loopAmount == -1 ) 
            { 
                audioSource.loop = true;
            }

            Start();
        }

        // Start is called before the first frame update
        void Start()
        {
            audioSource.Play();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

    public class PlayMusic : PlayAudio
    {
        public PlayMusic(AudioClip sound, int loopAmount = -1) : base(sound, loopAmount)
        {
        }
    }
}

