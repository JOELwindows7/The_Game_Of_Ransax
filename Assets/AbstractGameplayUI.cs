﻿using System.Collections;
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
    }
    public void HideGamePlayUI()
    {
        gameObject.SetActive(false);
    }
}
