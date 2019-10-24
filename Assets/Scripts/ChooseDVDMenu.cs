using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDVDMenu : MonoBehaviour
{
    //Just FUnctional COmponent
    public Button QuitButton;
    public CoreCanvas CoreCanvas;
    public int DVD_ID;
    public DVDMember DVDMember;
    public AbstractUISet SpecificDVD_UI_Set;
    public AbstractMenuVersionMember SelectMenuVersion;
    public void InsertDVDNumber(int annumber)
    {
        DVD_ID = annumber;
        //DVDMembers[DVD_ID].gameObject.SetActive(true);
        DVDMember = CoreCanvas.DVDSlotGame.DVDMembers[DVD_ID];
        DVDMember.gameObject.SetActive(true);
        //SpecificDVD_UI_Set[DVD_ID].gameObject.SetActive(true);
        SpecificDVD_UI_Set = CoreCanvas.DvdSlotUI.UISets[DVD_ID];
        SpecificDVD_UI_Set.gameObject.SetActive(true);
        //SelectMenuVersion = SpecificDVD_UI_Set[DVD_ID].MainMenuVersion;
        SelectMenuVersion = SpecificDVD_UI_Set.MainMenuVersion;
        SelectMenuVersion.gameObject.SetActive(true);
        CoreCanvas.LoadDVDNow();
    }
    public void EjectDVDNumber()
    {
        DVDMember.gameObject.SetActive(false);
        SpecificDVD_UI_Set.gameObject.SetActive(false);
        SelectMenuVersion.gameObject.SetActive(false);
        CoreCanvas.UnloadDVDNow();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitButtonPressed()
    {
        CoreCanvas.InvokeAreYouSureDialog(AreYouSureDialog.ConfirmsList.Shutdown);
    }
}
