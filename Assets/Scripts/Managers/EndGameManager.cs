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

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1; // bir sonraki levelin indexini hesapladık

        if (nextLevel > PlayerPrefs.GetInt(levelUnlock, 0)) // next level şuanki kilitten yüksekse
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



}
