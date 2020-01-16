using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDSlotUI : MonoBehaviour
{
    public AbstractUISet[] UISets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShopMenu(int GameIndex){
        UISets[GameIndex].OpenShopMenu();
    }
    public void OpenCreditMenu(int GameIndex){
        UISets[GameIndex].OpenCreditMenu();
    }
    public void OpenInstructionMenu(int GameIndex){
        UISets[GameIndex].OpenInstructionMenu();
    }

    public void OpenSettingMenu(int GameIndex){
        UISets[GameIndex].OpenSettingMenu();
    }

    public void GoBackToMenu(int GameIndex){
        UISets[GameIndex].BackToMenu();
    }

    public void ReceiveInstructionGameStart(int GameIndex)
    {
        UISets[GameIndex].StartTheGameplayUI();
    }

    public void ReceiveInstructionGameStop(int GameIndex)
    {
        UISets[GameIndex].StopTheGameplayUI();
    }
}
