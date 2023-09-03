using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;

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
        panelController.ActiveWinScreen();
    }
    public void LoseGame()
    {
        panelController.ActiveLooseScreen();
    }
    public void RegisterPanelController(PanelController _panelController) // panel kay�t
    {
        panelController = _panelController;
    }
    public void RegisterScoreText( TextMeshProUGUI scoreText)
    {
        scoreTextCompanent = scoreText; // text kay�t�
    }



}
