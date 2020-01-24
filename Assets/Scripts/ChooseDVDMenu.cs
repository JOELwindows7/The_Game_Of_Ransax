using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChooseDVDMenu : MonoBehaviour
{
    //FastBug
    public bool QuickStartNow = true;
    public int WhichQuickstart = 0;
    //Just FUnctional COmponent
    public Button QuitButton;
    public CoreCanvas CoreCanvas;
    public int DVD_ID;
    public DVDMember DVDMember;
    public AbstractUISet SpecificDVD_UI_Set;
    public AbstractMenuVersionMember SelectMenuVersion;
    public void InsertDVDNumber(int annumber)
    {
        DVD_ID = annumber;
        //DVDMembers[DVD_ID].gameObject.SetActive(true);
        DVDMember = CoreCanvas.DVDSlotGame.DVDMembers[DVD_ID];
        DVDMember.gameObject.SetActive(true);
        //SpecificDVD_UI_Set[DVD_ID].gameObject.SetActive(true);
        SpecificDVD_UI_Set = CoreCanvas.DvdSlotUI.UISets[DVD_ID];
        SpecificDVD_UI_Set.gameObject.SetActive(true);
        //SelectMenuVersion = SpecificDVD_UI_Set[DVD_ID].MainMenuVersion;
        SelectMenuVersion = SpecificDVD_UI_Set.MainMenuVersion;
        SelectMenuVersion.gameObject.SetActive(true);
        CoreCanvas.LoadDVDNow();
        Advertiser.Instance.HideBanner();
        Advertiser.Instance.RequestBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
    }
    public void ForceMoveToScene(string SceneName)
    {
        LoadLevel(SceneName);
    }
    public void EjectDVDNumber()
    {
        DVDMember.gameObject.SetActive(false);
        SpecificDVD_UI_Set.gameObject.SetActive(false);
        SelectMenuVersion.gameObject.SetActive(false);
        CoreCanvas.UnloadDVDNow();
    }
    void Awake(){
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if(QuickStartNow){
            InsertDVDNumber(WhichQuickstart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitButtonPressed()
    {
        CoreCanvas.InvokeAreYouSureDialog(AreYouSureDialog.ConfirmsList.Shutdown);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex, LoadSceneMode.Single));
    }

    public void LoadLevel(string sceneName) //This is JOELwindows7's mod. sometimes you will reffer scene by its name in the build.
    {
        StartCoroutine(LoadAsynchronously(sceneName, LoadSceneMode.Single));
    }

    public void LoadLevel(int sceneIndex, LoadSceneMode modus)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex, modus));
    }

    public void LoadLevel(string sceneName, LoadSceneMode modus) //This is JOELwindows7's mod. sometimes you will reffer scene by its name in the build.
    {
        StartCoroutine(LoadAsynchronously(sceneName, modus));
    }

    public void UnloadLevel(int sceneIndex)
    {
        StartCoroutine(UnLoadAsynchronously(sceneIndex));
    }

    public void UnloadLevel(string sceneName)
    {
        StartCoroutine(UnLoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously(int sceneIndex, LoadSceneMode loadSceneModing) //Brackeys Async loading
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, loadSceneModing);

        //if (loadingScreen && slider.value < .985f) loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);

            //if (slider) slider.value = progress;
            //if (progressText) progressText.text = progress * 100f + "%";

            //if (slider)
            //{
            //    if (slider.value >= 50)
            //    {
            //        //HajiyevMusicManager.instance.ForcePause();
            //        //MusicPlayer.ForcePause();
            //    }

            //}

            yield return null;
        }
    }

    IEnumerator LoadAsynchronously(string sceneName, LoadSceneMode loadSceneModing) //JOELwindows7
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, loadSceneModing);

        //if (loadingScreen && slider.value < .985f) loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);

            //if (slider) slider.value = progress;
            //if (progressText) progressText.text = progress * 100f + "%";

            //if (slider)
            //{
            //    if (slider.value >= 50)
            //    {
            //        //HajiyevMusicManager.instance.ForcePause();
            //        //MusicPlayer.ForcePause();
            //    }

            //}

            yield return null;
        }
    }

    IEnumerator UnLoadAsynchronously(int sceneIndex) //based on previous but this unloads
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneIndex);

        //if (loadingScreen && slider.value < .985f) loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);

            //if (slider) slider.value = progress;
            //if (progressText) progressText.text = progress * 100f + "%";

            //if (slider)
            //{
            //    if (slider.value >= 50)
            //    {
            //        //HajiyevMusicManager.instance.ForcePause();
            //        //MusicPlayer.ForcePause();
            //    }

            //}

            yield return null;
        }
    }

    IEnumerator UnLoadAsynchronously(string sceneName) //JOELwindows7
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneName);

        //if (loadingScreen && slider.value < .985f) loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);

            //if (slider) slider.value = progress;
            //if (progressText) progressText.text = progress * 100f + "%";

            //if (slider)
            //{
            //    if (slider.value >= 50)
            //    {
            //        //HajiyevMusicManager.instance.ForcePause();
            //        //MusicPlayer.ForcePause();
            //    }

            //}

            yield return null;
        }
    }
}
