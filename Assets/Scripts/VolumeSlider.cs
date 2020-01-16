using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Text VolumeValueText;
    public Slider Myselft;

    // Start is called before the first frame update
    void Start()
    {
        if(!Myselft){
            Myselft = GetComponent<Slider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(VolumeValueText){
            VolumeValueText.text = Myselft? Myselft.value + " db" : "??? db";
        }
    }
}
