using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParlorSpecificUI : MonoBehaviour
{
    [Range(0f, 100f)] public float HPLevel = 100f;
    public int AmmoNumber;
    public float ScoreNumber;

    public bool isGamePaused = false;

    public Slider HPBar;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI ScoreText;

    public AbstractGameplayUI AbstractGameplayUI;
    public AbstractShopUI AbstractShopUI;
    public PreemptedDialog preemptedDialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.value = HPLevel;
        AmmoText.text = AmmoNumber.ToString();
        ScoreText.text = ScoreNumber.ToString();
    }

    public void PauseTheGame()
    {
        if (preemptedDialog)
        {
            preemptedDialog.IsGamePaused = true;
        }
        SpawnPreemptedDialogAs(PreemptedDialog.WhichMode.Paused);
        FreezeTime();
        isGamePaused = true;
    }

    public void ResumeTheGame()
    {
        if (preemptedDialog)
        {
            preemptedDialog.IsGamePaused = false;
        }
        UnFreezeTime();
        isGamePaused = false;
    }

    [SerializeField] float tempTimeScale;
    public void FreezeTime()
    {
        tempTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void UnFreezeTime()
    {
        Time.timeScale = tempTimeScale;
        //Time.timeScale = 1f;
    }

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
}
