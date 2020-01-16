using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AbstractSettingUI : MonoBehaviour
{
    //https://www.youtube.com/watch?v=YOaYQrN1oYQ
    //Brackeys!!!

    public AudioMixer audioMixer;

    public Slider VolumeLevel;
    public TMP_Dropdown ResolutionSelect;
    public TMP_Dropdown QualitySelect;
    public Toggle FullScreenONorOFF;

    // Start is called before the first frame update
    void Start()
    {
        VolumeLevel.value = PlayerPrefs.GetFloat("VolumeLevel", 0f);
        if(PlayerPrefs.GetInt("FullScreenONorOFF", 1) == 1){
            FullScreenONorOFF.isOn = true;
        } else {
            FullScreenONorOFF.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume (float volume){
        Debug.Log("Set Volume Master to " + volume);
        PlayerPrefs.SetFloat("VolumeLevel", volume);

        if(audioMixer){
            audioMixer.SetFloat("ExposedMasterVolume", volume);
        }
    }

    public void SetQuality (int index){
        
    }

    public void SaveSetting(){
        PlayerPrefs.Save();
    }
}
