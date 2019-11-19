using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDMember : MonoBehaviour
{
    FieldContains FieldContains;

    private void Awake()
    {
        if(!parlorGame)
        parlorGame = GetComponent<ParlorGame>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] ParlorGame parlorGame;
    public void StartTheGameplayContains()
    {
        Debug.Log("DVD-member start game");
        if (FieldContains)
        {
            FieldContains.gameObject.SetActive(true);
        }

        if (parlorGame)
        {
            parlorGame.StartTheGameNow();
        }
    }
    public void StopTheGameplayContains()
    {
        if (FieldContains)
        {
            FieldContains.gameObject.SetActive(false);
        }

        if (parlorGame)
        {
            parlorGame.StopTheGameNow();
        }
    }
}
