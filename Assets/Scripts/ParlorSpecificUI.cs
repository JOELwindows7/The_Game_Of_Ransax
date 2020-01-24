using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParlorSpecificUI : MonoBehaviour
{
    [Range(0f, 100f)] public float HPLevel = 100f;
    public int AmmoNumber;
    public int AmmoMax;
    public float ScoreNumber;
    public float HiScoredNumber;
    public float CurrentHiScored;

    public bool isGamePaused = false;

    //public Slider HPBar;
    public MeterBar HPmeter;
    public AmunitionBar AmunitionThing;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI ScoreText;

    public AbstractUISet AbstractUISet;

    public AbstractGameplayUI AbstractGameplayUI;
    public AbstractShopUI AbstractShopUI;
    public PreemptedDialog preemptedDialog;

    public CoreCanvas CoreCanvas;

    public ParlorGame ItselfGame;

    public Text PauseText;

    void Awake(){

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HPBar.value = HPLevel;
        HPmeter.value = HPLevel;
        AmunitionThing.AmmoNumber = AmmoNumber;
        AmunitionThing.MaxAmmo = AmmoMax;
        //AmunitionThing.SetAmmoTextNumber(AmmoNumber);
        //AmmoText.text = AmmoNumber.ToString();
        ScoreText.text = ScoreNumber.ToString();
        if(preemptedDialog){
            preemptedDialog.PlayerHighScored.text = HiScoredNumber.ToString();
            preemptedDialog.CurrentHighScored.text = CurrentHiScored.ToString();
        }

        if(HPLevel>=100){
            HPmeter.barColor = Color.blue;
        } else if(HPLevel >=50f && HPLevel<100f){
            HPmeter.barColor = Color.green;
        } else if(HPLevel >=25f && HPLevel<50f){
            HPmeter.barColor = Color.yellow;
        } else if(HPLevel >=0f && HPLevel<25f){
            HPmeter.barColor = Color.red;
        } else if(HPLevel < 0){
            HPmeter.barColor = Color.black; //Zombie
        }

        if(PauseText){
            if(ItselfGame.HasGameStarted){
                PauseText.text = "PAUSE";
            } else {

            }
        }
    }

    public void PauseTheGame()
    {
        if(ItselfGame.HasGameStarted){
            if (preemptedDialog)
            {
                preemptedDialog.IsGamePaused = true;
            }
            SpawnPreemptedDialogAs(PreemptedDialog.WhichMode.Paused);
            TimeManagement.Instance. FreezeTime();
            isGamePaused = true;
        }
    }
    public void OverTheGame(){
        if (preemptedDialog)
        {
            //preemptedDialog.IsGamePaused = true;
        }
        if(PauseText){
            //PauseText.text = "RESURRECT\n(WATCH AD)";
            PauseText.text = "OH\nNO";
        }
        SpawnPreemptedDialogAs(PreemptedDialog.WhichMode.Game_Over);
    }

    public void StartTheGame(){
        // if(ItselfGame){
        //     ItselfGame.StartTheGameNow();
        // }
        if(CoreCanvas){
            CoreCanvas.InstructStartGame(0);
        }
        TimeManagement.Instance.UnFreezeTime();
        isGamePaused = false;
        if(PauseText){
            PauseText.text = "PAUSE";
        }
    }
    public void ResumeTheGame()
    {
        if (preemptedDialog)
        {
            preemptedDialog.IsGamePaused = false;
        }
        TimeManagement.Instance. UnFreezeTime();
        isGamePaused = false;
    }

    // [SerializeField] float tempTimeScale;
    // public void FreezeTime()
    // {
    //     tempTimeScale = Time.timeScale;
    //     Time.timeScale = 0f;
    // }

    // public void UnFreezeTime()
    // {
    //     //Time.timeScale = tempTimeScale;
    //     Time.timeScale = 1f;
    //     Debug.Log("Unfreeze Time");
    // }

    void SpawnPreemptedDialogAs()
    {
        if (preemptedDialog)
        {
            preemptedDialog.gameObject.SetActive(true);
        }
    }

    public void SpawnPreemptedDialogAs(PreemptedDialog.WhichMode WhatMode)
    {
        preemptedDialog.PreemptedMode = WhatMode;
        SpawnPreemptedDialogAs();
    }

    public void InvokeCeaseTheGameAttemp()
    {
        if (CoreCanvas)
        {
            CoreCanvas.InvokeAreYouSureDialog(AreYouSureDialog.ConfirmsList.BackToMenu);
        }
    }

    public void GoReload(){
        ItselfGame.BulletReload();
    }
}
