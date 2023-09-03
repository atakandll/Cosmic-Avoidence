using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRegistration : MonoBehaviour
{
    void Start() // texte atad�k bunu kay�t�n� burdan yapt�k
    {
        TextMeshProUGUI textForRegistation = GetComponent<TextMeshProUGUI>();

        EndGameManager.instance.RegisterScoreText(textForRegistation);

        textForRegistation.text = "Score: 0 ";
    }

   
}
