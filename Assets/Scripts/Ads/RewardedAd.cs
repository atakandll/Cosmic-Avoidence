using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener,IUnityAdsShowListener
{
    public int adNumber = 1;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms
    [SerializeField] private GameObject player;
    [SerializeField] private BannerAd _bannerAd;
 
    void Awake()
    {   
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        
        EndGameManager.instance.RegisterRewardedAd(this);
    }
    

    public void LoadAd()
    {
        if(Advertisement.isInitialized)
            Advertisement.Load(_adUnitId,this);
        
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId,this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        EndGameManager.instance.score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name); // score kaldığımız yerden devam ediyor.
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        //grant a reward
        if (placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Time.timeScale = 1;
            player.SetActive(true);
            
            _bannerAd.LoadBannerAd();
            
            LoadAd();
        }
    }
}
