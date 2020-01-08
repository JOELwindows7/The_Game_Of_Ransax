using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TargetShootBehaviour : MonoBehaviour
{
    public AudioClip soundFile;
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
        Destroy(gameObject);
        if(soundFile) ExternalSpeaker.Instance.FlashSoundEffect(soundFile, .5f);
        HitOrMiss.Instance.Hit();
    }

    private void OnMouseDown()
    {
        Debug.Log("Bang!");
        TargetHit();
    }
}
