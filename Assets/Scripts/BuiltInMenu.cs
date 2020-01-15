using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltInMenu : MonoBehaviour
{
    [SerializeField] int GameIndexIsRightNow = 0;
    public ChooseDVDMenu ChooseDvdMenu;
    public CoreCanvas coreCanvas;
    public enum MenuScreenLists { MainMenu,Setting,Shop,Equip,GameLobby,GamePlay};
    public MenuScreenLists MenuScreenRightNow;
    public AbstractMenuVersionMember[] MenuVersionMembers;
    public void PressPlayButton(int GameIndex)
    {
        coreCanvas.InstructStartGame(GameIndex);
        gameObject.SetActive(false);
    }
    public void OpenShopMenu(int GameIndex){
        coreCanvas.OpenShopMenu(GameIndex);
        gameObject.SetActive(false);
    }
    public void PressQuitButton()
    {
        //ChooseDvdMenu.EjectDVDNumber();
        coreCanvas.InvokeAreYouSureDialog(AreYouSureDialog.ConfirmsList.ChangeDVD);
    }

    public void PressInstructionButtion(int GameIndex){
        coreCanvas.OpenInstructionMenu(GameIndex);
        gameObject.SetActive(false);
    }

    public void PressCreditButton(int GameIndex){
        coreCanvas.OpenCreditMenu(GameIndex);
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        //foreach(GameObject MenuMembers in transform.ch)
        //{
        //    MenuVersionMembers = MenuMembers.GetComponent<AbstractMenuVersionMember>();
        //}
    }
    public enum MenuVersion { Custom,Horizontal,Vertical};
    public MenuVersion MenuSelectedVersion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
