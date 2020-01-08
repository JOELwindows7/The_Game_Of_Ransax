using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExternalSpeaker : Singleton<ExternalSpeaker>
{
    public float volumeScale = 1f;
    [SerializeField] AudioSource Speakering;
    // Start is called before the first frame update
    void Start()
    {
        if(!Speakering){
            Speakering = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlashSoundEffect(AudioClip soundFile){
        Speakering.PlayOneShot(soundFile);
    }
    public void FlashSoundEffect(AudioClip soundFile, float volume){
        Speakering.PlayOneShot(soundFile, volume);
    }
    public void FlashSoundEffect(AudioClip soundFile, Transform Pointition){
        
    }

    public void PlayTestoid(){
        
    }
}
