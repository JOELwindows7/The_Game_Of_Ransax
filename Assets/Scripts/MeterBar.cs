using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterBar : MonoBehaviour
{
    [Range(0f,100f)] public float value = 100f;
    public Color barColor = Color.white;
    public Slider targetBar;
    public Image FillAreaImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetBar){
            targetBar.value = value;
        }
        if(FillAreaImage){
            FillAreaImage.color = barColor;
        }
    }
}
