using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TargetShootBehaviour : MonoBehaviour
{
    public AudioClip soundFile;
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
            if(soundFile) ExternalSpeaker.Instance.FlashSoundEffect(soundFile, .5f);
            if(ParticleExplode) {
                Instantiate(ParticleExplode, transform.position, Quaternion.identity, transform.parent);
            }
            HitOrMiss.Instance.Hit();
        }
        else {
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
}
