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
    private PanelController panelController;
    private TextMeshProUGUI scoreTextCompanent;

    private int score;

    [HideInInspector]
    public string levelUnlock = "LevelUnlock";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // diðer levvellere geçince destroy olmucak
        }
        else
        {
            Destroy(gameObject); // diðer levele geçince olaný silicez
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
        if (gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }
    public void WinGame()
    {
        ScoreSet();
        panelController.ActiveWinScreen();

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevel > PlayerPrefs.GetInt(levelUnlock, 0))
        {
            PlayerPrefs.SetInt(levelUnlock, nextLevel); // save next level

        }
    }
    public void LoseGame()
    {
        ScoreSet();

        panelController.ActiveLooseScreen();
    }
    public void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score); // her levelde farklý key olucak böylelikle

        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

        if (score > highScore) //Þu anki oyuncu puaný (score), kayýtlý yüksek puandan (highScore) daha büyükse, içindeki kod bloðunu çalýþtýrýrýz.
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score); // highScore Güncelleme
        }
        score = 0; // yeni bir oyun baþladýðýnda oyuncu puanýnýn sýfýrdan baþladýðý anlamýna gelir. 
    }
    public void RegisterPanelController(PanelController _panelController) // panel kayýt
    {
        panelController = _panelController;
    }
    public void RegisterScoreText(TextMeshProUGUI scoreText)
    {
        scoreTextCompanent = scoreText; // text kayýtý
    }



}
