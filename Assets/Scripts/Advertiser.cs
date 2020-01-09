using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
//using UnityEngine.Advertisements;

public class Advertiser : Singleton<Advertiser>
{
    // https://www.youtube.com/watch?v=DWmD1RRORfc&t=290s

    [SerializeField] string GameId = "3425704";
    [SerializeField] bool UseTheFieldGameID = false;
    [SerializeField] bool TestMode = false;
    //public string placementId = "rewardedVideo";
    public string placementId_No = "video";
    public string placementId_Rewarded = "rewardedVideo";
    // Start is called before the first frame update
    void Start()
    {
        if(UseTheFieldGameID){
        } else {
            switch(Application.platform){
                case RuntimePlatform.IPhonePlayer:
                GameId = "3425704";
                break;

                case RuntimePlatform.Android:
                GameId = "3425705";
                break;

                default:
                GameId = "3425704";
                break;
            }
        }

        //Advertisement.Initialize(GameId,TestMode);
        Monetization.Initialize(GameId,TestMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void ShowAd () {
        Debug.Log("Ad Attempted");
        StartCoroutine (WaitForAd (false));
    }

    public void ShowAd_Rewarded () {
        Debug.Log("Ad Reward Attempted");
        StartCoroutine (WaitForAd (true));
    }

    IEnumerator WaitForAd (bool rewarded = false) {
        string selectPlacementID = rewarded? placementId_Rewarded: placementId_No;
        while (!Monetization.IsReady (selectPlacementID)) {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (selectPlacementID) as ShowAdPlacementContent;

        if (ad != null) {
            if(rewarded){
                ad.Show (AdFinished);
            } else {
                ad.Show(AdFinished_No);
            }
            
        }
    }

    void AdFinished (ShowResult result) {
        Debug.Log("Ad Rewarding");
        if (result == ShowResult.Finished) {
            // Reward the player
            Kixlonzing.Instance.AddKixlonz(25);
        }
    }
    void AdFinished_No (ShowResult result) {
        Debug.Log("Ad Finish");
        if (result == ShowResult.Finished) {
            // Reward the player
            Kixlonzing.Instance.AddKixlonz(20);
        }
    }
}
