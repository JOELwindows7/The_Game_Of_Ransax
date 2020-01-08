using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kixlonzing : Singleton<Kixlonzing>
{
    //Kixlonz is prototype currency in order to make Kivrontz the Cryptocurrency. Kvz
    //Kivrontz is based on Rupiah * 10K.
    //Perkedel Patent!
    private int KixlonzAmount = 0;

    public int KixlonzAmount1 { get => KixlonzAmount; set => KixlonzAmount = value; }
    public void AddKixlonz(int amount){
        KixlonzAmount += amount;
        PlayerPrefs.SetInt("KixlonzAmount", KixlonzAmount);
        PlayerPrefs.Save();
    }

    // void Awake(){
    //     KixlonzAmount = PlayerPrefs.GetInt("KixlonzAmount", 50);
    // }

    // Start is called before the first frame update
    void Start()
    {
        KixlonzAmount = PlayerPrefs.GetInt("KixlonzAmount", 50); //Start from 50 Kxz
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
