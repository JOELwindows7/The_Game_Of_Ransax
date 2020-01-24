using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TargetShootBehaviour : MonoBehaviour
{
    public AudioClip soundFile;
    public AudioClip[] MultiSoundFilesAtOnce;
    public AudioClip[] MultiSoundFilesRandomly;
    [Range(0f,10f)] public float VolumeOut = 1f;
    public bool PlaySoundFile = true;
    public bool PlayMultiAtOnce = false;
    public bool PlayMultiRandomly = false;
    public GameObject ParticleExplode;
    public float MoveLeftSpeed = 10f;
    public float MoveUpSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * MoveLeftSpeed * Time.deltaTime);
        transform.Translate(new Vector3(-MoveLeftSpeed * Time.deltaTime, MoveUpSpeed * Time.deltaTime));
    }

    void TargetHit()
    {
        if(HitOrMiss.Instance.BulletAmmoNumber > 0f){
            Destroy(gameObject);
            if(soundFile && PlaySoundFile) ExternalSpeaker.Instance.FlashSoundEffect(soundFile, VolumeOut);
            HitOrMiss.Instance.WeponShotSound();
            if(PlayMultiAtOnce){
                foreach(AudioClip sounds in MultiSoundFilesAtOnce){
                    if(sounds) ExternalSpeaker.Instance.FlashSoundEffect(sounds,VolumeOut);
                }
            }
            if(PlayMultiRandomly){
                AudioClip TempoAudio = MultiSoundFilesRandomly[Random.Range(0, MultiSoundFilesRandomly.Length)];
                if(TempoAudio) ExternalSpeaker.Instance.FlashSoundEffect(TempoAudio, VolumeOut);
            }

            if(ParticleExplode) {
                Instantiate(ParticleExplode, transform.position, Quaternion.identity, transform.parent);
            }
            HitOrMiss.Instance.Hit();
        }
        else {
            HitOrMiss.Instance.WeponShotEmpty();
            Debug.Log("Out of Ammo!");
        }
    }

    private void OnMouseDown()
    {
        if(!TimeManagement.Instance.IsTimeFrozen){
            Debug.Log("Bang!");
            TargetHit();
        }
    }

    //Todo mouse held rapid fire
}
