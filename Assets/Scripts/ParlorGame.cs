using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParlorGame : MonoBehaviour
{
    public bool HasGameStarted = false;
    public FieldContains FieldContains;
    public BekgronQuadScroller bekgronding;

    public ParlorSpecificUI parlorSpecificUI;

    public int HPinit = 5;
    [SerializeField] int HPnumber = 5;
    [SerializeField] float HPfloat;
    public int HPnumber1 { get => HPnumber; /*set => HPnumber = value;*/ }

    // Start is called before the first frame update
    void Start()
    {
        if (!transform.parent)
        {
            HasGameStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HPfloat = (float)HPnumber;
        if(HasGameStarted){
            //bekgronding.xVelocity = .5f;
            bekgronding.SwitchOn();
        } else {
            //bekgronding.xVelocity = 0f;
            bekgronding.SwitchOff();
        }

        if(parlorSpecificUI){
            parlorSpecificUI.HPLevel = (HPfloat/HPinit)*100f;

            if(HPnumber <= 0){
                if(HasGameStarted){
                    GameOverNow();
                }
            }
        }
    }

    public void ResetObjects()
    {
        if (FieldContains)
        {
            FieldContains.resetObjects();
        }
    }

    public Spawnering[] spawnerings;

    public void resetHP(){
        HPnumber = HPinit;
    }
    public void Ouch(){
        HPnumber--;
    }
    public void Heal(){
        HPnumber++;
    }

    //got a kiss
    public void TargetHit(){

    }
    public void TargetMiss(){
        Ouch();
        Debug.Log("MinusHP");
    }

    public void StartTheGameNow()
    {
        ResetObjects();
        resetHP();
        HasGameStarted = true;
        foreach(Spawnering spawnerr in spawnerings)
        {
            if(spawnerr)
            spawnerr.activateSpawner = true;
        }
    }
    public void StopTheGameNow()
    {
        
        resetHP();
        HasGameStarted = false;
        foreach (Spawnering spawnerr in spawnerings)
        {
            if(spawnerr)
            spawnerr.activateSpawner = false;
        }
    }
    public void StopTheGameNow(bool resetObjects){
        ResetObjects();
        StopTheGameNow();
    }

    public void GameOverNow(){
        if(parlorSpecificUI){
            parlorSpecificUI.OverTheGame();
        }
        StopTheGameNow(false);
    }
}
