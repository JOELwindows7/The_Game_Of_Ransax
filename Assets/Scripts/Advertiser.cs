﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using GoogleMobileAds.Api;
using System;
using System.IO;
//using UnityEngine.Advertisements;

public class Advertiser : Singleton<Advertiser>
{
    public bool isAdActuallyDisabled = true;

    /*
    Unity Ads
    */
    // https://www.youtube.com/watch?v=DWmD1RRORfc&t=290s

    //[SerializeField] TextAsset adMobFile;
    public string GameId = "3425704";
    [SerializeField] string AdMobFilePath = Application.streamingAssetsPath + "/AdMob/adMob_id.adMob";
    //https://docs.unity3d.com/Manual/StreamingAssets.html
    [SerializeField] string GoogleAppID = "ca-app-pub-3940256099942544~3347511713"; //Use your own ID!!!
    //admob.com
    [SerializeField] string bannerAppID = "ca-app-pub-3940256099942544/6300978111"; //Use your own ID!!!
    [SerializeField] string InterstitialID = "ca-app-pub-3940256099942544/8691691433";
    [SerializeField] string RewardeningID = "ca-app-pub-3940256099942544/5224354917";
    public bool UseTheFieldGameID = false;
    public bool TestMode = true;
    //public string placementId = "rewardedVideo";
    public string placementId_No = "video";
    public string placementId_Rewarded = "rewardedVideo";
    // Start is called before the first frame update

    public InterstitialAd interstitial;
    // https://www.youtube.com/watch?v=Nz5qD1EowL4
    
    [SerializeField] string DissectGoogleAppID;
    [SerializeField] string DissectbannerUnitID;
    [SerializeField] string DissectInterstitialUnitID;
    void DissectAdMobIDs(){
        //https://support.unity3d.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
        StreamReader reader = new StreamReader(AdMobFilePath);
        if(reader != null){
            string [] Linep = reader.ReadToEnd().Split('\n');
            string [] Reading = Linep[0].Split('#'); //https://stackoverflow.com/questions/8714197/c-sharp-streamreader-save-to-array-with-separator
            DissectGoogleAppID = Reading[0];
            DissectbannerUnitID = Reading[1];
            DissectInterstitialUnitID = Reading[2];

            reader.Close();
        } else {
            Debug.LogError("Admob ID not found");
        }
        
    }
    void InitializeAds(){
        //Advertisement.Initialize(GameId,TestMode);
        //Monetization.Initialize(GameId,TestMode);
        MobileAds.Initialize(GoogleAppID);

        //Request Google Ad banner now!
        RequestBanner(AdPosition.BottomLeft);
        RequestInterstitial(); 
    }
    public void ReinitializeAds(){
        MobileAds.Initialize(GoogleAppID);
        RequestInterstitial();
    }
    IEnumerator BufferedInitAd()
    {
        yield return new WaitForSeconds(5f);
        if(!isAdActuallyDisabled){
            InitializeAds();
        } else {
            Debug.Log("Cool and good. Ad is disabled. https://cointr.ee/joelwindows7");
            Kixlonzing.Instance.AddKixlonz(100);
        }
    }
    void Start()
    {
        AdMobFilePath = Application.streamingAssetsPath + "/AdMob/adMob_id.adMob";
        DissectAdMobIDs();
        if(Application.platform == RuntimePlatform.Android){
            GoogleAppID = TestMode? "ca-app-pub-3940256099942544~3347511713" : DissectGoogleAppID;
        } else if(Application.platform == RuntimePlatform.IPhonePlayer){
            GoogleAppID = TestMode? "ca-app-pub-3940256099942544~3347511713" : DissectGoogleAppID;
        } else {
            GoogleAppID = "";
        }
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

        // https://stackoverflow.com/questions/53478857/how-to-add-a-delay-in-a-c-sharp-unity-script
        // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        StartCoroutine(BufferedInitAd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [Range(0f,10f)][SerializeField] float ChanceAd = 0f;
    public bool NoRelyUnityAds = false;
    public bool UseTheNewUnityAds = true;

    public void ShowAd () {
        Debug.Log("Ad Attempted");

        if(!isAdActuallyDisabled){
            ChanceAd = UnityEngine.Random.Range(0f,10f);

            if(ChanceAd > 5f && !NoRelyUnityAds){
                if(!UseTheNewUnityAds) StartCoroutine (WaitForAd (false));
                else ExperimentAdvertiser.Instance.ShowAd();
            } else {
                ShowAd_Interstitial();
            }
        } else {
            Debug.Log("Ad is disabled. Cool and good. https://cointr.ee/joelwindows7");
            Kixlonzing.Instance.AddKixlonz(20);
        }
    }

    public void ShowAd_Rewarded () {
        Debug.Log("Ad Reward Attempted");

        if(!isAdActuallyDisabled){
            ChanceAd = UnityEngine.Random.Range(0f,10f);

            if(ChanceAd > 5f && !NoRelyUnityAds){
                if(!UseTheNewUnityAds) StartCoroutine (WaitForAd (true));
                else ExperimentAdvertiser.Instance.ShowAd(true);
            } else {
                ShowAd_InterstitialRewarded();
            }
        } else {
            Debug.Log("Ad Rewarded is disabled. Cool and good. https://cointr.ee/joelwindows7");
            Kixlonzing.Instance.AddKixlonz(25);
        }
    }

    public void ShowAd_Interstitial(){
        //RequestInterstitial();
        TriggerInterstitial();
    }

    public void ShowAd_InterstitialRewarded(){
        //Temporary
        ShowAd_Interstitial();
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
        Debug.Log("Ad Rewarding is " + result);
        AndroidToast.ShowToast("Ad Rewarding is " + result);
        if (result == ShowResult.Finished) {
            // Reward the player
            Kixlonzing.Instance.AddKixlonz(25);
            //AndroidToast.ShowToast("Ad Finished Rewarded");
        }
    }
    void AdFinished_No (ShowResult result) {
        Debug.Log("Ad Finish is " + result);
        AndroidToast.ShowToast("Ad Finish is " + result);
        if (result == ShowResult.Finished) {
            // Reward the player
            Kixlonzing.Instance.AddKixlonz(20);
            //AndroidToast.ShowToast("Ad Finished Regular");
        }
    }

    /*Google Ads
    Ads of Google
    Admob
    https://developers.google.com/admob/unity/banner
    https://developers.google.com/admob/unity/start
    https://developers.google.com/admob/unity/test-ads
    */

    public void RequestInterstitial(){
        if(Application.platform == RuntimePlatform.Android){
            InterstitialID = TestMode? "ca-app-pub-3940256099942544/1033173712" : DissectInterstitialUnitID;
        } else if(Application.platform == RuntimePlatform.IPhonePlayer){
            InterstitialID= TestMode? "ca-app-pub-3940256099942544/1033173712": DissectInterstitialUnitID;
        } else {
            InterstitialID = "unexpected_platform";
        }

        if(interstitial != null){
            interstitial.Destroy();
        }

        interstitial = new InterstitialAd(InterstitialID);
        AdRequest requestInters = new AdRequest.Builder().Build();

        interstitial.OnAdLoaded += HandleOnInterstitialLoaded;
        interstitial.OnAdOpening += HandleOnInterstitialOpened;
        interstitial.OnAdFailedToLoad += HandleOnInterstitialFailedToLoad;
        interstitial.OnAdClosed += HandleOnInterstitialClosed;
        interstitial.OnAdLeavingApplication += HandleOnInterstitialLeavingApplication;

        
        //https://developers.google.com/admob/unity/interstitial
        

        interstitial.LoadAd(requestInters);
        // if(interstitial.IsLoaded()){
        //     Kixlonzing.Instance.AddKixlonz(10);
        //     interstitial.Show();
        // }
    }

    private AdRequest CreateNewAdRequest(){
        return new AdRequest.Builder().Build();
    }

    public void TriggerInterstitial(){
        //Kixlonzing.Instance.AddKixlonz(10);
        if(interstitial != null){
            if(interstitial.IsLoaded()){
                interstitial.Show();
            } else {
               RequestInterstitial();
            }
        } else {
            RequestInterstitial();
        }
    }

    private BannerView bannerView;
    [SerializeField] AdPosition adPosition = AdPosition.BottomLeft;

    public void RequestBanner(){
        if(isAdActuallyDisabled) {
            Debug.Log("Banner Disabled. Cool and good. https://cointr.ee/joelwindows7");
            return;
        }

        //bannerAppID is ad unit ID
        if(Application.platform == RuntimePlatform.Android){
            bannerAppID = TestMode? "ca-app-pub-3940256099942544/6300978111" : DissectbannerUnitID;
        } else if(Application.platform == RuntimePlatform.IPhonePlayer){
            bannerAppID= TestMode? "ca-app-pub-3940256099942544/2934735716": DissectbannerUnitID;
        } else {
            bannerAppID = "unexpected_platform";
        }
        //adPosition = AdPosition.BottomLeft;
        bannerView = new BannerView(bannerAppID, AdSize.Banner, adPosition);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    public void RequestBanner(AdPosition position){
        adPosition = position;
        RequestBanner();
    }

     public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        if(TestMode) AndroidToast.ShowToast("HandleAdLoaded event received");
        Kixlonzing.Instance.AddKixlonz(5);
    }
     public void HandleOnInterstitialLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLoaded event received");
        if(TestMode) AndroidToast.ShowToast("HandleInterstitialLoaded event received");
        // if(interstitial.IsLoaded()){
        //     Kixlonzing.Instance.AddKixlonz(10);
        //     interstitial.Show();
        // }
        Kixlonzing.Instance.AddKixlonz(10);
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
        //ToastMessager.Instance.showToastOnUiThread("HandleFailedToReceiveAd event received with message: " + args.Message);
        AndroidToast.ShowToast("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleOnInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveInterstitial event received with message: "
                            + args.Message);
        //ToastMessager.Instance.showToastOnUiThread("HandleFailedToReceiveAd event received with message: " + args.Message);
        AndroidToast.ShowToast("HandleFailedToReceiveInterstitial event received with message: " + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
        Kixlonzing.Instance.AddKixlonz(10);
    }
    public void HandleOnInterstitialOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialOpened event received");
        Kixlonzing.Instance.AddKixlonz(20);
    }


    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        if(TestMode) AndroidToast.ShowToast("HandleAdClosed event received");
        Kixlonzing.Instance.AddKixlonz(10);
    }
    public void HandleOnInterstitialClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialClosed event received");
        if(TestMode) AndroidToast.ShowToast("HandleInterstitialClosed event received");
        Kixlonzing.Instance.AddKixlonz(20);
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
        if(TestMode) AndroidToast.ShowToast("HandleAdLeavingApplication event received");
        Kixlonzing.Instance.AddKixlonz(20);
    }
    public void HandleOnInterstitialLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLeavingApplication event received");
        if(TestMode) AndroidToast.ShowToast("HandleInterstitialLeavingApplication event received");
        Kixlonzing.Instance.AddKixlonz(40);
    }

    public void HideBanner(){
        if(bannerView != null){
            //bannerView.Hide();
            bannerView.Destroy();
        }
    }
}
