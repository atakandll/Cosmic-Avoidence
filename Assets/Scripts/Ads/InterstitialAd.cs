using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOSAdUnitId = "Interstitial_iOS";
    [SerializeField] private BannerAd banner;
    string _adUnitId;
    [SerializeField] private int timeToSkip = 1;
 
    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        //_adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
        //  ? _iOsAdUnitId
        // : _androidAdUnitId;
        
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif  UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        int skipNumbers = PlayerPrefs.GetInt("Interstitial", timeToSkip);

        if (skipNumbers != 0)
        {
            skipNumbers -= 1;
            PlayerPrefs.SetInt("Interstitial",skipNumbers);
        }
        else
        {
           
            LoadAd();
            PlayerPrefs.SetInt("Interstitial",timeToSkip);
        }
        
    }

    


    public void LoadAd()
    {
        if(Advertisement.isInitialized)
            Advertisement.Load(_adUnitId,this);
    }

    public void ShowAd()
    {
        if(Advertisement.isShowing)
           Advertisement.Show(_adUnitId,this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Failed to load");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Show failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Show start");
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Show completed");
        Time.timeScale = 1;
        banner.LoadBannerAd();
    }
}
