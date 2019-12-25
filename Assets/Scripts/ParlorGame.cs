using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParlorGame : MonoBehaviour
{
    public bool HasGameStarted = false;
    public FieldContains FieldContains;
    public BekgronQuadScroller bekgronding;
    // Start is called before the first frame update
    void Start()
    {
        if (!transform.parent)
        {
            HasGameStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HasGameStarted){
            //bekgronding.xVelocity = .5f;
            bekgronding.SwitchOn();
        } else {
            //bekgronding.xVelocity = 0f;
            bekgronding.SwitchOff();
        }
    }

    public void ResetObjects()
    {
        if (FieldContains)
        {
            FieldContains.resetObjects();
        }
    }

    public Spawnering[] spawnerings;
    public void StartTheGameNow()
    {
        ResetObjects();
        HasGameStarted = true;
        foreach(Spawnering spawnerr in spawnerings)
        {
            if(spawnerr)
            spawnerr.activateSpawner = true;
        }
    }
    public void StopTheGameNow()
    {
        ResetObjects();
        HasGameStarted = false;
        foreach (Spawnering spawnerr in spawnerings)
        {
            if(spawnerr)
            spawnerr.activateSpawner = false;
        }
    }
}
