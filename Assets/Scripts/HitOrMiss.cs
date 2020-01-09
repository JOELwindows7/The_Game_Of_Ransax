using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOrMiss : Singleton<HitOrMiss>
{
    public ParlorGame targetParlor;
    public float BulletAmmoNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletAmmoNumber = targetParlor.BulletAmmo1;
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
}
