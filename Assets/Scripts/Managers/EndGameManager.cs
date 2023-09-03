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
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // di�er levvellere ge�ince destroy olmucak
        }
        else
        {
            Destroy(gameObject); // di�er levele ge�ince olan� silicez
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
    }
    public void LoseGame()
    {
        ScoreSet();

        panelController.ActiveLooseScreen();
    }
    public void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score); // her levelde farkl� key olucak b�ylelikle

        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

        if (score > highScore) //�u anki oyuncu puan� (score), kay�tl� y�ksek puandan (highScore) daha b�y�kse, i�indeki kod blo�unu �al��t�r�r�z.
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score); // highScore G�ncelleme
        }
        score = 0; // yeni bir oyun ba�lad���nda oyuncu puan�n�n s�f�rdan ba�lad��� anlam�na gelir. 
    }
    public void RegisterPanelController(PanelController _panelController) // panel kay�t
    {
        panelController = _panelController;
    }
    public void RegisterScoreText(TextMeshProUGUI scoreText)
    {
        scoreTextCompanent = scoreText; // text kay�t�
    }



}
