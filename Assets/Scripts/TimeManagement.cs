using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagement : Singleton<TimeManagement>
{
    [SerializeField] bool isGamePaused = false;
    public bool IsGamePaused { get => isGamePaused; set => isGamePaused = value; }
    public bool IsTimeFrozen { get => isTimeFrozen; /*set => isTimeFrozen = value;*/ }

    [SerializeField] bool isTimeFrozen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] float tempTimeScale;
    public void FreezeTime()
    {
        tempTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        isTimeFrozen = true;
    }

    public void UnFreezeTime()
    {
        //Time.timeScale = tempTimeScale;
        Time.timeScale = 1f;
        Debug.Log("Unfreeze Time");
        isTimeFrozen = false;
    }
}
