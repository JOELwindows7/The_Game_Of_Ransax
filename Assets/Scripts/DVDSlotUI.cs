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

    public void ReceiveInstructionGameStart(int GameIndex)
    {
        UISets[GameIndex].StartTheGameplayUI();
    }

    public void ReceiveInstructionGameStop(int GameIndex)
    {
        UISets[GameIndex].StopTheGameplayUI();
    }
}
