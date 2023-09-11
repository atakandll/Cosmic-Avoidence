using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject adLoseScreen;
    void Start()
    {
        EndGameManager.instance.RegisterPanelController(this);
    }
    public void ActiveWinScreen()
    {
        cGroup.alpha = 1.0f;
        winScreen.SetActive(true);

    }
    public void ActiveLoseScreen()
    {
        cGroup.alpha = 1.0f;
        loseScreen.SetActive(true);
    }

    public void ActivateAdLose()
    {
        cGroup.alpha = 1.0f;
        adLoseScreen.SetActive(true);
    }

    public void DeactiveAdLose()
    {
        cGroup.alpha = 0;
        adLoseScreen.SetActive(false);
    }

   
}
