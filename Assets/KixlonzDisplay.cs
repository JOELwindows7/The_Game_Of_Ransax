using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KixlonzDisplay : MonoBehaviour
{
    public TextMeshProUGUI KXZtext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KXZtext.text = "KXZ " + Kixlonzing.Instance.KixlonzAmount1;
    }
}
