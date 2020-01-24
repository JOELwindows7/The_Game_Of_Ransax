using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ExperimentAdvertiser : Singleton<ExperimentAdvertiser>, IUnityAdsListener
{
    //https://www.youtube.com/watch?v=ZbQWtd1VkJw
    // https://unityads.unity3d.com/help/unity/integration-guide-unity
    public string GameId;
    public bool TestMode;
    public string placementId_No = "video";
    public string placementId_Rewarded = "rewardedVideo";
    string selectPlacementID;
    //Kok Unity Ads gk mau muncul ya?
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        GameId = Advertiser.Instance.GameId;
        TestMode = Advertiser.Instance.TestMode;
        Advertisement.Initialize(GameId,TestMode);
    }

    // Update is called once per frame
    void Update()
    {
        GameId = Advertiser.Instance.GameId;
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
            Kixlonzing.Instance.AddKixlonz(10);
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
            Kixlonzing.Instance.AddKixlonz(10);
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == placementId_Rewarded) {
            //Advertisement.Show (selectPlacementID);
            Kixlonzing.Instance.AddKixlonz(10);
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
        Debug.LogError("Experiment Ad Error: " + message );
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 
    //Do me a favour

    // void AdFinished (ShowResult result) {
    //     Debug.Log("Ad Rewarding is " + result);
    //     AndroidToast.ShowToast("Ad Rewarding is " + result);
    //     if (result == ShowResult.Finished) {
    //         // Reward the player
    //         Kixlonzing.Instance.AddKixlonz(25);
    //         //AndroidToast.ShowToast("Ad Finished Rewarded");
    //     }
    // }
    // void AdFinished_No (ShowResult result) {
    //     Debug.Log("Ad Finish is " + result);
    //     AndroidToast.ShowToast("Ad Finish is " + result);
    //     if (result == ShowResult.Finished) {
    //         // Reward the player
    //         Kixlonzing.Instance.AddKixlonz(20);
    //         //AndroidToast.ShowToast("Ad Finished Regular");
    //     }
    // }

    public void ShowAd(bool rewarded = false){
        selectPlacementID = rewarded? placementId_Rewarded: placementId_No;
        if(Advertisement.IsReady(selectPlacementID)){
            Advertisement.Show(selectPlacementID);
        }
    }
}
