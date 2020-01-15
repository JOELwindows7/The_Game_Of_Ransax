using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCanvas : MonoBehaviour
{
    public ChooseDVDMenu chooseDVDMenu;
    public BuiltInMenu BuiltInMenu;
    public DVDSlotUI DvdSlotUI;
    public AreYouSureDialog areYouSureDialog;
    public DVDSlotGame DVDSlotGame;
    public int DVD_ID;
    //public DVDMember[] DVDMembers;
    //public AbstractUISet[] SpecificDVD_UI_Set;
    // Start is called before the first frame update
    public void initGame()
    {
        //Time.timeScale = 1f;
        TimeManagement.Instance.UnFreezeTime();
        if (chooseDVDMenu)
        {
            chooseDVDMenu.gameObject.SetActive(true);
        }
        if (BuiltInMenu)
        {
            BuiltInMenu.gameObject.SetActive(false);
        }
        if (DvdSlotUI)
        {
            DvdSlotUI.gameObject.SetActive(false);
        }
        if (DVDSlotGame)
        {
            DVDSlotGame.gameObject.SetActive(false);
        }
        if (areYouSureDialog)
        {
            areYouSureDialog.gameObject.SetActive(false);
        }
    }
    public void LoadDVDNow()
    {
        chooseDVDMenu.gameObject.SetActive(false);
        BuiltInMenu.gameObject.SetActive(true);
        DVDSlotGame.gameObject.SetActive(true);
        DvdSlotUI.gameObject.SetActive(true);
    }
    public void UnloadDVDNow()
    {
        chooseDVDMenu.gameObject.SetActive(true);
        BuiltInMenu.gameObject.SetActive(false);
        DVDSlotGame.gameObject.SetActive(false);
        DvdSlotUI.gameObject.SetActive(false);
    }
    private void Awake()
    {
        initGame();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstructStartGame(int GameIndex)
    {
        Advertiser.Instance.HideBanner();
        DvdSlotUI.ReceiveInstructionGameStart(GameIndex);
        DVDSlotGame.ReceiveInstructionGameStart(GameIndex);
    }
    public void InstructStopGame(int GameIndex)
    {
        DvdSlotUI.ReceiveInstructionGameStop(GameIndex);
        DVDSlotGame.ReceiveInstructionGameStop(GameIndex);
        Debug.Log("Instruct Stop Game");
    }

    public void InstructGameOver(int GameIndex){

    }

    public void OpenShopMenu(int GameIndex){
        Advertiser.Instance.HideBanner();
        Advertiser.Instance.RequestBanner(GoogleMobileAds.Api.AdPosition.Bottom);
        DvdSlotUI.OpenShopMenu(GameIndex);
    }

    public void OpenCreditMenu(int GameIndex){
        Advertiser.Instance.HideBanner();
        DvdSlotUI.OpenCreditMenu(GameIndex);
    }
    public void OpenInstructionMenu(int GameIndex){
        Advertiser.Instance.HideBanner();
        DvdSlotUI.OpenInstructionMenu(GameIndex);
    }

    public void InvokeAreYouSureDialog()
    {
        areYouSureDialog.gameObject.SetActive(true);
    }
    public void closeAreYouSureDialog()
    {
        areYouSureDialog.gameObject.SetActive(false);
    }

    public void InvokeAreYouSureDialog(AreYouSureDialog.ConfirmsList SelectDialog)
    {
        areYouSureDialog.AreYouSureTo = SelectDialog;
        InvokeAreYouSureDialog();
    }

    public void ShutdownHexagonEngine()
    {
        Debug.Log("Shutdown Hexagon Engine initiated!");
        Advertiser.Instance.ShowAd();
        Application.Quit();
        closeAreYouSureDialog();
    }
    public void GoBackToChangeDVD()
    {
        Advertiser.Instance.HideBanner();
        Advertiser.Instance.RequestBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
        chooseDVDMenu.EjectDVDNumber();
        closeAreYouSureDialog();
        Advertiser.Instance.ShowAd();
    }
    public void GoBackToMainMenu()
    {
        //DvdSlotUI.ReceiveInstructionGameStop(DVD_ID);
        InstructStopGame(DVD_ID);
        closeAreYouSureDialog();
        Advertiser.Instance.ShowAd();
        Advertiser.Instance.HideBanner();
        Advertiser.Instance.RequestBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
    }

    public void JustBackToMainMenu(){
        Advertiser.Instance.HideBanner();
        Advertiser.Instance.RequestBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
        DvdSlotUI.GoBackToMenu(DVD_ID);
    }
}
