using UnityEngine;
using UnityEngine.Audio;
using System;
// using Array = UnityEngine.Audio.AudioMixerGroup;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance;
    Sounds currentSound,forgroundMusic;
    public bool isSoundOn=true;

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
       
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        currentSound=s;
        s.source.Play();
    }

    public void playForeground(string name){
        lowerMainVolume();
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        forgroundMusic=s;
        s.source.Play();


    }

    public void stopForeground(){
        if(forgroundMusic==null)
        return;
        normalizeMainVolume();
        forgroundMusic.source.Stop();
        forgroundMusic=null;
        

    }
     void lowerMainVolume(){
        currentSound.source.volume=0.3f;
    }

     void normalizeMainVolume(){
        currentSound.source.volume=1f;
    }


    public void pause(){
        currentSound.source.Pause();
        isSoundOn=false;
    }
    public void resume(){
        currentSound.source.UnPause();
        isSoundOn=true;
    }

    void stopCurrent(){
        currentSound.source.Stop();
    }
  
}