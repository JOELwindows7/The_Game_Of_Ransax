using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParlorSpecificUI : MonoBehaviour
{
    [Range(0f, 100f)] public float HPLevel;
    public int AmmoNumber;
    public float ScoreNumber;

    public Slider HPBar;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.value = HPLevel;
        AmmoText.text = AmmoNumber.ToString();
        ScoreText.text = ScoreNumber.ToString();
    }
}
