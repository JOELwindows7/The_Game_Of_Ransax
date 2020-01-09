using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDSlotGame : MonoBehaviour
{
    public DVDMember[] DVDMembers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveInstructionGameStart(int GameIndex)
    {
        Debug.Log("DVD Slot game start game");
        DVDMembers[GameIndex].StartTheGameplayContains();
    }

    public void ReceiveInstructionGameStop(int GameIndex)
    {
        Debug.Log("DVD slot game stop game");
        DVDMembers[GameIndex].StopTheGameplayContains();
    }
}
