using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGameplayUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameplayUI()
    {
        gameObject.SetActive(true);
        //Ugh! man. this is bad. Instance reference system makes games tangled!
        //you should always inherit to make it standalone DVD. where the Core only starts the app, not also manage the game states.
        // Like OSes usually. OS usually only execute the app, not manage how does it run.
        // because apps are programmed whatever it becomes.
        // and OSes should not give any peck.
    }
    public void HideGamePlayUI()
    {
        gameObject.SetActive(false);
    }
}
