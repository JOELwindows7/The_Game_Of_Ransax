using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BekgronQuadScroller : MonoBehaviour
{
    public ParlorGame engineSelf;
    public AudioClip soundFile;
    [SerializeField] Material materialingBekgron;
    [SerializeField] Vector2 offseting;

    public float xVelocity, yVelocity;

    public float ScrollSpeed = .5f;

    public void SwitchOn(){
        offseting = new Vector2(ScrollSpeed,0f);
    }
    public void SwitchOff(){
        offseting = new Vector2(0f,0f);
    }

    void Awake(){
        materialingBekgron = GetComponent<Renderer>().material;
        if(!engineSelf){
            engineSelf = transform.parent.GetComponent<ParlorGame>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //offseting = new Vector2(xVelocity,yVelocity);
        SwitchOff();
    }

    // Update is called once per frame
    void Update()
    {
        materialingBekgron.mainTextureOffset += offseting * Time.deltaTime;
    }

    private void MissHit(){
        // if(engineSelf){
        //     if(engineSelf.BulletAmmo1 > 0){
        //         if(soundFile) ExternalSpeaker.Instance.FlashSoundEffect(soundFile);
        //         else {
            
        //         }
        //         HitOrMiss.Instance.Miss(); //Huh
        //     }
        // }
        if(HitOrMiss.Instance.BulletAmmoNumber > 0f){
            if(soundFile) ExternalSpeaker.Instance.FlashSoundEffect(soundFile);
            else {
            
            }
            HitOrMiss.Instance.Miss(); //Huh
        }
    }

    private void OnMouseDown()
    {
        if(!TimeManagement.Instance.IsTimeFrozen){
            Debug.Log("Miss!");
            MissHit();
        }
    }

    //Todo Rapidfire on mouse held
}
