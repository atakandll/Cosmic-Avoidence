using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRegistration : MonoBehaviour
{
    void Start() // texte atadýk bunu kayýtýný burdan yaptýk
    {
        TextMeshProUGUI textForRegistation = GetComponent<TextMeshProUGUI>();

        EndGameManager.instance.RegisterScoreText(textForRegistation);

        textForRegistation.text = "Score: 0 ";
    }

   
}
