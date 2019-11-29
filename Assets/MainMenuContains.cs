using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuContains : MonoBehaviour
{
    public Button MainPlayButton;
    public Button MainInstructionButton;
    public Button MainExitButton;

    [SerializeField] Text PlayButtonSay;
    [SerializeField] Text ExitButtonSay;

    public bool isPauseTheGame = false;

    public Text ExitButtonSay1 { get => ExitButtonSay;}
    public Text PlayButtonSay1 { get => PlayButtonSay;}

    // Start is called before the first frame update
    void Start()
    {
        if (MainPlayButton)
        {
            PlayButtonSay = MainPlayButton.transform.GetChild(0).gameObject.GetComponent<Text>();
        }
        if (MainExitButton)
        {
            ExitButtonSay = MainExitButton.transform.GetChild(0).gameObject.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPauseTheGame)
        {
            PlayButtonSay.text = "Resume";
            ExitButtonSay.text = "Quit to Menu";
        } else
        {
            PlayButtonSay.text = "Play";
            ExitButtonSay.text = "Exit";
        }
    }
}
