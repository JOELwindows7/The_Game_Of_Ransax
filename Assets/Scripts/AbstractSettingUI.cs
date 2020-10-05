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
    //RIP Brackeys Unity tutorial, 2020. no, the person himself is still alive.
    //the Brackeys seems completed idk.

    public AudioMixer audioMixer;

    public Slider VolumeLevel;
    public TMP_Dropdown ResolutionSelect;
    public TMP_Dropdown QualitySelect;
    public TMP_Dropdown BekgronSelect;
    public Toggle FullScreenONorOFF;

    public Toggle DestroyTheAdOnorOff;
    public AreYouSureDialog areYouSureDialog; //Damn, I should have been set it as Singleton.
    public BekgronQuadScroller bekgron;

    public Resolution[] ResolutionsInIt;

    [SerializeField] bool ReadyToUse = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        GetResolution();
        GetVolume();
        GetFullScreen();
        GetAdDestroyer();
        GetQuality();
        GetFullScreen();
        GetBekgronType();

        ReadyToUse = true;
        IMeanLoadResolutionSetting();
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
    public void GetVolume(){
        float Volumein = PlayerPrefs.GetFloat("VolumeLevel", 0f);
        VolumeLevel.value = Volumein;
        // if(audioMixer){
        //     audioMixer.SetFloat("ExposedMasterVolume", Volumein);
        // }
    }

    public void SetQuality (int index){
        QualitySettings.SetQualityLevel(index);
        if(ReadyToUse) PlayerPrefs.SetInt("QualitySettings", index);
    }
    public void GetQuality(){
        QualitySelect.value = PlayerPrefs.GetInt("QualitySettings", 0);
    }

    public void SetFullScreen(bool statement){
        Screen.fullScreen = statement;
        if(ReadyToUse) PlayerPrefs.SetInt("FullScreenONorOFF", statement? 1 : 0);
    }
    public void GetFullScreen(){
        if(PlayerPrefs.GetInt("FullScreenONorOFF", 1) == 1){
            FullScreenONorOFF.isOn = true;
        } else {
            FullScreenONorOFF.isOn = false;
        }
    }

    public void SetAdDestroyer(bool statement){
        if(statement){
            Advertiser.Instance.isAdActuallyDisabled = statement;
            PlayerPrefs.SetInt("DestroyTheAds", statement? 1 : 0);
        } else {
            if(areYouSureDialog){
                areYouSureDialog.spawnMessagefor(AreYouSureDialog.ConfirmsList.EnableAd);
            }
        }

        //Advertiser.Instance.isAdActuallyDisabled = statement;
        //PlayerPrefs.SetInt("DestroyTheAds", statement? 1 : 0);
    }
    public void GetAdDestroyer(){
        if(PlayerPrefs.GetInt("DestroyTheAds", 1) == 1){
            DestroyTheAdOnorOff.isOn = true;
            Advertiser.Instance.isAdActuallyDisabled = true; //Make sure it's destroyed
        } else{
            Advertiser.Instance.isAdActuallyDisabled = false;
            DestroyTheAdOnorOff.isOn = false;
        }
    }

    public int totalResolutionIndex;
    public void SetResolution(int index){
        Resolution resolution = ResolutionsInIt[index];

        if(ReadyToUse){
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            PlayerPrefs.SetInt("ResolutionIndex", index);
        }
    }
    public void GetResolution(){
        ResolutionsInIt = Screen.resolutions;

        ResolutionSelect.ClearOptions();

        List<string> ResolutionStrings = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0;i<ResolutionsInIt.Length;i++){
            string option = ResolutionsInIt[i].width + " x " + ResolutionsInIt[i].height;
            ResolutionStrings.Add(option);

            if(ResolutionsInIt[i].width == Screen.currentResolution.width && ResolutionsInIt[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
                totalResolutionIndex = i;
            }
        }
        ResolutionSelect.AddOptions(ResolutionStrings);
        ResolutionSelect.value = currentResolutionIndex;
        ResolutionSelect.RefreshShownValue();
    }

    public void IMeanLoadResolutionSetting(){
        ResolutionSelect.value = PlayerPrefs.GetInt("ResolutionIndex", totalResolutionIndex);
        // if(!Application.isMobilePlatform){
        //     if(PlayerPrefs.GetInt("ResolutionEverBeenPlay", 0) == 0){
                
        //         PlayerPrefs.SetInt("ResoltionInEverBeenPlay", 1);
        //         SaveSetting();
        //     } else {
        //     }
        // }
    }

    public int BekgronIndexi;
    public void SetBekgronType(int indexi){
        BekgronIndexi = indexi;
        bekgron.SetMaterial(BekgronIndexi);

        if(ReadyToUse) PlayerPrefs.SetInt("BekgronIndex", BekgronIndexi);
    }
    public void GetBekgronType(){
        BekgronIndexi = PlayerPrefs.GetInt("BekgronIndex", 0);
        BekgronSelect.value = BekgronIndexi;
    }

    public void SaveSetting(){
        PlayerPrefs.Save();
    }
}
