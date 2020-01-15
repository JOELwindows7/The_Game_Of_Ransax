using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParlorGame : MonoBehaviour
{
    public bool HasGameStarted = false;
    public FieldContains FieldContains;
    public BekgronQuadScroller bekgronding;

    public ParlorSpecificUI parlorSpecificUI;

    public CoreCanvas core;
    

    public int HPinit = 5;
    [SerializeField] int HPnumber = 5;
    [SerializeField] float HPfloat;
    [SerializeField] int DiceRange = 100;
    [SerializeField] int DiceSelect = 0;
    [SerializeField] int DiceWishMeLuck = 77;
    public int HPnumber1 { get => HPnumber; /*set => HPnumber = value;*/ }
    
    public int SelectWepon = 0;
    public int [] BulletInit = {10,10,5};
    public int [] BulletAmmo = {10, 10, 5};
    public float [] BulletFloat = {10f, 10f, 5f};
    //public int BulletAmmo1 { get => BulletAmmo; /*set => BulletAmmo = value;*/ }
    

    [SerializeField] float ScoreYeah = 0f;
    public float ScoreYeah1 { 
        get => ScoreYeah; 
        set => ScoreYeah = value; 
    }
    public void AddScore(float howMuch){
        ScoreYeah+=howMuch;
        if(ScoreYeah > InGameHiScore){
            InGameHiScore = ScoreYeah;
        }
    }

    [SerializeField] float HiScoreFirst = 0f;
    public float HiScoreFirst1 { get => HiScoreFirst; set => HiScoreFirst = value; }
    

    public float InGameHiScore = 0f;

    void Awake(){
        HiScoreFirst = PlayerPrefs.GetFloat("HiScoreFirst", 0f);
        InGameHiScore = HiScoreFirst;
    }


    // Start is called before the first frame update
    void Start()
    {
        SelectWepon=0;
        if (!transform.parent)
        {
            HasGameStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HPfloat = (float)HPnumber;
        //BulletFloat = (float)BulletAmmo1;
        for(int i=0; i < BulletFloat.Length-1;i++){
            BulletFloat[i]=(float)BulletAmmo[i];
        }
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

            parlorSpecificUI.AmmoNumber = BulletAmmo[SelectWepon];
            parlorSpecificUI.AmmoMax = BulletInit[SelectWepon];

            parlorSpecificUI.ScoreNumber = ScoreYeah;
            parlorSpecificUI.HiScoredNumber = InGameHiScore;
            parlorSpecificUI.CurrentHiScored = HiScoreFirst;
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

    public void BulletThrow(){
        BulletAmmo[SelectWepon]--;
    }
    public void BulletReload(){
        if(SelectWepon == 0){
            BulletAmmo[SelectWepon] = BulletInit[SelectWepon];
        }
    }

    public void ResetScore(){
        ScoreYeah = 0f;
    }
    public void PublishScoreHi(){
        if(ScoreYeah > HiScoreFirst){
            Kixlonzing.Instance.AddKixlonz(5);
            HiScoreFirst = ScoreYeah;
            PlayerPrefs.SetFloat("HiScoreFirst", HiScoreFirst);
            PlayerPrefs.Save();
        }
    }

    //got a kiss
    public void TargetHit(){
        if(HasGameStarted){
            //ScoreYeah+=100f;
            if(HasGameStarted){ 
                AddScore(100f);
                BulletThrow();

                WishMeLuck();
            }
        }
    }
    public void TargetMiss(){
        if(HasGameStarted){
            if(SelectWepon == 0){
                if(!parlorSpecificUI.isGamePaused){
                    Ouch();
                    Debug.Log("MinusHP");
                }
            }

            BulletThrow();
        }
    }

    public void WishMeLuck(){
        DiceSelect = Random.Range(0,DiceRange);
        if(DiceSelect == DiceWishMeLuck){
            Heal();
        }
    }

    public void StartTheGameNow()
    {
        ResetObjects();
        resetHP();
        ResetScore();
        BulletReload();
        HasGameStarted = true;
        foreach(Spawnering spawnerr in spawnerings)
        {
            if(spawnerr)
            spawnerr.activateSpawner = true;
        }
    }
    public void StopTheGameNow()
    {
        Debug.Log("Stop Game");
        //resetHP();
        HasGameStarted = false;
        foreach (Spawnering spawnerr in spawnerings)
        {
            if(spawnerr)
            spawnerr.activateSpawner = false;
        }
        parlorSpecificUI.ResumeTheGame();
    }
    public void StopTheGameNow(bool resetObjects, bool resetHPnow){
        if(resetObjects) ResetObjects();
        if(resetHPnow) resetHP();
        StopTheGameNow();
    }

    public void GameOverNow(){
        PublishScoreHi();
        if(parlorSpecificUI){
            parlorSpecificUI.OverTheGame();
        }
        parlorSpecificUI.preemptedDialog.IsGameStarted=false;
        StopTheGameNow(false, false);
        //core.InstructStopGame(0);
    }
}
