using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmunitionBar : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;
    public ParlorGame engineSelf;
    public Slider AmmoMeter;
    public float AmmoNumber;
    public float MaxAmmo;

    void Awake(){
        if(!engineSelf){
            engineSelf = transform.parent.GetComponent<ParlorGame>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetAmmoTextNumber(AmmoNumber);
        AmmoMeter.value = (AmmoNumber/MaxAmmo)*100f;
    }

    public void SetAmmoTextNumber(int Number){
        AmmoText.text = "" + Number;
    }
    public void SetAmmoTextNumber(float Number){
        AmmoText.text = "" + Number;
    }

    public void ReloadButton(){
        if(!TimeManagement.Instance.IsTimeFrozen){
            if(engineSelf){
            engineSelf.BulletReload();
            }
        }
    }
}
