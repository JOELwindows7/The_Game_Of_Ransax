using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParlorGame : MonoBehaviour
{
    public bool HasGameStarted = false;
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
        
    }
}
