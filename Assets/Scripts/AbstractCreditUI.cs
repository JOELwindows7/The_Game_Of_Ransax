using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.IO;
using TMPro;

public class AbstractCreditUI : MonoBehaviour
{
    public TextAsset CreditData;
    public TextMeshProUGUI CreditText;

    void Awake(){
        LoadCredit();
    }
    public void LoadCredit(){
        if(CreditText && CreditData){
            CreditText.text = CreditData.text;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
