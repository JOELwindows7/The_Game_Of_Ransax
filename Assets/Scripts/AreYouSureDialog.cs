﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AreYouSureDialog : MonoBehaviour
{
    public TextMeshProUGUI DialogSays;
    public string toDoSomething = "Shutdown Hexagon Unity Framework";
    public CoreCanvas CoreCanvas;
    public Toggle setAdDestroyToggler;
    public enum ConfirmsList { Shutdown, ChangeDVD, BackToMenu, EnableAd};
    public ConfirmsList AreYouSureTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void spawnMessagefor(ConfirmsList confirmer){
        AreYouSureTo = confirmer;
        gameObject.SetActive(true);
    }

    public void PressYesButton()
    {
        Debug.Log("Yes Button COnfirm!");
        switch (AreYouSureTo)
        {
            case ConfirmsList.Shutdown:
                if (CoreCanvas)
                {
                    CoreCanvas.ShutdownHexagonEngine();
                }
                break;
            case ConfirmsList.ChangeDVD:
                if (CoreCanvas)
                {
                    CoreCanvas.GoBackToChangeDVD();
                }
                break;
            case ConfirmsList.BackToMenu:
                if (CoreCanvas)
                {
                    CoreCanvas.GoBackToMainMenu();
                }
                break;
            case ConfirmsList.EnableAd:
                if(setAdDestroyToggler){
                    
                }
                
                Advertiser.Instance.isAdActuallyDisabled = false;
                PlayerPrefs.SetInt("DestroyTheAds", 0);
                Advertiser.Instance.ReinitializeAds();
                break;
            default:
                
                break;
        }
        gameObject.SetActive(false);
    }

    public void PressNoButton()
    {
        switch(AreYouSureTo){
            case ConfirmsList.EnableAd:
                if(setAdDestroyToggler){
                    setAdDestroyToggler.isOn = true;
                }
                break;
            default:
                break;
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (AreYouSureTo)
        {
            case ConfirmsList.Shutdown:
                toDoSomething = "Shutdown Hexagon Unity Framework";
                break;
            case ConfirmsList.ChangeDVD:
                toDoSomething = "Exit this game";
                break;
            case ConfirmsList.BackToMenu:
                toDoSomething = "Quit to Menu";
                break;
            case ConfirmsList.EnableAd:
                toDoSomething = "Enable Ad \n(Not Recommended! AdMob & some ad plugins collects your private data wildly!)";
                break;
            default:
                toDoSomething = "Something";
                break;
        }

        if (DialogSays)
        {
            DialogSays.text = "Are You Sure to " + toDoSomething + "?";
        }
    }
}
