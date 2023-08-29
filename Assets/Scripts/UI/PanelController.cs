using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    void Start()
    {
        EndGameManager.instance.RegisterPanelController(this);
    }
    public void ActiveWinScreen()
    {
        cGroup.alpha = 1.0f;
        winScreen.SetActive(true);

    }
    public void ActiveLooseScreen()
    {
        cGroup.alpha = 1.0f;
        loseScreen.SetActive(true);
    }

   
}
