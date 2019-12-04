using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractUISet : MonoBehaviour
{
    public AbstractMenuVersionMember MainMenuVersion;
    public AbstractGameplayUI AbstractGameplayUI;
    public AbstractShopUI AbstractShopUI;
    public PreemptedDialog PreemptedDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheGameplayUI()
    {
        if (AbstractGameplayUI)
        {
            AbstractGameplayUI.gameObject.SetActive(true);
        }
        if (PreemptedDialog)
        {
            PreemptedDialog.IsGameStarted = true;
        }
    }
    public void StopTheGameplayUI()
    {
        if (AbstractGameplayUI)
        {
            AbstractGameplayUI.gameObject.SetActive(false);
        }
        if (MainMenuVersion)
        {
            MainMenuVersion.transform.parent.gameObject.SetActive(true);
        }
        if (PreemptedDialog)
        {
            PreemptedDialog.IsGameStarted = false;
            PreemptedDialog.gameObject.SetActive(false);
        }
    }
}
