using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreemptedDialog : MonoBehaviour
{
    public enum WhichMode { Paused, Game_Over};
    public WhichMode PreemptedMode;

    public ParlorSpecificUI itselfEngine;
    [SerializeField] bool isGamePaused = false;
    [SerializeField] bool isGameStarted = false;

    public TextMeshProUGUI PreemptTitle;
    public TMP_InputField PlayerHighScored;
    public TMP_InputField CurrentHighScored;
    public Button RetryResumeButton;
    public Button QuittoButton;

    public bool IsGamePaused { get => isGamePaused; set => isGamePaused = value; }
    public bool IsGameStarted { get => isGameStarted; set => isGameStarted = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (PreemptedMode)
        {
            default:
                break;
            case WhichMode.Paused:
                PreemptTitle.text = "PAUSED";
                RetryResumeButton.GetComponentInChildren<Text>().text = "Resume";
                break;
            case WhichMode.Game_Over:
                PreemptTitle.text = "GAME OVER";
                RetryResumeButton.GetComponentInChildren<Text>().text = "Retry";
                break;
        }
    }

    public void PressRetryResume()
    {
        //if (RetryResumeButton)
        //{
        //    if (itselfEngine)
        //    {
        //        if (itselfEngine.isGamePaused)
        //        {

        //        } else
        //        {

        //        }
        //    }
        //}
        if (IsGamePaused)
        {
            //Resume Button
            if (itselfEngine)
            {
                //Resynne funtuon
                itselfEngine.ResumeTheGame();
                gameObject.SetActive(false);
            }
        } else
        {
            if (!IsGameStarted)
            {
                //Retry Button
                if (itselfEngine)
                {
                    //Retrye FUnction


                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void PressQuitto()
    {
        if (itselfEngine)
        {
            itselfEngine.InvokeCeaseTheGameAttemp();
        }
    }
}
