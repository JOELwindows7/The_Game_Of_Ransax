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
        if (areYouSureDialog)
        {
            areYouSureDialog.gameObject.SetActive(false);
        }
    }
    public void LoadDVDNow()
    {
        chooseDVDMenu.gameObject.SetActive(false);
        BuiltInMenu.gameObject.SetActive(true);
    }
    public void UnloadDVDNow()
    {
        chooseDVDMenu.gameObject.SetActive(true);
        BuiltInMenu.gameObject.SetActive(false);
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
        Application.Quit();
        closeAreYouSureDialog();
    }
    public void GoBackToChangeDVD()
    {
        chooseDVDMenu.EjectDVDNumber();
        closeAreYouSureDialog();
    }
    public void GoBackToMainMenu()
    {
        closeAreYouSureDialog();
    }
}
