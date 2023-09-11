using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;
    public bool gameOver;
    public bool possibleWin;
    
    private PanelController panelController;
    private TextMeshProUGUI scoreTextCompanent;

    private PlayerStats player;
    private RewardedAd _rewardedAd;

    public int score;

    [HideInInspector]
    public string levelUnlock = "LevelUnlock";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // diğer levvellere geçince destroy olmucak
        }
        else
        {
            Destroy(gameObject); // diğer levele geçince olanı silicez
        }
    }
    void Start()
    {

    }
    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreTextCompanent.text = "Score: " + score.ToString();
    }
    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveGameSequences));
        StartCoroutine(ResolveGameSequences());
    }
    public IEnumerator ResolveGameSequences()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();

    }
    public void ResolveGame()
    {
        //possible win == true : we defeated the boss or the timer has expired
        //gameover == false : deactive player
        
        if (possibleWin ==true && gameOver == false) // we defeated the boss or the timer has expired and game over is false
        {
            WinGame();
        }
        else if(possibleWin == false && gameOver == true) // we are not at the end of the level but we are deactive the player
        {
            AdLoseGame();
        }
        else if (possibleWin == true && gameOver == true) // player is deactive at the end of a level
        {
            //we lost at the and of a level. Both the player and boss were destroyed
            // or the timer expired but the player was destroyed by the last meteor/ bullet.
            LoseGame();
        }
    }
    public void WinGame()
    {
        player.canTakeDamage = false; // win screen geldiğinde hiçbir şey olmucak.
        
        ScoreSet();

        panelController.ActiveWinScreen();

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1; // bir sonraki levelin indexini hesapladık

        if (nextLevel > PlayerPrefs.GetInt(levelUnlock, 0)) // next level şuanki kilitten yüksekse
        {
            PlayerPrefs.SetInt(levelUnlock, nextLevel); // save next level

        }
    }
    public void LoseGame()
    {
        ScoreSet();

        panelController.ActiveLoseScreen();
    }

    public void AdLoseGame()
    {
        ScoreSet();

        if (_rewardedAd.adNumber > 0)
        {
            _rewardedAd.adNumber -= 1;
            panelController.ActivateAdLose();

        }
        else
        {
            panelController.ActiveLoseScreen();
        }
    }
    public void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score); // her levelde farklı key olucak böylelikle

        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

        if (score > highScore) //Şu anki oyuncu puanı (score), kayıtlı yüksek puandan (highScore) daha büyükse, içindeki kod bloğunu çalıştırırız.
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score); // highScore Güncelleme
        }
        score = 0; // yeni bir oyun başladığında oyuncu puanının sıfırdan başladığı anlamına gelir. 
    }
    public void RegisterPanelController(PanelController _panelController) // panel kayıt
    {
        panelController = _panelController;
    }
    public void RegisterScoreText(TextMeshProUGUI scoreText)
    {
        scoreTextCompanent = scoreText; // text kayıtı
    }

    public void RegisterPlayerStats(PlayerStats playerStats)
    {
        this.player = playerStats;
    }

    public void RegisterRewardedAd(RewardedAd rewardedAd)
    {
        _rewardedAd = rewardedAd;
    }



}
