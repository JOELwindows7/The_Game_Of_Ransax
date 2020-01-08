using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOrMiss : Singleton<HitOrMiss>
{
    public ParlorGame targetParlor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
