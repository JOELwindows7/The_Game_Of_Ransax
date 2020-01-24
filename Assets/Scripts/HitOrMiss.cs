using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOrMiss : Singleton<HitOrMiss>
{
    public ParlorGame targetParlor;
    public float BulletAmmoNumber;
    public int SelectedWeapon;

    public AudioClip weponEmpty;
    public AudioClip weponPistolShot;
    public AudioClip weponReload;
    public AudioClip weponLastShotFired;

    public AudioClip EikSerkatDedd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectedWeapon = targetParlor.SelectWepon;
        BulletAmmoNumber = targetParlor.BulletAmmo[SelectedWeapon];
    }

    //Miss ya
    public void Hit(){
        if(targetParlor){
            targetParlor.TargetHit();
        }
    }
    public void Miss(){
        if(targetParlor){
            targetParlor.TargetMiss();
        }
    }

    public void FellOffScreen(){
        if(targetParlor){
            targetParlor.TargetFellOffScreen();
        }
    }

    public void WeponShotSound(){
        if(targetParlor.HasGameStarted) {
            ExternalSpeaker.Instance.FlashSoundEffect(weponPistolShot);
            if(BulletAmmoNumber == 1){
                WeponShotLast();
            }
        }
    }
    public void WeponShotEmpty(){
        if(targetParlor.HasGameStarted) ExternalSpeaker.Instance.FlashSoundEffect(weponEmpty);
    }
    public void WeponShotReload(){
        if(targetParlor.HasGameStarted) ExternalSpeaker.Instance.FlashSoundEffect(weponReload);
    }
    public void WeponShotLast(){
        if(targetParlor.HasGameStarted) ExternalSpeaker.Instance.FlashSoundEffect(weponLastShotFired);
    }
    public void EikSerkatImDedd(){
        ExternalSpeaker.Instance.FlashSoundEffect(EikSerkatDedd);
    }
}
