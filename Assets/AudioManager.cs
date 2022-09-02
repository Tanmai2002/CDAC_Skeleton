using UnityEngine;
using UnityEngine.Audio;
using System;
// using Array = UnityEngine.Audio.AudioMixerGroup;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance;
    Sounds currentSound;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

        public int SoundIndex = 0;

        void Start()
        {
            
            Play(sounds[SoundIndex].name);

        }


    public void Play(string name)
    {
        if(currentSound!=null){
            
        }
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        currentSound=s;
        s.source.Play();
    }

    public void pause(){
        currentSound.source.Pause();
    }
    public void resume(){
             currentSound.source.UnPause();
    }

    void stopCurrent(){
        currentSound.source.Stop();
    }
  
}