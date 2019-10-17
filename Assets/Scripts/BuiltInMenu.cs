using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltInMenu : MonoBehaviour
{
    public enum MenuScreenLists { MainMenu,Setting,Shop,Equip,GameLobby,GamePlay};
    public MenuScreenLists MenuScreenRightNow;
    public AbstractMenuVersionMember[] MenuVersionMembers;
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
