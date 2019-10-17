using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCanvas : MonoBehaviour
{
    [SerializeField] ChooseDVDMenu chooseDVDMenu;
    [SerializeField] BuiltInMenu BuiltInMenu;
    [SerializeField] DVDSlotUI DvdSlotUI;
    [SerializeField] AreYouSureDialog areYouSureDialog;
    // Start is called before the first frame update
    private void Awake()
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

    public void InvokeAreYouSureDialog(AreYouSureDialog.ConfirmsList SelectDialog)
    {
        areYouSureDialog.AreYouSureTo = SelectDialog;
        InvokeAreYouSureDialog();
    }

    public void ShutdownHexagonEngine()
    {
        Debug.Log("Shutdown Hexagon Engine initiated!");
        Application.Quit();
    }
    public void GoBackToChangeDVD()
    {

    }
    public void GoBackToMainMenu()
    {

    }
}
